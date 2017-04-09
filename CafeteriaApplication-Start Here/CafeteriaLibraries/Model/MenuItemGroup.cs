using System;
using System.Linq;
using System.Collections.Generic;
namespace CafeteriaLibraries
{
	public class MenuItemGroup
	{
		public MealType Meal { get; set; }
		public List<MenuItem> MenuItems { get; set; }
		public string MenuString
		{
			get
			{
				// get the item text
				// combine (aggregate) them into a line separted string
				return MenuItems.Select(item => item.Name)
								.Aggregate((item1, item2) => item1 + Environment.NewLine + item2);
			}
		}
		public MenuItemGroup()
		{
			MenuItems = new List<MenuItem>();
		}


	}
}
