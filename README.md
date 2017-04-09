# Xamarin.Forms MSU Cafeteria Application

![Alt text](/Images/AppFinal.png?raw=true "Finished Application")

### Setup
Before you being building your first mobile app, you need to make sure you have everything properly installed.

1. Install [Xamarin](https://xamarin.com/download). Xamarin allows you to build cross-platform native apps for iOS, Android, and Windows Phone using C#.
2. Install the [Xamarin Android Player](https://xamarin.com/android-player). The Xamarin Android Player uses hardware-accelerated virtualization to simulate, debug, demo, or run Android apps. Think Android emulators, but faster.
3. Download the demo. You can do so by clicking the "Download" button on the righthand side of this page.
4. Request a free Xamarin subscription. Xamarin is free for students! All you have to do is visit [xamarin.com/student#apply](xamarin.com/student#apply) to apply.

### Walkthrough #1a - Building a Cafeteria App
What's for lunch at Shaw Cafeteria today? You don't want to have to check the website everytime, what if there was an app that could do it for you? Today, you are going to build your first mobile app for iOS, Android, and Windows Phone.

---

#### Project Setup and Architecture 

1. Open the solution (inside a folder called `CafeteriaApplication - Start Here`) using either Xamarin Studio or Visual Studio.
2. There are four projects inside the solution: `CafeteriaApplication`, `CafeteriaApplication.iOS`, `CafeteriaApplication.Droid`, and `CafeteriaLibraries`. Remember, Xamarin.Forms allows you to build native UIs for iOS, Android, and Windows Phone from a single, shared codebase. The `Todo` project is a library called a PCL - or Portable Class Library. All the code we write here will be shared between iOS, Android, and Windows Phone.
3. Expand the `CafeteriaApplication.iOS`, and `CafeteriaApplication.Droid` projects. We won't have to work with these today, but if you wanted to add functionality to your app that requires APIs that are platform-specific, you would make those changes here.
4. Back to our `CafeteriaApplication` project. Open the `App.cs` file. This is the entry point for our Xamarin.Forms application. We can manage important app lifecycle events here, such as the app resuming, starting up, or sleeping. The most important thing is to define a `MainPage`, which will be the first page users see when they launch your app.
5. Notice that there are a few additional folders within the `Todo` project, called `Models`, `View Models`, and `Views`. These terms come from the [MVVM architectural pattern](https://en.wikipedia.org/wiki/Model_View_ViewModel). You don't need to know too much about MVVM, aside from the fact it helps to architect your applications in a scalable and decoupled manner. `Views` are simply the visual objects you see when you launch an app. `View Models` add behavior to `Views`. Finally, `Models` are just representations of something we are trying to abstract, like a cafeteria.
6. Go ahead and compile and run your app. We are going to transform this into a functional todo app to keep up with all the assignments we have to complete for class.

---

#### Create the Main Page

1. Back to Xamarin.Forms! We want the UI to be simple - really simple. When users launch the app, there should be a list of all incomplete todos. You should be able to click each todo to get more information. Finally, we need an easy way to add new todos. Let's add a page to show a list of all outstanding todos. Right-click the `Views` folder. Click Add->New File. Select the `Forms` category on the left-hand side. Create a new `Forms ContentPage XAML` and name it "CafeteriaApplicationPage". This creates a new page that uses XAML markup to define UIs.
2. After the page is added, you will see that there are two files: a `CafeteriaApplicationPage.xaml` file and a `CafeteriaApplicationPage.xaml.cs` file. `CafeteriaApplicationPage.xaml` is where we will describe our UI using XAML markup. `CafeteriaApplicationPage.xaml.cs` is called a codebehind, and is just a place where we can add functionality to our views (if we don't do so in our view model).
3. Open up `CafeteriaApplicationPage.xaml` and add a new ListView under `<ContentPage.Content>`. A list view is just a list of items, and is in almost every mobile app you've ever used, if you know where to look.
4. Remember, nobody will see this page if we don't let our application know that this is the main page. Jump back to `App.cs` and set the `MainPage` property to an instance of the page we just created, or `MainPage = new CafeteriaApplicationPage ();`.
5. Compile and run the app, and you should now see a list view when the app launches.

---

#### Populate the ListView

1. Time to add some data to our list view! Remember, a page's behavior should come from a view model, not the page itself? For every page, we should create a new view model that adds behavior to the visual elements on the page. 

2. We will be utilizing the class `Cafeteria` from the `CafeteriaLibraries` Library

	```
	public class Cafeteria
	{
		public string Name { get; set; }
	        
		public string Key { get; set; }
		 
		public ObservableCollection<StationGroup> Stations { get; set; }

		public Cafeteria() 
		{
			Stations = new ObservableCollection<StationGroup>();
		}
	}
	```

3. We will also be utilizing our class `CafeteriaViewModel.cs`, to bind to our view

	```
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

	```

4. Our list view needs data to operate on; we can add this data by creating a list of todo items and connecting that to our list view. Add `using System.Collections.ObjectModel;` to the top of the file. This will allow us access to some extra classes that we will use for storing our data. Next, create a new `ObservableCollection<Cafeteria>` property called `Caferterias`, which is basically just a List<T>, except with support for MVVM. 

5. In the constructor for the view model, let's add our list of cafeterias to populate our app on launch. You can do this several ways, but one easy way is:

			Cafeterias = new ObservableCollection<Cafeteria>();
			Cafeterias.Add(new Cafeteria { Name = "Brody Square", Key = "brody" });
			Cafeterias.Add(new Cafeteria { Name = "The Edge at Akers", Key = "akers" });

6. Remember how our view model is supposed to help out our view by supplying data and behavior? How do they share data? MVVM came up with a concept of data binding, which basically means that a view's property is "bound" to a property of our view model. Whenever the property changes (via view model), the view will update to reflect the changes. This is why we had to use an `ObservableCollection<T>`, rather than just a regular list. `ObservableCollection` is a special class made for data binding that will automatically alert our view that data has changed, and that the view needs to update. Now that we have bindings defined on the view model end, we need to update our view to handle this.

7. Time to give the list view the data it needs! Jump back over to `CafeteriaPage` and open up the codebehind (`CafeteriaPage.xaml.cs`). 

	```
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
			

	```
	
Why? We need to let our page know the source of all the data bindings we will create. 

8. In `CafeteriaPage.xaml`, update the `ItemsSource` property to `"{Binding Cafeterias}"`. This will mean that all the items for our list view will come from the `Todos` property of our binding context, which we just set to a new `CafeteriaViewModel`. For clarity, this is what your XAML should look like right now.
		
		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="CafeteriaApplication.CafeteriaPage" Title="Cafeterias">
			<ContentPage.Content>

				<ListView x:Name="lsvCafeterias" ItemsSource="{Binding Cafeterias}">

				</ListView>
			</ContentPage.Content>
		</ContentPage>
		
9. `ListViews` in Xamarin.Forms are made up of individual cells. Adding a cell is easy! There are many different types of cells, but what we will be using is called a `TextCell`. Also, remember how the list view is populated from the `Cafeterias` binding, which is an `ObservableCollection<Cafeteria>`? This means that each cell is representative of a single `Cafeteria`. We should update our bindings to reflect that. When you are done, you should have something like this:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="CafeteriaApplication.CafeteriaPage" Title="Cafeterias">
			<ContentPage.Content>

				<ListView x:Name="lsvCafeterias" ItemsSource="{Binding Cafeterias}">
					<ListView.ItemTemplate>
						<DataTemplate>
							<TextCell Text="{Binding Name}" TextColor="Black" />
						</DataTemplate>
					</ListView.ItemTemplate>
				</ListView>
			</ContentPage.Content>
		</ContentPage>

10. Compile and run your app. You should see your todo items in the list view!

---

#### Add a Navigation Bar and Setup Detail Page

1. Now it's time to take our todo app and make it a multi-page app. When a user taps on a todo item in the list, we want to open a new page that contains the item with the name, description, and if the task is done or not. This is called push-pop navigation, as a new page is pushed onto the screen, and then poped off. (Technically, it's pushing/popping off the navigation stack, but you get the point.)
2. Hop back to `App.cs`. Let's update our `MainPage` property so that we can handle this type of navigation. This will also add a navigation bar, so we will style that a bit as well.

	```
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
	```

3. Compile and run your app. Now, you should see a green navigation bar with white text that says "Cafeterias". Great, now that the framework is in place to handle navigation, let's create a new page for viewing and editing existing todos. Right-click the `Views` folder. Click Add->New File. Select the `Forms` category on the left-hand side. Create a new `Forms ContentPage XAML` and name it "CafeteriaMenuPage".
4. In `CafeteriaMenuPage.xaml.xs` update the constructor to have the following signature `public CafeteriaMenuPage (Cafeteria cafeteria)`. Why? When a user selects a cell, we want to pass our selected item along to the page.

5. Remember how the binding context for `CafeteriaPage` was a view model? It doesn't always have to be! In this case, we are binding to a single item, a `Cafeteria`. We will create a property to hold our Cafeteria so we can just set the `BindingContext = Cafeteria` in the constructor of `CafeteriaMenuPage`. We can use this binding in our actual page by adding a `Title` property to our `ContentPage` tag, and binding to the `Cafeterias`'s name.

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="CafeteriaApplication.CafeteriaMenuPage"
			Title="{Binding Name}">
			<ContentPage.Content>
			</ContentPage.Content>
		</ContentPage>

6. Next, we want an easy way to navigate after a cell is tapped. Luckily, Xamarin.Forms list views expose an event called `ItemSelected` for this purpose. First, we are going to want to add a name to our list view by adding the `x:Name` property to `CafeteriaPage.xaml` as follows: 

		<ListView x:Name="lsvCafeterias"
			ItemsSource="{Binding Cafeterias}">
		</ListView>

7. Hop back over to `CafeteriaPage.xaml.cs` and you should be able to add a lambda expression (fancy name for an anonymous method in C#) to the constructor that looks something like this:

		lsvCafeterias.ItemSelected += (sender, e) => {
			// Navigation logic here
		};

8. To navigate, all we have to do is use the `Navigation.PushAsync`method, coupled with an instance of the `TodoDetailPage`. When done, your `TodoPage.xaml.cs` should look something like this:

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


9. Compile and run! Tap a cell in the list view... and boom! You should navigate to a new page with the title of the item that you just selected. Awesome! Now it's time to update our detail view so people can edit and view their todos in more detail.

![Alt text](/Images/UIBreakDown1.png?raw=true "Finished Application")
---

#### Finish Menu Page

1. Jump back to `CafeteriaMenuPage.xaml`. Let's add some visual elements. We will add a ListView to show all of our Stations and their Items.
2. Our ListView will be grouped by station so we will need to tell our ListView out elements our grouped `IsGroupingEnabled="true"`. We also want to tell our ListView what the value of the headers will be, `GroupDisplayBinding="{Binding StationName}"`. Last each row will have text of varying size, for our UI to conform to this `HasUnevenRows="true"`

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="CafeteriaApplication.CafeteriaMenuPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<ListView ItemsSource="{Binding Stations}" HasUnevenRows="true" IsGroupingEnabled="true" GroupDisplayBinding="{Binding StationName}">
				</ListView>
			</ContentPage.Content>
		</ContentPage>

3. Compile and run the app. Great! We have a nice structure, now let's actually hook this up to our `Stations` so we can actually make changes. Remember, to update our data, we need to use data binding. Because our `BindingContext` for `CafeteriaMenuPage` is already set to the `Cafeteria`, all we have to do is bind to specific properties of our `Station`, like the Meal and MenuString. Give it a try yourself, but this is what `CafeteriaPage.xaml` should look like when you are done:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage 
			xmlns="http://xamarin.com/schemas/2014/forms" 
			xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			x:Class="CafeteriaApplication.CafeteriaMenuPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<ListView ItemsSource="{Binding Stations}" HasUnevenRows="true" IsGroupingEnabled="true" GroupDisplayBinding="{Binding StationName}">
					<ListView.ItemTemplate>
						<DataTemplate>
							<ViewCell>
								<StackLayout>
									<Label Margin="10,0,0,0" FontSize="18" TextColor="Green" Text="{Binding Meal}" />
									<Label Margin="20,0,0,0" TextColor="Black" Text="{Binding MenuString}" />
								</StackLayout>
							</ViewCell>
						</DataTemplate>
					</ListView.ItemTemplate>
				</ListView>
			</ContentPage.Content>
		</ContentPage>


4. Compile and run the app again. Wow! Now we can make changes to the todo on the detail screen, and return to see our changes are still there. However, you may have noticed, if you update the title of the todo, it doesn't update on the list view. This is because nothing is notifying the list view that the `TodoItem` has changed. Fixing this is easy! All we have do is implement an interface called `INotifyPropertyChanged`, which will let our UI know about changes to the `TodoItem`. Copy the `TodoItem` implementation below back into your `TodoItem` class.

		using System;
		using System.ComponentModel;

		namespace Todo
		{
			public class TodoItem : INotifyPropertyChanged
			{
				private string name;

				public string Name 
				{ 
					get { return name; }
					set { name = value; NotifyPropertyChanged ("Name"); }
				}
				public string Description { get; set; }
				public bool Done { get; set; }

				public event PropertyChangedEventHandler PropertyChanged;

				private void NotifyPropertyChanged(String info)
				{
					if (PropertyChanged != null)
					{
						PropertyChanged(this, new PropertyChangedEventArgs(info));
					}
				}
			}
		}


5. If you run the compile and app again, you should see that the title now updates when it is changed on the `TodoDetailPage`. 

---

#### Add functionality for creating items

1. One last step: we are missing a page to add new items. One easy way to do this is to add an "Add" button to our navigation bar, which will add a new todo to our list view that we can edit. Hop back over to `TodoPage.xaml.cs`. We can access what Xamarin.Forms calls the toolbar by using the `ToolbarItems` property on our `TodoPage`, and adding a new `ToolbarItem`. Add the following code to the constructor of the `TodoPage` class:

		ToolbarItems.Add (new ToolbarItem ("Add", null, async () => {
			// This is where we define actions that will happen when the "Add" button is tapped.
		}));

2. Now that we have a toolbar item, we need to make it actually do something! Let's add a new `TodoItem` to the list view. Remember how our list view uses the `ItemsSource` property, which references `BindingContext`of our page? Luckily for us, almost all the heavily lifting is done to do this. Because `ItemsSource` is binded to our `ObservableCollection<TodoItem>`, all updates to that collection will automatically update the UI. All we need to do then, is to add a new `TodoItem` to this collection. There are a few ways to acccomplish this, but this is the easiest:

		ToolbarItems.Add (new ToolbarItem ("Add", null, async () => {
			// Get a reference to our view model
			var viewModel = BindingContext as TodoViewModel;
			// Add our todo to the Todos collection
			viewModel.Todos.Add (new TodoItem { Name = "New Todo", Description = "Edit Me", Done = false });
		}));


3. Compile and run the app, and you have a working todo application! You will now be able to keep track of your assignments using this simple app that you built for iOS, Android, and Windows Phone. :) If you are up to the challenge, jump to Walkthrough #2, and learn how to add a cloud backend to your application (so you can view your todos anywhere), using [Microsoft Azure App Service](https://azure.microsoft.com/en-us/services/app-service/).


