using System;
using System.Collections.ObjectModel;
namespace CafeteriaLibraries
{
	public class CafeteriaViewModel
	{
		public ObservableCollection<Cafeteria> Cafeterias { get; set; }
		public CafeteriaViewModel()
		{
			Cafeterias = new ObservableCollection<Cafeteria>();

			Cafeterias.Add(new Cafeteria { Name = "Brody Square", Key = "brody" });
			Cafeterias.Add(new Cafeteria { Name = "The Edge at Akers", Key = "akers" });
			Cafeterias.Add(new Cafeteria { Name = "Holmes", Key = "holmes" });
			Cafeterias.Add(new Cafeteria { Name = "Riverwalk Market", Key = "riverWalk" });
			Cafeterias.Add(new Cafeteria { Name = "The Vista at Shaw", Key = "shaw" });
			Cafeterias.Add(new Cafeteria { Name = "The Gallery at Snyder/Phillips", Key = "gallery" });
			Cafeterias.Add(new Cafeteria { Name = "Heritage Commons at Landon", Key = "landon" });
			Cafeterias.Add(new Cafeteria { Name = "South Pointe at Case", Key = "case" });
			Cafeterias.Add(new Cafeteria { Name = "Holden", Key = "holden" });
			Cafeterias.Add(new Cafeteria { Name = "Wilson", Key = "wilson" });

		}
	}
}
