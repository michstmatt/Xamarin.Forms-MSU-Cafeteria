using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

using CafeteriaLibraries;

namespace CafeteriaApplication
{
	public partial class CafeteriaMenuPage : ContentPage
	{
		// cafteria model
		public Cafeteria Cafeteria { get; set; }

		// our service object, 
		// used to get information about the cafeteria
		private CafeteriaService Service;



		public CafeteriaMenuPage(Cafeteria cafeteria)
		{

			// set our Cafeteria Property to the selected cafeteria
			Cafeteria = cafeteria;

			// instantiate our service 
			Service = new CafeteriaService();

			// call load to get the cafeteria information
			Load();

			// bind our cafeteria to our view
			BindingContext = Cafeteria;

			InitializeComponent();
		}

		public async void Load()
		{
			await Service.GetCafeteria(Cafeteria);
		}
	}
}
