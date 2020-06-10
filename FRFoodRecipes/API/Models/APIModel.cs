using System;
using System.Collections.Generic;
using System.Text;
using static FRFoodRecipes.API.RecipesAPI;

namespace FRFoodRecipes.API.Models
{
    public class APIModel
    {
        public string uri { get; set; }
        public string foodName { get; set; }
        public string imageUri { get; set; }
        public string source { get; set; }
        public string sourceUrl { get; set; }
        public string shareAs { get; set; }
        public int yield { get; set; }
        public List<string> dietLabels { get; set; }
        public List<string> healthLabels { get; set; }
        public List<string> cautions { get; set; }
        public List<string> ingredientLines { get; set; }
        public List<RecipesAPI.Ingredient> ingredients { get; set; }
        public double calories { get; set; }
        public double totalWeight { get; set; }
        public int totalTime { get; set; }
        public RecipesAPI.TotalNutrients totalNutrients { get; set; }
        public RecipesAPI.TotalDaily totalDaily { get; set; }
        public List<RecipesAPI.Digest> digest { get; set; }
    }
}
