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

![Alt text](/Images/UIBreakDown1.png?raw=true "Finished Application")
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

6. Next, we want an easy way to navigate after a cell is tapped. Luckily, Xamarin.Forms list views expose an event called `ItemSelected` for this purpose. First, we are going to want to add a name to our list view by adding the `x:Name` property to `TodoPage.xaml` as follows: 

		<ListView x:Name="todoListView"
			ItemsSource="{Binding Todos}">
		</ListView>

7. Hop back over to `TodoPage.xaml.cs` and you should be able to add a lambda expression (fancy name for an anonymous method in C#) to the constructor that looks something like this:

		todoListView.ItemSelected += (sender, e) => {
			// Navigation logic here
		};

8. To navigate, all we have to do is use the `Navigation.PushAsync`method, coupled with an instance of the `TodoDetailPage`. When done, your `TodoPage.xaml.cs` should look something like this:

		using System;
		using System.Collections.Generic;

		using Xamarin.Forms;

		namespace Todo
		{
			public partial class TodoPage : ContentPage
			{
				public TodoPage ()
				{
					BindingContext = new TodoViewModel ();

					InitializeComponent ();

					todoListView.ItemSelected += (sender, e) => {
						if (todoListView.SelectedItem == null)
							return;

						Navigation.PushAsync (new TodoDetailPage (todoListView.SelectedItem as TodoItem));

						todoListView.SelectedItem = null;
					};
				}
			}
		}

9. Compile and run! Tap a cell in the list view... and boom! You should navigate to a new page with the title of the item that you just selected. Awesome! Now it's time to update our detail view so people can edit and view their todos in more detail.

---

#### Finish Detail Page

1. Jump back to `TodoDetailPage.xaml`. Let's add some visual elements. First, let's create a `StackLayout`, which is a managed layout. All we will have to do is define the order of controls, and the `StackLayout` will handle the rest for us.
2. Inside the `StackLayout`, let's add a few labels, two `Entry`s (for editing the title and description) and a `Switch` (for toggling the state of task). At this point, your XAML will look something like this:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoDetailPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<StackLayout Padding="15, 20, 15, 20">
					<Label Text="Title" />
					<Entry Text="Name" />
					<Label Text="Description" />
					<Entry Text="Description" />
					<Label Text="Done?" />
					<Switch IsToggled="false" />
				</StackLayout>
			</ContentPage.Content>
		</ContentPage>

3. Compile and run the app. Great! We have a nice structure, now let's actually hook this up to our selected `TodoItem` so we can actually make changes. Remember, to update our data, we need to use data binding. Because our `BindingContext` for `TodoDetailPage` is already set to the `TodoItem`, all we have to do is bind to specific properties of our `TodoItem`, like the name, description, and status. Give it a try yourself, but this is what `TodoDetailPage.xaml` should look like when you are done:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoDetailPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<StackLayout Padding="15, 20, 15, 20">
					<Label Text="Title" />
					<Entry Text="{Binding Name}" />
					<Label Text="Description" />
					<Entry Text="{Binding Description}" />
					<Label Text="Task Completed" />
					<Switch IsToggled="{Binding Done}" />
				</StackLayout>
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

### Walkthrough #1b - Building a Todo App
Being in college is tough. When you aren't working on a group project you waited *way* too long to get started on, you are probably cramming for a test or skipping class. Naturally, it's easy to lose track of your assignments. Today, you are going to build your first mobile app for iOS, Android, and Windows Phone - a simple todo app - to solve your problem.

---

#### Project Setup and Architecture

1. Open the solution (inside a folder called `Todo - Start Here`) using either Xamarin Studio or Visual Studio.
2. There are four projects inside the solution: `Todo`, `Todo.iOS`, `Todo.Droid`, and `Todo.WinPhone`. Remember, Xamarin.Forms allows you to build native UIs for iOS, Android, and Windows Phone from a single, shared codebase. The `Todo` project is a library called a PCL - or Portable Class Library. All the code we write here will be shared between iOS, Android, and Windows Phone.
3. Expand the `Todo.iOS`, `Todo.Droid`, and `Todo.WinPhone` projects. We won't have to work with these today, but if you wanted to add functionality to your app that requires APIs that are platform-specific, you would make those changes here.
4. Back to our `Todo` project. Open the `App.cs` file. This is the entry point for our Xamarin.Forms application. We can manage important app lifecycle events here, such as the app resuming, starting up, or sleeping. The most important thing is to define a `MainPage`, which will be the first page users see when they launch your app.
5. Notice that there are a few additional folders within the `Todo` project, called `Models`, `View Models`, and `Views`. These terms come from the [MVVM architectural pattern](https://en.wikipedia.org/wiki/Model_View_ViewModel). You don't need to know too much about MVVM, aside from the fact it helps to architect your applications in a scalable and decoupled manner. `Views` are simply the visual objects you see when you launch an app. `View Models` add behavior to `Views`. Finally, `Models` are just representations of something we are trying to abstract, like a todo item.
6. Go ahead and compile and run your app. We are going to transform this into a functional todo app to keep up with all the assignments we have to complete for class.

---

#### Create the Main Page

1. Back to Xamarin.Forms! We want the UI for the todo app to be simple - really simple. When users launch the app, there should be a list of all incomplete todos. You should be able to click each todo to get more information. Finally, we need an easy way to add new todos. Let's add a page to show a list of all outstanding todos. Right-click the `Views` folder. Click Add->New File. Select the `Forms` category on the left-hand side. Create a new `Forms ContentPage XAML` and name it "TodoPage". This creates a new page that uses XAML markup to define UIs.
2. After the page is added, you will see that there are two files: a `TodoPage.xaml` file and a `Todo.xaml.cs` file. `TodoPage.xaml` is where we will describe our UI using XAML markup. `TodoPage.xaml.cs` is called a codebehind, and is just a place where we can add functionality to our views (if we don't do so in our view model).
3. Open up `TodoPage.xaml` and add a new ListView under `<ContentPage.Content>`. A list view is just a list of items, and is in almost every mobile app you've ever used, if you know where to look. Here is what your `TodoPage.xaml` code should look like:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoPage">
			<ContentPage.Content>
				<ListView>
				</ListView>
			</ContentPage.Content>
		</ContentPage>

4. Remember, nobody will see this page if we don't let our application know that this is the main page. Jump back to `App.cs` and set the `MainPage` property to an instance of the page we just created, or `MainPage = new TodoPage ();`.
5. Compile and run the app, and you should now see a list view when the app launches.

---

#### Populate the ListView

1. Time to add some data to our list view! Remember, a page's behavior should come from a view model, not the page itself? For every page, we should create a new view model that adds behavior to the visual elements on the page. For your conveienence, you we have gone ahead and added the view model (`TodoViewModel`) for you. Also, if you go check out the `Models` folder, specifically `TodoItem.cs`, you will see that we have a "model" representation of a todo item, including a name, description, and something to let us know if the todo was completed.
2. Open back up `TodoViewModel.cs`. Our list view needs data to operate on; we can add this data by creating a list of todo items and connecting that to our list view. You can see that we created a new `ObservableCollection<TodoItem>` property called `Todos`, which is basically just a List<T>, except with support for MVVM. In the constructor, we went ahead and provided some dummy starting data to populate our app on launch.
3. Remember how our view model is supposed to help out our view by supplying data and behavior? How do they share data? MVVM came up with a concept of data binding, which basically means that a view's property is "bound" to a property of our view model. Whenever the property changes (via view model), the view will update to reflect the changes. This is why we had to use an `ObservableCollection<T>`, rather than just a regular list. `ObservableCollection` is a special class made for data binding that will automatically alert our view that data has changed, and that the view needs to update. Now that we have bindings defined on the view model end, we need to update our view to handle this.
4. Time to give the list view the data it needs! Jump back over to `TodoPage` and open up the codebehind (`TodoPage.xaml.cs`). In the constructor, add `BindingContext = new TodoViewModel ()`. Why? We need to let our page know the source of all the data bindings we will create.
5. In `TodoPage.xaml`, update the `ItemsSource` property to `"{Binding Todos}"`. This will mean that all the items for our list view will come from the `Todos` property of our binding context, which we just set to a new `TodoViewModel`. Also, add the `Title` property to your page in XAML and set the value to "Todos". For clarity, this is what your XAML should look like right now:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoPage"
			Title="Todos">
			<ContentPage.Content>
				<ListView ItemsSource="{Binding Todos}">
				</ListView>
			</ContentPage.Content>
		</ContentPage>

6. `ListViews` in Xamarin.Forms are made up of individual cells. Adding a cell is easy! There are many different types of cells, but what we will be using is called a `TextCell`. Also, remember how the list view is populated from the `Todos` binding, which is an `ObservableCollection<TodoItem>`? This means that each cell is representative of a single `TodoItem`. We should update our bindings to reflect that. When you are done, you should have something like this:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoPage"
			Title="Todos">
			<ContentPage.Content>
				<ListView x:Name="todoListView"
					ItemsSource="{Binding Todos}">
					<ListView.ItemTemplate>
						<DataTemplate>
							<TextCell Text="{Binding Name}" />
						</DataTemplate>
					</ListView.ItemTemplate>
				</ListView>
			</ContentPage.Content>
		</ContentPage>

7. Compile and run your app. You should see your todo items in the list view!

--- 

#### Add a Navigation Bar and Setup Detail Page

1. Now it's time to take our todo app and make it a multi-page app. When a user taps on a todo item in the list, we want to open a new page that contains the item with the name, description, and if the task is done or not. This is called push-pop navigation, as a new page is pushed onto the screen, and then poped off. (Technically, it's pushing/popping off the navigation stack, but you get the point.)
2. Hop back to `App.cs`. Let's update our `MainPage` property so that we can handle this type of navigation. This will also add a navigation bar, so we will style that a bit as well.

		MainPage = new NavigationPage (new TodoPage ()) {
		  BarTextColor = Color.White,
		  BarBackgroundColor = Color.FromHex ("2C97DE")
		};

3. Compile and run your app. You should see a beautiful blue navigation bar with white text that says "Todos". Great, now that the framework is in place to handle navigation, let's create a new page for viewing and editing existing todos. Right-click the `Views` folder. Click Add->New File. Select the `Forms` category on the left-hand side. Create a new `Forms ContentPage XAML` and name it "TodoDetailPage".
4. In `TodoDetailPage.xaml.xs` update the constructor to have the following signature `public TodoDetailPage (TodoItem item)`. Why? When a user selects a cell, we want to pass our selected item along to the page.
5. Remember how the binding context for `TodoPage` was a view model? It doesn't always have to be! In this case, we are binding to a single item, a `TodoItem`, so we can just set the `BindingContext = item` in the constructor of `TodoDetailPage`. We can use this binding in our actual page by adding a `Title` property to our `ContentPage` tag, and binding to the `TodoItem`'s name.

		TodoDetailPage.xaml.cs

		using System;
		using System.Collections.Generic;

		using Xamarin.Forms;

		namespace Todo
		{
			public partial class TodoDetailPage : ContentPage
			{
				public TodoDetailPage (TodoItem item)
				{
					BindingContext = item;

					InitializeComponent ();
				}
			}
		}

		TodoDetailPage.xaml

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoDetailPage"
			Title="{Binding Name}">
			<ContentPage.Content>
			</ContentPage.Content>
		</ContentPage>

6. Next, we want an easy way to navigate after a cell is tapped. Luckily, Xamarin.Forms list views expose an event called `ItemSelected` for this purpose. First, we are going to want to add a name to our list view by adding the `x:Name` property to `TodoPage.xaml` as follows: 

		<ListView x:Name="todoListView"
			ItemsSource="{Binding Todos}">
			<ListView.ItemTemplate>
				<DataTemplate>
					<TextCell Text="{Binding Name}" />
				</DataTemplate>
			</ListView.ItemTemplate>
		</ListView>

7. Hop back over to `TodoPage.xaml.cs` and you should be able to add a lambda expression (fancy name for an anonymous method in C#) to the constructor that looks something like this:

		todoListView.ItemSelected += (sender, e) => {
			// Navigation logic here
		};

8. To navigate, all we have to do is use the `Navigation.PushAsync`method, coupled with an instance of the `TodoDetailPage`. When done, your `TodoPage.xaml.cs` should look something like this:

		using System;
		using System.Collections.Generic;

		using Xamarin.Forms;

		namespace Todo
		{
			public partial class TodoPage : ContentPage
			{
				public TodoPage ()
				{
					BindingContext = new TodoViewModel ();

					InitializeComponent ();

					todoListView.ItemSelected += (sender, e) => {
						if (todoListView.SelectedItem == null)
							return;

						Navigation.PushAsync (new TodoDetailPage (todoListView.SelectedItem as TodoItem));

						todoListView.SelectedItem = null;
					};
				}
			}
		}

9. Compile and run! Tap a cell in the list view... and boom! You should navigate to a new page with the title of the item that you just selected. Awesome! Now it's time to update our detail view so people can edit and view their todos in more detail.

---

#### Finish Detail Page

1. Jump back to `TodoDetailPage.xaml`. Let's add some visual elements. First, let's create a `StackLayout`, which is a managed layout. All we will have to do is define the order of controls, and the `StackLayout` will handle the rest for us.
2. Inside the `StackLayout`, let's add a few labels, two `Entry`s (for editing the title and description) and a `Switch` (for toggling the state of task). At this point, your XAML will look something like this:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoDetailPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<StackLayout Padding="15, 20, 15, 20">
					<Label Text="Title" />
					<Entry Text="Name" />
					<Label Text="Description" />
					<Entry Text="Description" />
					<Label Text="Done?" />
					<Switch IsToggled="false" />
				</StackLayout>
			</ContentPage.Content>
		</ContentPage>

3. Compile and run the app. Great! We have a nice structure, now let's actually hook this up to our selected `TodoItem` so we can actually make changes. Remember, to update our data, we need to use data binding. Because our `BindingContext` for `TodoDetailPage` is already set to the `TodoItem`, all we have to do is bind to specific properties of our `TodoItem`, like the name, description, and status. Give it a try yourself, but this is what `TodoDetailPage.xaml` should look like when you are done:

		<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="Todo.TodoDetailPage"
			Title="{Binding Name}">
			<ContentPage.Content>
				<StackLayout Padding="15, 20, 15, 20">
					<Label Text="Title" />
					<Entry Text="{Binding Name}" />
					<Label Text="Description" />
					<Entry Text="{Binding Description}" />
					<Label Text="Task Completed" />
					<Switch IsToggled="{Binding Done}" />
				</StackLayout>
			</ContentPage.Content>
		</ContentPage>

4. Compile and run the app again. Wow! Now we can make changes to the todo on the detail screen, and return to see our changes are still there. You may have noticed, if you update the title of the todo, it will also update the cell in the list view.

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
