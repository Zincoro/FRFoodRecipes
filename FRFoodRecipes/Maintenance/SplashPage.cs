using FRFoodRecipes.API;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FRFoodRecipes.Maintenance
{
    public class SplashPage : ContentPage
    {
        public static bool isRemember;
        Image splashImage;

        public SplashPage() //Initially to be used as a loading screen but not working for some reason, app.xaml sends us to this page, loads logo and once loaded sends to the loginpage
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "Logo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.White;
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000);
            await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await splashImage.ScaleTo(150, 1200, Easing.Linear);

            if (await LocalStorage.ReadTextFileAsync("Remember.txt") == "true")
                isRemember = true;
            else
                isRemember = false;

            if (isRemember)
            {
                var userName = await LocalStorage.ReadTextFileAsync("Username.txt");
                var pwrd = await LocalStorage.ReadTextFileAsync("Pwrd.txt");

                ApiProxy apiProxy = new ApiProxy();
                LoginPage.userInfo = await apiProxy.GetUser(userName, pwrd);
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
                Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
