using System;
using System.Collections.Generic;

using Xamarin.Forms;

using CafeteriaLibraries;

namespace CafeteriaApplication
{
	public partial class CafeteriaApplicationMenuPage : ContentPage
	{

		// private variable to hold our cafeteria object
		public ObservableValue<Cafeteria> Cafeteria { get; set; }

		// our service to handle calls to MSU to get cafeteria
		private CafeteriaService CafeteriaService;


		// page constructor, with cafeteria object 
		public CafeteriaApplicationMenuPage(Cafeteria cafeteria)
		{
			

			Cafeteria = new ObservableValue<Cafeteria>();
			Cafeteria.Value = cafeteria;

			CafeteriaService = new CafeteriaService();


			BindingContext = Cafeteria.Value;


			InitializeComponent();



			Load();
		}

		public async void Load()
		{
			
			await CafeteriaService.GetCafeteria(Cafeteria.Value);

		}
	}
}
