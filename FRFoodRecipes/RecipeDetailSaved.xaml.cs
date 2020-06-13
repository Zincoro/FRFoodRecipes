using FRFoodRecipes.API;
using FRFoodRecipes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static FRFoodRecipes.API.RecipesAPI;

namespace FRFoodRecipes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetailSaved : TabbedPage //Duplication of page RecipeDetail because it accepts a different model
    {
        ApiProxy apiProxy = new ApiProxy();
        SavedFoodTable saveFood = new SavedFoodTable();
        UriModel uriModel = new UriModel();
        List<SingleRootObject> newuriModel = new List<SingleRootObject>();
        private int foodID;

        public RecipeDetailSaved(List<SingleRootObject> tempuriModel)
        {
            InitializeComponent();

            newuriModel = tempuriModel; //Made this newuriModel can be used outside this class to refresh the page (To refresh the Save/Delete button)

            foreach (var item in tempuriModel)
            {
                uriModel.Calories = item.Calories;
                uriModel.Cautions = item.Cautions;
                uriModel.DietLabels = item.DietLabels;
                uriModel.Digest = item.Digest;
                uriModel.HealthLabels = item.HealthLabels;
                uriModel.Image = item.Image;
                uriModel.IngredientLines = item.IngredientLines;
                uriModel.Ingredients = item.Ingredients;
                uriModel.Label = item.Label;
                uriModel.ShareAs = item.ShareAs;
                uriModel.Source = item.Source;
                uriModel.TotalDaily = item.TotalDaily;
                uriModel.TotalNutrients = item.TotalNutrients;
                uriModel.TotalTime = item.TotalTime;
                uriModel.TotalWeight = item.TotalWeight;
                uriModel.Uri = item.Uri;
                uriModel.Url = item.Url;
                uriModel.Yield = item.Yield;
            }
           

            saveFood.Uri = uriModel.Uri;//apiuri;
            saveFood.calories = uriModel.Calories;
            saveFood.foodName = uriModel.Label;
            saveFood.imageUri = uriModel.Image;
            saveFood.Uid = LoginPage.userInfo.UserId;

            getFood();

            foodName.Text = uriModel.Label;
            foodImage.Source = new UriImageSource()
            {
                Uri = new Uri(uriModel.Image)
            };

            totCalories.Text = "Calories " + uriModel.Calories.ToString("F");
            totCarbs.Text = "Carbs " + uriModel.TotalNutrients.Chocdf.Quantity.ToString("F") + uriModel.TotalNutrients.Chocdf.Unit.ToString();

            totFat.Text = "Fat " + uriModel.TotalNutrients.Fat.Quantity.ToString("F") + uriModel.TotalNutrients.Fat.Unit.ToString();
            totProtein.Text = "Protein " + uriModel.TotalNutrients.Procnt.Quantity.ToString("F") + uriModel.TotalNutrients.Procnt.Unit.ToString();

            totSugar.Text = "Sugar " + uriModel.TotalNutrients.Sugar.Quantity.ToString("F") + uriModel.TotalNutrients.Sugar.Unit.ToString();
            totFiber.Text = "Fiber " + uriModel.TotalNutrients.Fibtg.Quantity.ToString("F") + uriModel.TotalNutrients.Fibtg.Unit.ToString();

            totIngredients.Text = "Ingredients " + uriModel.Ingredients.Count().ToString();
            time.Text = "Time " + uriModel.TotalTime.ToString();

            //time.Text = ingredLines[0].ToString();
            lstIngredLines.ItemsSource = uriModel.Ingredients;

            try
            {
                lblFAT.Text = uriModel.TotalNutrients.Fat.Label + " " + uriModel.TotalNutrients.Fat.Quantity.ToString("F") + uriModel.TotalNutrients.Fat.Unit;
                lblFASAT.Text = uriModel.TotalNutrients.Fasat.Label + " " + uriModel.TotalNutrients.Fasat.Quantity.ToString("F") + uriModel.TotalNutrients.Fasat.Unit;
                lblFATRN.Text = uriModel.TotalNutrients.Fatrn.Label + " " + uriModel.TotalNutrients.Fatrn.Quantity.ToString("F") + uriModel.TotalNutrients.Fatrn.Unit;
                lblFAMS.Text = uriModel.TotalNutrients.Fams.Label + " " + uriModel.TotalNutrients.Fams.Quantity.ToString("F") + uriModel.TotalNutrients.Fams.Unit;
                lblFAPU.Text = uriModel.TotalNutrients.Fapu.Label + " " + uriModel.TotalNutrients.Fapu.Quantity.ToString("F") + uriModel.TotalNutrients.Fapu.Unit;
                lblCHOCDF.Text = uriModel.TotalNutrients.Chocdf.Label + " " + uriModel.TotalNutrients.Chocdf.Quantity.ToString("F") + uriModel.TotalNutrients.Chocdf.Unit;
                lblFIBTG.Text = uriModel.TotalNutrients.Fibtg.Label + " " + uriModel.TotalNutrients.Fibtg.Quantity.ToString("F") + uriModel.TotalNutrients.Fibtg.Unit;
                lblSUGAR.Text = uriModel.TotalNutrients.Sugar.Label + " " + uriModel.TotalNutrients.Sugar.Quantity.ToString("F") + uriModel.TotalNutrients.Sugar.Unit;
                lblPROCNT.Text = uriModel.TotalNutrients.Procnt.Label + " " + uriModel.TotalNutrients.Procnt.Quantity.ToString("F") + uriModel.TotalNutrients.Procnt.Unit;
                lblCHOLE.Text = uriModel.TotalNutrients.Chole.Label + " " + uriModel.TotalNutrients.Chole.Quantity.ToString("F") + uriModel.TotalNutrients.Chole.Unit;
                lblNA.Text = uriModel.TotalNutrients.Na.Label + " " + uriModel.TotalNutrients.Na.Quantity.ToString("F") + uriModel.TotalNutrients.Na.Unit;
                lblCA.Text = uriModel.TotalNutrients.Ca.Label + " " + uriModel.TotalNutrients.Ca.Quantity.ToString("F") + uriModel.TotalNutrients.Ca.Unit;
                lblMG.Text = uriModel.TotalNutrients.Mg.Label + " " + uriModel.TotalNutrients.Mg.Quantity.ToString("F") + uriModel.TotalNutrients.Mg.Unit;
                lblK.Text = uriModel.TotalNutrients.K.Label + " " + uriModel.TotalNutrients.K.Quantity.ToString("F") + uriModel.TotalNutrients.K.Unit;
                lblFE.Text = uriModel.TotalNutrients.Fe.Label + " " + uriModel.TotalNutrients.Fe.Quantity.ToString("F") + uriModel.TotalNutrients.Fe.Unit;
                lblZN.Text = uriModel.TotalNutrients.Zn.Label + " " + uriModel.TotalNutrients.Zn.Quantity.ToString("F") + uriModel.TotalNutrients.Zn.Unit;
                lblP.Text = uriModel.TotalNutrients.P.Label + " " + uriModel.TotalNutrients.P.Quantity.ToString("F") + uriModel.TotalNutrients.P.Unit;
                lblVitaRae.Text = uriModel.TotalNutrients.VitaRae.Label + " " + uriModel.TotalNutrients.VitaRae.Quantity.ToString("F") + uriModel.TotalNutrients.VitaRae.Unit;
                lblVITC.Text = uriModel.TotalNutrients.Vitc.Label + " " + uriModel.TotalNutrients.Vitc.Quantity.ToString("F") + uriModel.TotalNutrients.Vitc.Unit;
                lblTHIA.Text = uriModel.TotalNutrients.Thia.Label + " " + uriModel.TotalNutrients.Thia.Quantity.ToString("F") + uriModel.TotalNutrients.Thia.Unit;
                lblRIBF.Text = uriModel.TotalNutrients.Ribf.Label + " " + uriModel.TotalNutrients.Ribf.Quantity.ToString("F") + uriModel.TotalNutrients.Ribf.Unit;
                lblNIA.Text = uriModel.TotalNutrients.Nia.Label + " " + uriModel.TotalNutrients.Nia.Quantity.ToString("F") + uriModel.TotalNutrients.Nia.Unit;
                lblVITB6A.Text = uriModel.TotalNutrients.Vitb6A.Label + " " + uriModel.TotalNutrients.Vitb6A.Quantity.ToString("F") + uriModel.TotalNutrients.Vitb6A.Unit;
                lblFOLDFE.Text = uriModel.TotalNutrients.Foldfe.Label + " " + uriModel.TotalNutrients.Foldfe.Quantity.ToString("F") + uriModel.TotalNutrients.Foldfe.Unit;
                lblFOLFD.Text = uriModel.TotalNutrients.Foldfe.Label + " " + uriModel.TotalNutrients.Foldfe.Quantity.ToString("F") + uriModel.TotalNutrients.Foldfe.Unit;
                lblVITB12.Text = uriModel.TotalNutrients.Vitb12.Label + " " + uriModel.TotalNutrients.Vitb12.Quantity.ToString("F") + uriModel.TotalNutrients.Vitb12.Unit;
                lblVITD.Text = uriModel.TotalNutrients.Vitd.Label + " " + uriModel.TotalNutrients.Vitd.Quantity.ToString("F") + uriModel.TotalNutrients.Vitd.Unit;
                lblTOCPHA.Text = uriModel.TotalNutrients.Tocpha.Label + " " + uriModel.TotalNutrients.Tocpha.Quantity.ToString("F") + uriModel.TotalNutrients.Tocpha.Unit;
                lblWATER.Text = uriModel.TotalNutrients.Water.Label + " " + uriModel.TotalNutrients.Water.Quantity.ToString("F") + uriModel.TotalNutrients.Water.Unit;
            }
            catch (Exception)
            {


            }




            foodSource.Text = "Recipe by " + uriModel.Source;
        }

        private async void getFood()
        {
            ToolbarItem removeFood = new ToolbarItem
            {
                IconImageSource = ImageSource.FromFile("heartDark.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            removeFood.Clicked += RemoveFood_Clicked;

            ToolbarItem addFood = new ToolbarItem
            {
                IconImageSource = ImageSource.FromFile("emptyheartDark.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            addFood.Clicked += AddFood_Clicked;

            var getFood = await apiProxy.GetSavedFood(saveFood.Uid);
            var allFood = getFood.Where(e => e.Uri == saveFood.Uri).ToList();

            if (allFood.Count() > 0) //check if this food id exists in database, if it exists show button to remove it
            {
                this.ToolbarItems.Add(removeFood); //add button if pressed will remove from database
            }
            else //if it doesnt exist, show button to add it
            {
                this.ToolbarItems.Add(addFood); //add button if pressed will add to database
            }
        }

        private async void AddFood_Clicked(object sender, EventArgs e)
        {
            var savedfoood = await apiProxy.PostSavedFood(saveFood);
            if (savedfoood == null)
            {
                await DisplayAlert("Error", "Food cannot be saved", "Try Again");
            }
            else
            {
                await DisplayAlert("Success", "Food is saved", "Ok");
                var page = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new RecipeDetailSaved(newuriModel)); //Loading the same page and deleting the 1 before to refresh
                Navigation.RemovePage(page);
            }
        }

        private async void RemoveFood_Clicked(object sender, EventArgs e)
        {
            var getFood = await apiProxy.GetSavedFood(LoginPage.userInfo.UserId);
            foreach (var item in getFood)
            {
                foodID = item.SavedFoodId;
            }
            var savedfoood = await apiProxy.DeleteSavedFood(foodID);
            if (savedfoood == false)
            {
                await DisplayAlert("Error", "Food cannot be deleted", "Try Again");
            }
            else
            {
                await DisplayAlert("Success", "Food successfuly deleted", "Ok");
                var page = Navigation.NavigationStack.LastOrDefault();
                await Navigation.PushAsync(new RecipeDetailSaved(newuriModel)); //Loading the same page and deleting the 1 before to refresh
                Navigation.RemovePage(page);
            }
        }
    }

}