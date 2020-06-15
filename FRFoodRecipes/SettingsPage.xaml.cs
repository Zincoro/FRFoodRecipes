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
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage() //Gets the Info from the Login page for the user and fills in the textboxes when the page loads
        {
            InitializeComponent();

            txtFirstName.Text = LoginPage.userInfo.Fname;
            txtLastName.Text = LoginPage.userInfo.Lname;
            txtUsername.Text = LoginPage.userInfo.Username;
            txtEmail.Text = LoginPage.userInfo.Email;
        }

        private async void btnLogout_Clicked(object sender, EventArgs e) // Asks user if they want to logout, if yes takes them back to the LoginPage
        {
            bool answer = await DisplayAlert("Logout?", "Are you sure you want to logout?", "Yes", "No");
            if (answer)
            {
                //var existingPages = Navigation.NavigationStack.ToList();
                //foreach (var page in existingPages)
                //{
                //    Navigation.RemovePage(page);
                //}
                App.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
                return;
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e) //Validation if fields are empty etc, 
        {
            if (String.IsNullOrEmpty(txtFirstName.Text) || String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
                await DisplayAlert("Error", "All fields must be filled", "Try Again");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                await DisplayAlert("Error", "Password & Confirm Password are not the same", "Try Again");
            else if (txtPassword.Text != LoginPage.userInfo.Pword)
                await DisplayAlert("Error", "Incorrect Password", "Try Again");
            else if (LoginPage.userInfo.Pword == txtNewPassword.Text)
                await DisplayAlert("Error", "New Password cannot be same as old password", "Try Again");
            else if (!String.IsNullOrWhiteSpace(txtNewPassword.Text) && txtNewPassword.Text.Length < 10)
                await DisplayAlert("Error", "New Password must be 10 characters or longer", "Try Again");
            else
            {
                ApiProxy apiProxy = new ApiProxy();
                UserTable updateUser = new UserTable(); //a new instance of the modelclass is created to updateuser 
                updateUser.UserId = LoginPage.userInfo.UserId;
                updateUser.Fname = txtFirstName.Text;
                updateUser.Lname = txtLastName.Text;
                updateUser.Username = txtUsername.Text;
                updateUser.Email = txtEmail.Text;

                if (!String.IsNullOrEmpty(txtNewPassword.Text)) //If txtNewPassword contains anything in it, update everything
                {
                    updateUser.Pword = txtNewPassword.Text;
                    var user = await apiProxy.UpdateUser(updateUser);
                    if (user == null)
                    {
                        await DisplayAlert("Error", "Account could not be updated", "Try Again");
                    }
                    else
                        await DisplayAlert("Success", "Account Updated", "Ok");
                }
                else //Else if new password is empty, update everything else except the password
                {
                    updateUser.Pword = txtPassword.Text;
                    var user = await apiProxy.UpdateUser(updateUser);
                    if (user == null)
                    {
                        await DisplayAlert("Error", "Account could not be updated", "Try Again");
                    }
                    else
                        await DisplayAlert("Success", "Account Updated", "Ok");
                }
            }
        }
    }
}