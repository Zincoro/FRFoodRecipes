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
        //public static RootObject foodDatabase;
        public static List<SingleRootObject> foodDatabase1;

        //private ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>();

        //private APIModel apiModel = new APIModel();
        private ObservableCollection<List<SingleRootObject>> tempModel = new ObservableCollection<List<SingleRootObject>> ();
        public static SavedFoodTable savedFood;
        public static UriModel uriModel;
        public APIController apicontroller = new APIController();
        

        public SavedFood()
        {
            InitializeComponent();

            getSavedFood();
        }

        private async void FoodResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var recDets = (SavedFoodTable)e.Item;
            var itemUri = recDets.Uri;
            var foodDatabase = await RecipesAPI.GetRecipeFromUri(itemUri);

            await Navigation.PushAsync(new RecipeDetailSaved(foodDatabase));
        }

        private async void getSavedFood()
        {
            FoodResults.ItemsSource = null;
            var getFood = await apiProxy.GetSavedFood(LoginPage.userInfo.UserId);

            if (getFood.Count != 0)
            {
                lblDataInfo.IsVisible = false;
                FoodResults.ItemsSource = getFood;
            }
            else
            {
                lblDataInfo.IsVisible = true;
            }
            //IsRefreshing = false;
            ////if (getFood != null)
            ////{
            ////    List<RootObject> foods = new List<RootObject>();
            ////    foreach (var item in getFood)
            ////    {
            ////        foods.Add(await RecipesAPI.GetRecipeFromUri(item.Uri));
            ////    }
            ////}
            ////apiModel = apicontroller.GetRecipeResults(foodDatabase);
            ////FoodResults.ItemsSource = apiModel;
            //foodDatabase1 = await RecipesAPI.GetRecipeFromUri(getFood);
            //tempModel = apicontroller.GetSingleRecipeByURI(foodDatabase1);
            //foreach (var item in tempModel)
            //{
            //    FoodResults.ItemsSource = item;
            //}

        }

        private void FoodResults_Refreshing(object sender, EventArgs e)
        {
            getSavedFood();
            FoodResults.IsRefreshing = false;
        }
    }
}