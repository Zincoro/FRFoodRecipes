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
        public ObservableCollection<APIModel> apiModel = new ObservableCollection<APIModel>(); //Make a List of the APIModel

        public ObservableCollection<List<SingleRootObject>> tempmodel = new ObservableCollection< List < SingleRootObject >> ();

        public ObservableCollection<APIModel> GetRecipeResults(RootObject foodDatabase) //After the food has been searched, the results are put into the apiModel and then returned for it to be used
        {
            apiModel.Clear(); //Clears the APIModel everytime Controller is called
            foreach (var item in foodDatabase.hits) //Each item in fooddatabase.hit put into the apimodel
            {
                apiModel.Add(new APIModel { uri = item.recipe.uri, foodName = item.recipe.label, imageUri = item.recipe.image, source = item.recipe.source, sourceUrl = item.recipe.url, shareAs = item.recipe.shareAs, yield = item.recipe.yield, dietLabels = item.recipe.dietLabels, healthLabels = item.recipe.dietLabels, cautions = item.recipe.cautions, ingredientLines = item.recipe.ingredientLines, ingredients = item.recipe.ingredients, calories = item.recipe.calories, totalWeight = item.recipe.totalWeight, totalTime = item.recipe.totalTime, totalNutrients = item.recipe.totalNutrients, totalDaily = item.recipe.totalDaily, digest = item.recipe.digest });
            }
            return apiModel; //Gets Name and other data, then returns.
        }

        public ObservableCollection<List<SingleRootObject>> GetSingleRecipeByURI(List<SingleRootObject> foodDatabase) //For getting a selected result for a food that has been saved by the user
        {
            tempmodel.Clear(); //Clears the APIModel everytime Controller is called

            tempmodel.Add(foodDatabase);
            //foreach (var item in foodDatabase)
            //{
            //    tempmodel.Add(new UriModel { Calories = item.Calories, DietLabels = item.DietLabels, Digest = item.Digest, HealthLabels = item.HealthLabels, Image = item.Image, IngredientLines = item.IngredientLines, Ingredients = item.Ingredients, Label = item.Label, ShareAs = item.ShareAs, Source = item.Source, TotalDaily = item.TotalDaily, TotalNutrients = item.TotalNutrients, TotalTime = item.TotalTime, TotalWeight = item.TotalWeight, Uri = item.Uri, Url = item.Url, Yield = item.Yield });
            //}

            return tempmodel; //Gets Name and other data, then returns.
        }

    }
}
