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
        public static RootObject foodDatabase;
        public static List<SingleRootObject> foodDatabase1;

        private ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>();

        private ObservableCollection<List<SingleRootObject>> tempModel = new ObservableCollection<List<SingleRootObject>> ();

        public APIController apicontroller = new APIController();

        public SavedFood()
        {
            InitializeComponent();

            getSavedFood();
        }

        private void FoodResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void getSavedFood()
        {
            var getFood = await apiProxy.GetSavedFood(LoginPage.userInfo.UserId);
            //if (getFood != null)
            //{
            //    List<RootObject> foods = new List<RootObject>();
            //    foreach (var item in getFood)
            //    {
            //        foods.Add(await RecipesAPI.GetRecipeFromUri(item.Uri));
            //    }
            //}
            //apiModel = apicontroller.GetRecipeResults(foodDatabase);
            //FoodResults.ItemsSource = apiModel;
            foodDatabase1 = await RecipesAPI.GetRecipeFromUri();
            tempModel = apicontroller.GetSingleRecipeByURI(foodDatabase1);
            FoodResults.ItemsSource = tempModel;
        }
    }
}