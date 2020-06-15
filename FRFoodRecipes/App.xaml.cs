using FRFoodRecipes.Maintenance;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FRFoodRecipes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            /////////MainPage = new NavigationPage(new LoginPage());
            //var navi = Application.Current.MainPage as NavigationPage;

            MainPage = new NavigationPage(new SplashPage()); //The root page of the App
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
