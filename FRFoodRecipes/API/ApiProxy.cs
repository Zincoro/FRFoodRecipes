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
        public async Task<UserTable> GetUser(string userName, string pwrd)
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"https://foodapi27036778.azurewebsites.net/user/{userName}&{pwrd}");
            var data = await response.Content.ReadAsAsync<UserTable>();
            return data;
        }

        public async Task<UserTable> NewUser(UserTable user)
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

        public async Task<UserTable> UpdateUser(UserTable user)
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

        public async Task<List<SavedFoodTable>> GetSavedFood(int uid)
        {
            var http = new HttpClient();
            var response = await http.GetAsync($"https://foodapi27036778.azurewebsites.net/SavedFood/{uid}");
            var data = await response.Content.ReadAsAsync<List<SavedFoodTable>>();
            return data;
        }

        public async Task<SavedFoodTable> PostSavedFood(SavedFoodTable savedFood)
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

        public async Task<bool> DeleteSavedFood(int foodId)
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
