using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CafeteriaLibraries
{
	public class CafeteriaService
	{
		
		public async Task<Cafeteria> GetCafeteria(Cafeteria cafeteria)
		{
			// create http client to handle our request
			HttpClient client = new HttpClient();

			// make our request
			HttpResponseMessage response = await client.GetAsync($"https://eatatstate.com/menus/{cafeteria.Key}/feed");

			// make sure response is good
			if (response.IsSuccessStatusCode)
			{
				// read in the content 
				Stream content = await response.Content.ReadAsStreamAsync();
				XDocument doc = XDocument.Load(content);


				foreach (var item in doc.Descendants("item"))
				{
					// get the station name
					// format is 'Cafeteria-Station name'
					// lets get Station name
					StationGroup station = new StationGroup();
					station.StationName = item.Element("title").Value.Split('-')[1];

					// lets get the menus

					var description = Regex.Replace(item.Element("description").Value, "<.*?>", string.Empty);

					// we are looking for this pattern 
					// "Breakfast Menu:&nbsp;"
					// \w+ word
					// \s whitespace
					// \w+:&nbsp word with trailing
					string pattern = "\\w+\\s\\w+:&nbsp;";

					// get menu for each meal
					var menus = Regex.Matches(description, pattern);

					// split up items by meal
					var menuItems = Regex.Split(description, pattern);

					// iterate through menus
					for (int index = 0; index < menus.Count; index++)
					{
						// get menu meal, Breakfast, Lunch, Dinner, Late
						string meal = Regex.Match(menus[index].Value, "\\w+").Value;

						MenuItemGroup menuGroup = new MenuItemGroup();
						menuGroup.Meal = (MealType)(Enum.Parse(typeof(MealType), meal));

						// looking for words separted by newlines

						foreach (string menuItem in Regex.Split(menuItems[index + 1], "\\n"))
						{
							// remove all leading and trailing whitespace
							string trimmed = menuItem.Trim();
							// make sure its not an empty or null string
							if (!string.IsNullOrEmpty(trimmed))
							{
								// add a new menu item to our menu group
								menuGroup.MenuItems.Add(new MenuItem()
								{
									Meal = menuGroup.Meal,

									// decode any HTML charcater codes
									Name = System.Net.WebUtility.HtmlDecode(trimmed)
								});
							}
						}
						station.Add(menuGroup);

					}

					// add the station to the cafeteria
					cafeteria.Stations.Add(station);

				}


			}
			return cafeteria;
		}

	}
}
