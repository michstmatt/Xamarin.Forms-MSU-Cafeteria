using Xamarin.Forms;

namespace CafeteriaApplication
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			// create a root page
			CafeteriaPage root = new CafeteriaPage();

			// set the back button text to nothing
			NavigationPage.SetBackButtonTitle(root,"");

			// set up the navigation page to so we can navigate between pages
			MainPage = new NavigationPage(root)
			{
				BarTextColor = Color.White,
				BarBackgroundColor= Color.Green
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
