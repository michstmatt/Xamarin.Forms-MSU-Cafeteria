using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace CafeteriaLibraries
{
	public class Cafeteria
	{
		public string Name { get; set; }
	        
		public string Key { get; set; }
		 

		public ObservableCollection<StationGroup> Stations { get; set; }

		public Cafeteria() {

			Stations = new ObservableCollection<StationGroup>();

		}
	}
}
