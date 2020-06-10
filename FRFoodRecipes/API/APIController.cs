using FRFoodRecipes.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static FRFoodRecipes.API.RecipesAPI;

namespace FRFoodRecipes.API
{
    public class APIController
    {
        //public APIModel apiModel = new APIModel();
        public ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>();

        public ObservableCollection<List<SingleRootObject>> tempmodel = new ObservableCollection< List < SingleRootObject >> ();

        public ObservableCollection<APIModel> GetRecipeResults(RootObject foodDatabase)
        {
            apiModel.Clear(); //Clears the APIModel everytime Controller is called
            foreach (var item in foodDatabase.hits)
            {
                apiModel.Add(new APIModel { uri = item.recipe.uri, foodName = item.recipe.label, imageUri = item.recipe.image, source = item.recipe.source, sourceUrl = item.recipe.url, shareAs = item.recipe.shareAs, yield = item.recipe.yield, dietLabels = item.recipe.dietLabels, healthLabels = item.recipe.dietLabels, cautions = item.recipe.cautions, ingredientLines = item.recipe.ingredientLines, ingredients = item.recipe.ingredients, calories = item.recipe.calories, totalWeight = item.recipe.totalWeight, totalTime = item.recipe.totalTime, totalNutrients = item.recipe.totalNutrients, totalDaily = item.recipe.totalDaily, digest = item.recipe.digest });
            }

            return apiModel; //Gets Name and other data, then returns.
        }

        public ObservableCollection<List<SingleRootObject>> GetSingleRecipeByURI(List<SingleRootObject> foodDatabase)
        {
            tempmodel.Clear(); //Clears the APIModel everytime Controller is called

            tempmodel.Add(foodDatabase);

            return tempmodel; //Gets Name and other data, then returns.
        }

    }
}
