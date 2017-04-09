using System;
using System.Collections.Generic;

using Xamarin.Forms;

using CafeteriaLibraries;

namespace CafeteriaApplication
{
	public partial class CafeteriaPage : ContentPage
	{

		// define a view model to bind to our view
		public CafeteriaViewModel ViewModel { get; set; }

		public CafeteriaPage()
		{

			// instantiate our view model
			ViewModel = new CafeteriaViewModel();

			// bind our view model to our view
			BindingContext = ViewModel;

			InitializeComponent();


			lsvCafeterias.ItemTapped+= async  (sender, e) => {

				// get the tapped item
				Cafeteria selected = (Cafeteria)e.Item;

				// make sure it was casted right
				if (selected == null)
					return;

				// navigate to our menu page with our selected cafeteria
				await Navigation.PushAsync(new CafeteriaMenuPage(selected));
			};
		}
	}
}
