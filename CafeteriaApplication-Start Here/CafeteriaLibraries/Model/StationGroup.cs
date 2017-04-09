using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace CafeteriaLibraries
{
	public class StationGroup:ObservableCollection<MenuItemGroup>
	{
		public string StationName { get; set; }

	}

}
