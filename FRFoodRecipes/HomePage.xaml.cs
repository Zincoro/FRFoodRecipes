using FRFoodRecipes.API;
using FRFoodRecipes.API.Models;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FRFoodRecipes.API.RecipesAPI;

namespace FRFoodRecipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public static RootObject foodDatabase; //static variable of the rootobject
        private ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>(); //Private model of APIModel in list

        public APIController apicontroller = new APIController(); 

        public HomePage()
        {
            InitializeComponent();
        }

        private void btnFilter_Pressed(object sender, EventArgs e) //When filter button pressed, call the filter page
        {
            PopupNavigation.Instance.PushAsync(new FilterPopup());
        }

        private async void searchRecipe_SearchButtonPressed(object sender, EventArgs e) //When searched, send the searched string by the user into the api for results and display it in the foodresults list
        {
            var searchedRecipe = searchRecipe.Text;
            foodDatabase = await RecipesAPI.GetRecipe(searchedRecipe);
            apiModel = apicontroller.GetRecipeResults(foodDatabase);
            FoodResults.ItemsSource = apiModel;
            lblDataInfo.IsVisible = false;
        }

        private async void FoodResults_ItemTapped(object sender, ItemTappedEventArgs e) //Each tapped item, gets its items as the APIModel and sends them to the recipe detail page to be displayed
        {
            var recDets = e.Item as APIModel;
            await Navigation.PushAsync(new RecipeDetail(recDets));
        }
    }
}