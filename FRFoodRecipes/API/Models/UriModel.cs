using System;
using System.Collections.Generic;
using System.Text;

namespace FRFoodRecipes.API.Models
{
    public class UriModel //UriModel class for when getting the URI back from private database
    {
        public string Uri { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string ShareAs { get; set; }
        public long Yield { get; set; }
        public List<string> DietLabels { get; set; }
        public List<string> HealthLabels { get; set; }
        public List<string> Cautions { get; set; }
        public List<string> IngredientLines { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double Calories { get; set; }
        public double TotalWeight { get; set; }
        public long TotalTime { get; set; }
        public TotalNutrients TotalNutrients { get; set; }
        public TotalDaily TotalDaily { get; set; }
        public List<Digest> Digest { get; set; }
    }
}
