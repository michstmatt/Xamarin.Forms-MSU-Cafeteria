using Xamarin.Forms;

namespace CafeteriaApplication
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// create a navigation page
			// this will give us navigation, with back button between pages
			// the root page will be a list of cafeterias


			MainPage = new NavigationPage(new CafeteriaApplicationPage())
			{

				// set the the top bar color to green
				// set the text of the top bar to white 

				BarBackgroundColor = Color.Green,
				BarTextColor = Color.White

			};
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
