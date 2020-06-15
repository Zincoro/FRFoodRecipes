using System;
using System.Collections.Generic;
using System.Text;

namespace FRFoodRecipes.API.Models
{
    public class UserTable //User Model Class for Signing in/Signing up 
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Pword { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
    }
}
