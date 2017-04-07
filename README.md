# Xamarin.Forms MSU Cafeteria Application


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
5. Notice that there are a few additional folders within the `Todo` project, called `Models`, `View Models`, and `Views`. These terms come from the [MVVM architectural pattern](https://en.wikipedia.org/wiki/Model_View_ViewModel). You don't need to know too much about MVVM, aside from the fact it helps to architect your applications in a scalable and decoupled manner. `Views` are simply the visual objects you see when you launch an app. `View Models` add behavior to `Views`. Finally, `Models` are just representations of something we are trying to abstract, like a todo item.
6. Go ahead and compile and run your app. We are going to transform this into a functional todo app to keep up with all the assignments we have to complete for class.
