using FRFoodRecipes.Maintenance;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class FilterPopup : PopupPage
    {

        private string fileNameFrom = "fromCaloriesFilter.txt";
        private string fileNameTo = "toCaloriesFilter.txt";
        private string fileNameIngreds = "uptoIngredsFilter.txt";
        private string fileNameDiet = "dietFilter.txt";
        private string fileNameHealth = "healthFilter.txt";
        private string storage = "";
        private string dietStorage = "";
        private string healthStorage = "";

        public FilterPopup()
        {
            InitializeComponent();

            fillTexts();
        }

        public async void fillTexts()
        {
            btnClearFilters.Text += " Clear Filters";

            string fromCalories = "0";
            string toCalories = "800";
            string uptoIngr = "20";

            txtCalorieFrom.Text = fromCalories;
            txtCalorieTo.Text = toCalories;
            txtIngredsUpto.Text = uptoIngr;

            var fromCal = await LocalStorage.ReadTextFileAsync(fileNameFrom);
            var toCal = await LocalStorage.ReadTextFileAsync(fileNameTo);
            var uptoIngreds = await LocalStorage.ReadTextFileAsync(fileNameIngreds);
            var diet = await LocalStorage.ReadTextFileAsync(fileNameDiet);
            var health = await LocalStorage.ReadTextFileAsync(fileNameHealth);

            if (!String.IsNullOrEmpty(fromCal))
            {
                txtCalorieFrom.Text = fromCal;
            }
            if (!String.IsNullOrEmpty(toCal))
            {
                txtCalorieTo.Text = toCal;
            }
            if (!String.IsNullOrEmpty(uptoIngreds))
            {
                txtIngredsUpto.Text = uptoIngreds;
            }

            //------------------------------------Diet-------------------------------
            if (diet.Contains("diet=balanced&"))
            {
                chkBalanced.IsChecked = true;
            }
            else if (diet.Contains("diet=high-protein&"))
            {
                chkHighProtein.IsChecked = true;
            }
            else if (diet.Contains("diet=low-fat&"))
            {
                chkLowFat.IsChecked = true;
            }
            else if (diet.Contains("diet=high-fiber&"))
            {
                chkHighFiber.IsChecked = true;
            }
            else if (diet.Contains("diet=low-carb&"))
            {
                chkLowCarb.IsChecked = true;
            }
            else if (diet.Contains("diet=low-sodium&"))
            {
                chkLowSodium.IsChecked = true;
            }

            //------------------------------------Health-------------------------------
            if (health.Contains("health=vegan&"))
            {
                chkVegan.IsChecked = true;
            }
            if (health.Contains("health=paleo&"))
            {
                chkPaleo.IsChecked = true;
            }
            if (health.Contains("health=gluten-free&"))
            {
                chkGluten.IsChecked = true;
            }
            if (health.Contains("health=vegetarian&"))
            {
                chkVegetarian.IsChecked = true;
            }
            if (health.Contains("health=low-sugar&"))
            {
                chkLowSugar.IsChecked = true;
            }
            if (health.Contains("health=soy-free&"))
            {
                chkSoy.IsChecked = true;
            }
            if (health.Contains("health=alcohol-free&"))
            {
                chkAlcoholFree.IsChecked = true;
            }
            if (health.Contains("health=keto-friendly&"))
            {
                chkKeto.IsChecked = true;
            }
            if (health.Contains("health=shellfish-free&"))
            {
                chkShellfish.IsChecked = true;
            }
            if (health.Contains("health=dairy-free&"))
            {
                chkDairy.IsChecked = true;
            }
            if (health.Contains("health=wheat-free&"))
            {
                chkWheat.IsChecked = true;
            }
            if (health.Contains("health=tree-nut-free&"))
            {
                chkTreeNuts.IsChecked = true;
            }
            if (health.Contains("health=egg-free&"))
            {
                chkEggs.IsChecked = true;
            }
            if (health.Contains("health=fish-free&"))
            {
                chkFish.IsChecked = true;
            }
            if (health.Contains("health=peanut-free&"))
            {
                chkPeanuts.IsChecked = true;
            }
        }

        private void btnClearFilters_Clicked(object sender, EventArgs e)
        {
            ClearDiet();
            ClearAllergies();
            txtCalorieFrom.Text = "0";
            txtCalorieTo.Text = "800";
            txtIngredsUpto.Text = "20";
        }

        private void ClearDiet()
        {
            chkVegetarian.IsChecked = false;
            chkHighFiber.IsChecked = false;
            chkLowFat.IsChecked = false;
            chkAlcoholFree.IsChecked = false;

            chkVegan.IsChecked = false;
            chkHighProtein.IsChecked = false;
            chkLowSodium.IsChecked = false;
            chkBalanced.IsChecked = false;

            chkPaleo.IsChecked = false;
            chkLowCarb.IsChecked = false;
            chkLowSugar.IsChecked = false;
        }

        private void ClearAllergies()
        {
            chkGluten.IsChecked = false;
            chkSoy.IsChecked = false;
            chkShellfish.IsChecked = false;

            chkDairy.IsChecked = false;
            chkWheat.IsChecked = false;
            chkTreeNuts.IsChecked = false;

            chkEggs.IsChecked = false;
            chkFish.IsChecked = false;
            chkPeanuts.IsChecked = false;
        }

        private async void btnDone_Clicked(object sender, EventArgs e)
        {
            storage = txtCalorieFrom.Text;
            await LocalStorage.WriteTextFileAsync(fileNameFrom, storage);

            storage = txtCalorieTo.Text;
            await LocalStorage.WriteTextFileAsync(fileNameTo, storage);

            storage = txtIngredsUpto.Text;
            await LocalStorage.WriteTextFileAsync(fileNameIngreds, storage);

            //-----------------------------Diet------------------------------
            if (chkBalanced.IsChecked)
            {
                dietStorage = "diet=balanced&";
            }
            else if (chkHighFiber.IsChecked)
            {
                dietStorage = "diet=high-fiber&";
            }
            else if (chkHighProtein.IsChecked)
            {
                dietStorage = "diet=high-protein&";
            }
            else if (chkLowCarb.IsChecked)
            {
                dietStorage = "diet=low-carb&";
            }
            else if (chkLowFat.IsChecked)
            {
                dietStorage = "diet=low-fat&";
            }
            else if (chkLowSodium.IsChecked)
            {
                dietStorage = "diet=low-sodium&";
            }
            else
            {
                dietStorage = "";
            }
            await LocalStorage.WriteTextFileAsync(fileNameDiet, dietStorage);

            //-----------------------------Health-------------------------------
            healthStorage = "";
            if (chkVegan.IsChecked)
            {
                healthStorage += "health=vegan&";
            }
            if (chkPaleo.IsChecked)
            {
                healthStorage += "health=paleo&";
            }
            if (chkGluten.IsChecked)
            {
                healthStorage += "health=gluten-free&";
            }
            if (chkVegetarian.IsChecked)
            {
                healthStorage += "health=vegetarian&";
            }
            if (chkLowSugar.IsChecked)
            {
                healthStorage += "health=low-sugar&";
            }
            if (chkSoy.IsChecked)
            {
                healthStorage += "health=soy-free&";
            }
            if (chkAlcoholFree.IsChecked)
            {
                healthStorage += "health=alcohol-free&";
            }
            if (chkKeto.IsChecked)
            {
                healthStorage += "health=keto-friendly&";
            }
            if (chkShellfish.IsChecked)
            {
                healthStorage += "health=shellfish-free&";
            }
            if (chkDairy.IsChecked)
            {
                healthStorage += "health=dairy-free&";
            }
            if (chkWheat.IsChecked)
            {
                healthStorage += "health=wheat-free&";
            }
            if (chkTreeNuts.IsChecked)
            {
                healthStorage += "health=tree-nut-free&";
            }
            if (chkEggs.IsChecked)
            {
                healthStorage += "health=egg-free&";
            }
            if (chkFish.IsChecked)
            {
                healthStorage += "health=fish-free&";
            }
            if (chkPeanuts.IsChecked)
            {
                healthStorage += "health=peanut-free&";
            }
            await LocalStorage.WriteTextFileAsync(fileNameHealth, healthStorage);
            _ = App.Current.MainPage.Navigation.PopAllPopupAsync();
        }

        private void chkBalanced_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkBalanced.IsChecked)
            {
                chkHighFiber.IsChecked = false;
                chkHighProtein.IsChecked = false;
                chkLowCarb.IsChecked = false;
                chkLowFat.IsChecked = false;
                chkLowSodium.IsChecked = false;
            }
        }

        private void chkHighFiber_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkHighFiber.IsChecked)
            {
                chkBalanced.IsChecked = false;
                chkHighProtein.IsChecked = false;
                chkLowCarb.IsChecked = false;
                chkLowFat.IsChecked = false;
                chkLowSodium.IsChecked = false;
            }
        }

        private void chkHighProtein_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkHighProtein.IsChecked)
            {
                chkBalanced.IsChecked = false;
                chkHighFiber.IsChecked = false;
                chkLowCarb.IsChecked = false;
                chkLowFat.IsChecked = false;
                chkLowSodium.IsChecked = false;
            }
        }

        private void chkLowCarb_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkLowCarb.IsChecked)
            {
                chkBalanced.IsChecked = false;
                chkHighFiber.IsChecked = false;
                chkHighProtein.IsChecked = false;
                chkLowFat.IsChecked = false;
                chkLowSodium.IsChecked = false;
            }
        }

        private void chkLowFat_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkLowFat.IsChecked)
            {
                chkBalanced.IsChecked = false;
                chkHighFiber.IsChecked = false;
                chkHighProtein.IsChecked = false;
                chkLowCarb.IsChecked = false;
                chkLowSodium.IsChecked = false;
            }
        }

        private void chkLowSodium_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkLowSodium.IsChecked)
            {
                chkBalanced.IsChecked = false;
                chkHighFiber.IsChecked = false;
                chkHighProtein.IsChecked = false;
                chkLowCarb.IsChecked = false;
                chkLowFat.IsChecked = false;
            }
        }
    }
}