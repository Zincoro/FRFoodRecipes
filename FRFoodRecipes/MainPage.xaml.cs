using FRFoodRecipes.API;
using FRFoodRecipes.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace FRFoodRecipes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public static UserTable user = new UserTable(); //Model class of Usertable
        public MainPage()
        {
            //If user isn't already logged in, push LognPage on top of NavigationPage
            //Navigation.PushModalAsync(new LoginPage());
            //else stay on home page

            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom); //Sets the navigation bar to bottom, disabled swiping...
            On<Android>().SetIsSwipePagingEnabled(false);
            On<Android>().SetBarSelectedItemColor(Color.FromHex("#028ee6"));
            On<Android>().SetBarItemColor(Color.Black);
            this.CurrentPageChanged += TabbedPage_CurrentPageChanged;

            InitializeComponent();

            Children.Add(new HomePage()); //Adds pages as children with icons and titles
            Children.Add(new SavedFood());
            Children.Add(new SettingsPage());
            Children[0].IconImageSource = "homedark.png";
            Children[0].Title = "Home";
            Children[1].IconImageSource = "ic_action_fastfooddark.png";
            Children[1].Title = "Saved Food";
            Children[2].IconImageSource = "ic_action_settingsdark.png";
            Children[2].Title = "Settings";
            CurrentPage = Children[0]; //The page it loads first (Home Page)
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e) //If the page detects change and the children 0 is detected (Being home) than title is changed to home
        {
            if (CurrentPage == Children[0])
            {
                this.Title = "Home";
            }
            else if (CurrentPage == Children[1])
            {
                this.Title = "Saved Food";
            }
            else if (CurrentPage == Children[2])
            {
                this.Title = "Settings";
            }
        }
    }
}
