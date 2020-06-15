using FRFoodRecipes.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FRFoodRecipes.API
{
    public class ApiProxy
    {
        public async Task<UserTable> GetUser(string userName, string pwrd) //API Call, getting the user info if the username and password match through the api to the database
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"https://foodapi27036778.azurewebsites.net/user/{userName}&{pwrd}");
            var data = await response.Content.ReadAsAsync<UserTable>();
            return data;
        }

        public async Task<UserTable> NewUser(UserTable user) //Sending a Usermodel class full of new user info for an account to be created
        {
            var http = new HttpClient();
            var response = await http.PostAsJsonAsync($"https://foodapi27036778.azurewebsites.net/user", user);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserTable>();
                return data;
            }
            else
                return null;
        }

        public async Task<UserTable> UpdateUser(UserTable user) //Sending an updated Model class of a user to be updated
        {
            var http = new HttpClient();
            var response = await http.PostAsJsonAsync($"https://foodapi27036778.azurewebsites.net/user/update", user);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<UserTable>();
                return data;
            }
            else
                return null;
        }

        public async Task<List<SavedFoodTable>> GetSavedFood(int uid) //Getting all the saved food that is privately stored from the users id
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"https://foodapi27036778.azurewebsites.net/SavedFood/{uid}");
            var data = await response.Content.ReadAsAsync<List<SavedFoodTable>>();
            return data;
        }

        public async Task<SavedFoodTable> PostSavedFood(SavedFoodTable savedFood) //Using the model class for SavedFoodTable, certain things are saved from the public api to the private database api
        {
            var http = new HttpClient();
            var response = await http.PostAsJsonAsync($"https://foodapi27036778.azurewebsites.net/SavedFood", savedFood);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<SavedFoodTable>();
                return data;
            }
            else
                return null;
        }

        public async Task<bool> DeleteSavedFood(int foodId) //Getting the foodID for a savedfood from a private database to delete it
        {
            var http = new HttpClient();
            var response = await http.DeleteAsync($"https://foodapi27036778.azurewebsites.net/SavedFood/{foodId}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
                return false;
        }

    }
}
