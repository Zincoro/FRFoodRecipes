using FRFoodRecipes.API;
using FRFoodRecipes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FRFoodRecipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static UserTable userInfo; //Model class Usertable to be filled

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e) //When login clicked, check if fields are empty, if not ...
        {
            if (String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text))
                await DisplayAlert("Error", "All fields must be filled", "Try Again");
            else
            {
                ApiProxy apiProxy = new ApiProxy();

                var user = await apiProxy.GetUser(txtUsername.Text, txtPassword.Text); //send the username and password to the private api to see if it matches

                if (user != null) //If it matches and the user exists, add all of the users data into the model class of UserInfo to be used throughout the app, sending the user to home page
                {
                    userInfo = user;

                    //await Navigation.PopModalAsync();
                    var page = Navigation.NavigationStack.LastOrDefault();
                    await Navigation.PushAsync(new MainPage());
                    Navigation.RemovePage(page);
                }
                else
                {
                    await DisplayAlert("Error", "Account not found", "Try Again"); //Otherwise account not found
                }
            }
                

        }

        private async void btnSignup_Clicked(object sender, EventArgs e) //When signup clicked, navigation takes to the signup page
        {
            await Navigation.PushModalAsync(new Signup());
        }
    }
}