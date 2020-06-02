using FRFoodRecipes.API;
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
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            ApiProxy apiProxy = new ApiProxy();

            var user = await apiProxy.GetUser(txtUsername.Text, txtPassword.Text);

            if (user != null)
            {
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "Account not found", "Try Again");
            }

        }

        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Signup());
        }
    }
}