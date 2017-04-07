using Xamarin.Forms;
using System.Collections.Generic;

using CafeteriaLibraries;
namespace CafeteriaApplication
{
	public partial class CafeteriaApplicationPage : ContentPage
	{
		// Lets create a list that will hold the values of cafeterias, 
		// we wrap our list in an observable value, so if the list changes
		// the view will update 
		// we bind the itemsource of lsvCafeterias to the Value property of Cafeterias

		public ObservableValue<List<Cafeteria>> Cafeterias { get; set; }

		// we will create an object to get information about the cafeterias
		private CafeteriaService service;

		// page constructor
		public CafeteriaApplicationPage()
		{
			// we need to initialize our list and service
			Cafeterias = new ObservableValue<List<CafeteriaLibraries.Cafeteria>>();
			service = new CafeteriaService();

			// this will bind the properies of this class to the view, 
			// this line is crucial for our infomation to show up in the UI
			BindingContext = this;

			// loads the UI 
			InitializeComponent();

			// lets load our data
			Load();


			// we want to create a handler for when a user taps on an item in the list
			lsvCafeterias.ItemSelected += async (sender, e) =>
			{
				// get the item we just tapped on
				CafeteriaLibraries.Cafeteria caf = e.SelectedItem as CafeteriaLibraries.Cafeteria;

				// check to make sure item isnt null
				if (caf == null)
					return;

				// navigate to our menu page, with the cafeteria object
				await Navigation.PushAsync(new CafeteriaApplicationMenuPage(caf));



			};


		}
		public async void Load()
		{
			// set our list equal to the list of cafeterias
			// since we are asigning a value, our observable value code will notifiy the UI to update
			Cafeterias.Value = service.GetCafeterias();
		}
	}
}
