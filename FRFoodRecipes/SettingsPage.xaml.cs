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
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void btnLogout_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Logout?", "Are you sure you want to logout?", "Yes", "No");
            if (answer)
            {
                //var existingPages = Navigation.NavigationStack.ToList();
                //foreach (var page in existingPages)
                //{
                //    Navigation.RemovePage(page);
                //}
            }
            else
                return;
        }
    }
}