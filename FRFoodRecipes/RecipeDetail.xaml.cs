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
        public RecipeDetail(string apiuri, string fName, string imgUri, string srce, string srceUrl, string share, int yields, List<string> dietLbls, List<string> healthLbls, List<string> caution, List<string> ingredLines, List<Ingredient> ingrdients, double cals, double totWeight, int totTime, TotalNutrients totNutrients, TotalDaily totDaily, List<Digest> digests)
        {
            InitializeComponent();
            foodName.Text = fName;
            foodImage.Source = new UriImageSource()
            {
                Uri = new Uri(imgUri)
            };
            totCalories.Text = "Calories " + cals.ToString("F");
            totCarbs.Text = "Carbs " + totNutrients.CHOCDF.quantity.ToString("F") + totNutrients.CHOCDF.unit.ToString();

            totFat.Text = "Fat " + totNutrients.FAT.quantity.ToString("F") + totNutrients.FAT.unit.ToString();
            totProtein.Text = "Protein " + totNutrients.PROCNT.quantity.ToString("F") + totNutrients.PROCNT.unit.ToString();

            totSugar.Text = "Sugar " + totNutrients.SUGAR.quantity.ToString("F") + totNutrients.SUGAR.unit.ToString();
            totFiber.Text = "Fiber " + totNutrients.FIBTG.quantity.ToString("F") + totNutrients.FIBTG.unit.ToString();

            totIngredients.Text = "Ingredients " + ingrdients.Count().ToString();
            time.Text = "Time " + totTime.ToString();

            //time.Text = ingredLines[0].ToString();

            lstIngredLines.ItemsSource = ingrdients;

            lblFAT.Text = totNutrients.FAT.label + " " + totNutrients.FAT.quantity.ToString("F") + totNutrients.FAT.unit;
            lblFASAT.Text = totNutrients.FASAT.label + " " + totNutrients.FASAT.quantity.ToString("F") + totNutrients.FASAT.unit;
            lblFATRN.Text = totNutrients.FATRN.label + " " + totNutrients.FATRN.quantity.ToString("F") + totNutrients.FATRN.unit;
            lblFAMS.Text = totNutrients.FAMS.label + " " + totNutrients.FAMS.quantity.ToString("F") + totNutrients.FAMS.unit;
            lblFAPU.Text = totNutrients.FAPU.label + " " + totNutrients.FAPU.quantity.ToString("F") + totNutrients.FAPU.unit;
            lblCHOCDF.Text = totNutrients.CHOCDF.label + " " + totNutrients.CHOCDF.quantity.ToString("F") + totNutrients.CHOCDF.unit;
            lblFIBTG.Text = totNutrients.FIBTG.label + " " + totNutrients.FIBTG.quantity.ToString("F") + totNutrients.FIBTG.unit;
            lblSUGAR.Text = totNutrients.SUGAR.label + " " + totNutrients.SUGAR.quantity.ToString("F") + totNutrients.SUGAR.unit;
            lblPROCNT.Text = totNutrients.PROCNT.label + " " + totNutrients.PROCNT.quantity.ToString("F") + totNutrients.PROCNT.unit;
            lblCHOLE.Text = totNutrients.CHOLE.label + " " + totNutrients.CHOLE.quantity.ToString("F") + totNutrients.CHOLE.unit;
            lblNA.Text = totNutrients.NA.label + " " + totNutrients.NA.quantity.ToString("F") + totNutrients.NA.unit;
            lblCA.Text = totNutrients.CA.label + " " + totNutrients.CA.quantity.ToString("F") + totNutrients.CA.unit;
            lblMG.Text = totNutrients.MG.label + " " + totNutrients.MG.quantity.ToString("F") + totNutrients.MG.unit;
            lblK.Text = totNutrients.K.label + " " + totNutrients.K.quantity.ToString("F") + totNutrients.K.unit;
            lblFE.Text = totNutrients.FE.label + " " + totNutrients.FE.quantity.ToString("F") + totNutrients.FE.unit;
            lblZN.Text = totNutrients.ZN.label + " " + totNutrients.ZN.quantity.ToString("F") + totNutrients.ZN.unit;
            lblP.Text = totNutrients.P.label + " " + totNutrients.P.quantity.ToString("F") + totNutrients.P.unit;
            lblVitaRae.Text = totNutrients.VITA_RAE.label + " " + totNutrients.VITA_RAE.quantity.ToString("F") + totNutrients.VITA_RAE.unit;
            lblVITC.Text = totNutrients.VITC.label + " " + totNutrients.VITC.quantity.ToString("F") + totNutrients.VITC.unit;
            lblTHIA.Text = totNutrients.THIA.label + " " + totNutrients.THIA.quantity.ToString("F") + totNutrients.THIA.unit;
            lblRIBF.Text = totNutrients.RIBF.label + " " + totNutrients.RIBF.quantity.ToString("F") + totNutrients.RIBF.unit;
            lblNIA.Text = totNutrients.NIA.label + " " + totNutrients.NIA.quantity.ToString("F") + totNutrients.NIA.unit;
            lblVITB6A.Text = totNutrients.VITB6A.label + " " + totNutrients.VITB6A.quantity.ToString("F") + totNutrients.VITB6A.unit;
            lblFOLDFE.Text = totNutrients.FOLDFE.label + " " + totNutrients.FOLDFE.quantity.ToString("F") + totNutrients.FOLDFE.unit;
            lblFOLFD.Text = totNutrients.FOLFD.label + " " + totNutrients.FOLFD.quantity.ToString("F") + totNutrients.FOLFD.unit;
            lblVITB12.Text = totNutrients.VITB12.label + " " + totNutrients.VITB12.quantity.ToString("F") + totNutrients.VITB12.unit;
            lblVITD.Text = totNutrients.VITD.label + " " + totNutrients.VITD.quantity.ToString("F") + totNutrients.VITD.unit;
            lblTOCPHA.Text = totNutrients.TOCPHA.label + " " + totNutrients.TOCPHA.quantity.ToString("F") + totNutrients.TOCPHA.unit;
            lblWATER.Text = totNutrients.WATER.label + " " + totNutrients.WATER.quantity.ToString("F") + totNutrients.WATER.unit;



            foodSource.Text = "Recipe by " + srce;
        }
    }
}