﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FRFoodRecipes.API.Models
{
    public class SavedFoodTable //Model for saved food, from public api to private database
    {
        public int SavedFoodId { get; set; }
        public string Uri { get; set; }
        public string foodName { get; set; }
        public double calories { get; set; }
        public string imageUri { get; set; }
        public int Uid { get; set; }
    }
}
