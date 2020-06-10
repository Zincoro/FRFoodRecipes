﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FRFoodRecipes.API.Models
{
    public class UriModel
    {
        public string Uri { get; set; }
        public string Label { get; set; }
        public string Image { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string ShareAs { get; set; }
        public long Yield { get; set; }
        public string[] DietLabels { get; set; }
        public string[] HealthLabels { get; set; }
        public string[] Cautions { get; set; }
        public string[] IngredientLines { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public double Calories { get; set; }
        public double TotalWeight { get; set; }
        public long TotalTime { get; set; }
        public TotalNutrients TotalNutrients { get; set; }
        public TotalDaily TotalDaily { get; set; }
        public Digest[] Digest { get; set; }
    }
}