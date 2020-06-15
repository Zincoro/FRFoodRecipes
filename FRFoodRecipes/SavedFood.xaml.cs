using FRFoodRecipes.API;
using FRFoodRecipes.API.Models;
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
    public partial class SavedFood : ContentPage
    {
        ApiProxy apiProxy = new ApiProxy();
        public static List<SingleRootObject> foodDatabase1;
        public static SavedFoodTable savedFood;
        public static UriModel uriModel;
        public APIController apicontroller = new APIController();
        

        public SavedFood()
        {
            InitializeComponent();

            getSavedFood(); //Calls the getSavedFood method when called 
        }

        private async void FoodResults_ItemTapped(object sender, ItemTappedEventArgs e) //When tapped the savedfood icon, it gets it uri and then makes an api call for the uri 
        {
            var recDets = (SavedFoodTable)e.Item;
            var itemUri = recDets.Uri;
            var foodDatabase = await RecipesAPI.GetRecipeFromUri(itemUri);

            await Navigation.PushAsync(new RecipeDetailSaved(foodDatabase)); //calls a new recipe details page with  a new model class specific for savedfood database
        }

        private async void getSavedFood() //empty the foodresults list, get all the food that matches the users id if its saved
        {
            FoodResults.ItemsSource = null;
            var getFood = await apiProxy.GetSavedFood(LoginPage.userInfo.UserId);

            if (getFood.Count != 0) //If the count is 0 the lbl that says "You havent searched for a food yet" is hidden
            {
                lblDataInfo.IsVisible = false;
                FoodResults.ItemsSource = getFood; //Then the saved data is added into the list
            }
            else
            {
                lblDataInfo.IsVisible = true; //otherwise keep the lbl visible
            }

        }

        private void FoodResults_Refreshing(object sender, EventArgs e) //pull to refresh, when pulled it recalls the method and then turns off the refresh icon
        {
            getSavedFood();
            FoodResults.IsRefreshing = false;
        }
    }
}