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
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        private async void btnSignup_Pressed(object sender, EventArgs e) //Simple validation if fields empty, if passwords dont match or if passwords too short
        {
            if (String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtFirstName.Text) || String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtPasswordConfirm.Text) || String.IsNullOrEmpty(txtUsername.Text))
                await DisplayAlert("Error", "All fields must be filled", "Try Again");
            else if (txtPassword.Text != txtPasswordConfirm.Text)
                await DisplayAlert("Error", "Passwords are not the same", "Try Again");
            else if (txtPasswordConfirm.Text.Length < 10 && txtPassword.Text.Length < 10)
                await DisplayAlert("Error", "Password must be 10 characters or longer", "Try Again");
            else
            {
                UserTable newuser = new UserTable(); //An instance of UserTable called new user which is then filled with the data
                newuser.Username = txtUsername.Text;
                newuser.Fname = txtFirstName.Text;
                newuser.Lname = txtLastName.Text;
                newuser.Email = txtEmail.Text;
                newuser.Pword = txtPassword.Text;

                ApiProxy apiProxy = new ApiProxy(); //Instance of the ApiProxy page to be called 

                var user = await apiProxy.NewUser(newuser); //then sends the data to the api 


                if (user == null) //if user isnt found show error
                {
                    await DisplayAlert("Error", "Account cannot be created", "Try Again");
                }
                else //if the user IS found, take the user back to the login page to be logged in
                {
                    await Navigation.PopModalAsync();
                }
            }
        }

        private async void btnCancelSignup_Pressed(object sender, EventArgs e) //Button if they wanna go back to the login page and cancel their sign up
        {
            await Navigation.PopModalAsync();
        }
    }
}