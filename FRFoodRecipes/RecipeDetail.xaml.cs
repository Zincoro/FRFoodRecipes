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
    public partial class RecipeDetail : TabbedPage
    {
        ApiProxy apiProxy = new ApiProxy();
        SavedFoodTable saveFood = new SavedFoodTable();
        APIModel newPublicFood = new APIModel();
        private int foodID;

        //public RecipeDetail(string apiuri, string fName, string imgUri, string srce, string srceUrl, string share, int yields, List<string> dietLbls, List<string> healthLbls, List<string> caution, List<string> ingredLines, List<Ingredient> ingrdients, double cals, double totWeight, int totTime, TotalNutrients publicFood.totalNutrients, TotalDaily totDaily, List<Digest> digests)
        public RecipeDetail(APIModel publicFood)
        {
            InitializeComponent();

            newPublicFood = publicFood; //Made this newPublicFood can be used outside this class to refresh the page (To refresh the Save/Delete button)

            saveFood.Uri = publicFood.uri;//apiuri;
            saveFood.calories = publicFood.calories;
            saveFood.foodName = publicFood.foodName;
            saveFood.imageUri = publicFood.imageUri;
            saveFood.Uid = LoginPage.userInfo.UserId;

            getFood();

            foodName.Text = publicFood.foodName;//fName;
            foodImage.Source = new UriImageSource()
            {
                Uri = new Uri(publicFood.imageUri)
            };
            totCalories.Text = "Calories " + publicFood.calories.ToString("F");
            totCarbs.Text = "Carbs " + publicFood.totalNutrients.CHOCDF.quantity.ToString("F") + publicFood.totalNutrients.CHOCDF.unit.ToString();

            totFat.Text = "Fat " + publicFood.totalNutrients.FAT.quantity.ToString("F") + publicFood.totalNutrients.FAT.unit.ToString();
            totProtein.Text = "Protein " + publicFood.totalNutrients.PROCNT.quantity.ToString("F") + publicFood.totalNutrients.PROCNT.unit.ToString();

            totSugar.Text = "Sugar " + publicFood.totalNutrients.SUGAR.quantity.ToString("F") + publicFood.totalNutrients.SUGAR.unit.ToString();
            totFiber.Text = "Fiber " + publicFood.totalNutrients.FIBTG.quantity.ToString("F") + publicFood.totalNutrients.FIBTG.unit.ToString();

            totIngredients.Text = "Ingredients " + publicFood.ingredients.Count().ToString();
            time.Text = "Time " + publicFood.totalTime.ToString();

            //time.Text = ingredLines[0].ToString();

            lstIngredLines.ItemsSource = publicFood.ingredients;

            try
            {
                lblFAT.Text = publicFood.totalNutrients.FAT.label + " " + publicFood.totalNutrients.FAT.quantity.ToString("F") + publicFood.totalNutrients.FAT.unit;
                lblFASAT.Text = publicFood.totalNutrients.FASAT.label + " " + publicFood.totalNutrients.FASAT.quantity.ToString("F") + publicFood.totalNutrients.FASAT.unit;
                lblFATRN.Text = publicFood.totalNutrients.FATRN.label + " " + publicFood.totalNutrients.FATRN.quantity.ToString("F") + publicFood.totalNutrients.FATRN.unit;
                lblFAMS.Text = publicFood.totalNutrients.FAMS.label + " " + publicFood.totalNutrients.FAMS.quantity.ToString("F") + publicFood.totalNutrients.FAMS.unit;
                lblFAPU.Text = publicFood.totalNutrients.FAPU.label + " " + publicFood.totalNutrients.FAPU.quantity.ToString("F") + publicFood.totalNutrients.FAPU.unit;
                lblCHOCDF.Text = publicFood.totalNutrients.CHOCDF.label + " " + publicFood.totalNutrients.CHOCDF.quantity.ToString("F") + publicFood.totalNutrients.CHOCDF.unit;
                lblFIBTG.Text = publicFood.totalNutrients.FIBTG.label + " " + publicFood.totalNutrients.FIBTG.quantity.ToString("F") + publicFood.totalNutrients.FIBTG.unit;
                lblSUGAR.Text = publicFood.totalNutrients.SUGAR.label + " " + publicFood.totalNutrients.SUGAR.quantity.ToString("F") + publicFood.totalNutrients.SUGAR.unit;
                lblPROCNT.Text = publicFood.totalNutrients.PROCNT.label + " " + publicFood.totalNutrients.PROCNT.quantity.ToString("F") + publicFood.totalNutrients.PROCNT.unit;
                lblCHOLE.Text = publicFood.totalNutrients.CHOLE.label + " " + publicFood.totalNutrients.CHOLE.quantity.ToString("F") + publicFood.totalNutrients.CHOLE.unit;
                lblNA.Text = publicFood.totalNutrients.NA.label + " " + publicFood.totalNutrients.NA.quantity.ToString("F") + publicFood.totalNutrients.NA.unit;
                lblCA.Text = publicFood.totalNutrients.CA.label + " " + publicFood.totalNutrients.CA.quantity.ToString("F") + publicFood.totalNutrients.CA.unit;
                lblMG.Text = publicFood.totalNutrients.MG.label + " " + publicFood.totalNutrients.MG.quantity.ToString("F") + publicFood.totalNutrients.MG.unit;
                lblK.Text = publicFood.totalNutrients.K.label + " " + publicFood.totalNutrients.K.quantity.ToString("F") + publicFood.totalNutrients.K.unit;
                lblFE.Text = publicFood.totalNutrients.FE.label + " " + publicFood.totalNutrients.FE.quantity.ToString("F") + publicFood.totalNutrients.FE.unit;
                lblZN.Text = publicFood.totalNutrients.ZN.label + " " + publicFood.totalNutrients.ZN.quantity.ToString("F") + publicFood.totalNutrients.ZN.unit;
                lblP.Text = publicFood.totalNutrients.P.label + " " + publicFood.totalNutrients.P.quantity.ToString("F") + publicFood.totalNutrients.P.unit;
                lblVitaRae.Text = publicFood.totalNutrients.VITA_RAE.label + " " + publicFood.totalNutrients.VITA_RAE.quantity.ToString("F") + publicFood.totalNutrients.VITA_RAE.unit;
                lblVITC.Text = publicFood.totalNutrients.VITC.label + " " + publicFood.totalNutrients.VITC.quantity.ToString("F") + publicFood.totalNutrients.VITC.unit;
                lblTHIA.Text = publicFood.totalNutrients.THIA.label + " " + publicFood.totalNutrients.THIA.quantity.ToString("F") + publicFood.totalNutrients.THIA.unit;
                lblRIBF.Text = publicFood.totalNutrients.RIBF.label + " " + publicFood.totalNutrients.RIBF.quantity.ToString("F") + publicFood.totalNutrients.RIBF.unit;
                lblNIA.Text = publicFood.totalNutrients.NIA.label + " " + publicFood.totalNutrients.NIA.quantity.ToString("F") + publicFood.totalNutrients.NIA.unit;
                lblVITB6A.Text = publicFood.totalNutrients.VITB6A.label + " " + publicFood.totalNutrients.VITB6A.quantity.ToString("F") + publicFood.totalNutrients.VITB6A.unit;
                lblFOLDFE.Text = publicFood.totalNutrients.FOLDFE.label + " " + publicFood.totalNutrients.FOLDFE.quantity.ToString("F") + publicFood.totalNutrients.FOLDFE.unit;
                lblFOLFD.Text = publicFood.totalNutrients.FOLFD.label + " " + publicFood.totalNutrients.FOLFD.quantity.ToString("F") + publicFood.totalNutrients.FOLFD.unit;
                lblVITB12.Text = publicFood.totalNutrients.VITB12.label + " " + publicFood.totalNutrients.VITB12.quantity.ToString("F") + publicFood.totalNutrients.VITB12.unit;
                lblVITD.Text = publicFood.totalNutrients.VITD.label + " " + publicFood.totalNutrients.VITD.quantity.ToString("F") + publicFood.totalNutrients.VITD.unit;
                lblTOCPHA.Text = publicFood.totalNutrients.TOCPHA.label + " " + publicFood.totalNutrients.TOCPHA.quantity.ToString("F") + publicFood.totalNutrients.TOCPHA.unit;
                lblWATER.Text = publicFood.totalNutrients.WATER.label + " " + publicFood.totalNutrients.WATER.quantity.ToString("F") + publicFood.totalNutrients.WATER.unit;
            }
            catch (Exception)
            {

                
            }




            foodSource.Text = "Recipe by " + publicFood.source;
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
                await Navigation.PushAsync(new RecipeDetail(newPublicFood)); //Loading the same page and deleting the 1 before to refresh
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
                await Navigation.PushAsync(new RecipeDetail(newPublicFood)); //Loading the same page and deleting the 1 before to refresh
                Navigation.RemovePage(page);
            }
        }
    }
}