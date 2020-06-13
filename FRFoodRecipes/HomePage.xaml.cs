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
        public static RootObject foodDatabase;
        private ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>();
        //private APIModel SelectedItem;

        public APIController apicontroller = new APIController();

        public HomePage()
        {
            InitializeComponent();
        }

        private void btnFilter_Pressed(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new FilterPopup());
        }

        private async void searchRecipe_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchedRecipe = searchRecipe.Text;
            foodDatabase = await RecipesAPI.GetRecipe(searchedRecipe);
            apiModel = apicontroller.GetRecipeResults(foodDatabase);
            FoodResults.ItemsSource = apiModel;
            lblDataInfo.IsVisible = false;
        }

        private async void FoodResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recDets = e.Item as APIModel;
            //await Navigation.PushAsync(new RecipeDetail(recDets.uri, recDets.foodName, recDets.imageUri, recDets.source, recDets.sourceUrl, recDets.shareAs, recDets.yield, recDets.dietLabels, recDets.healthLabels, recDets.cautions, recDets.ingredientLines, recDets.ingredients, recDets.calories, recDets.totalWeight, recDets.totalTime, recDets.totalNutrients, recDets.totalDaily, recDets.digest));
            await Navigation.PushAsync(new RecipeDetail(recDets));
        }
    }
}