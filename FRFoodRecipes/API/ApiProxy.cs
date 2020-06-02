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
            //var http = new HttpClient
            //{
            //    BaseAddress = new Uri("https://foodapi27036778.azurewebsites.net/")
            //};

            //HttpResponseMessage response = await http.GetAsync($"user/{userName}&{pwrd}");
            //if (response.IsSuccessStatusCode)
            //{
            //    var result = await response.Content.ReadAsStringAsync();
            //    var serializer = new DataContractJsonSerializer(typeof(UserTable));

            //    var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            //    var data = (UserTable)serializer.ReadObject(ms);
            //    return data;
            //}
            //else return new UserTable { Fname = response.ReasonPhrase, Lname = "" };

            var http = new HttpClient();
            var response = await http.GetAsync($"https://foodapi27036778.azurewebsites.net/user/{userName}&{pwrd}");
            var data = await response.Content.ReadAsAsync<UserTable>();
            return data;
        }
    }
}
