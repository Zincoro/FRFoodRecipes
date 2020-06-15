using FRFoodRecipes.API.Models;
using FRFoodRecipes.Maintenance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FRFoodRecipes.API
{
    public class RecipesAPI
    {
        public async static Task<RootObject> GetRecipe(string foodName)//Receiving a string of a foodname that the user has searched
        {
            string fileNameFrom = "fromCaloriesFilter.txt"; //For Local Storage, putting txt file names in a string to be easily accessible
            string fileNameTo = "toCaloriesFilter.txt";
            string fileNameIngreds = "uptoIngredsFilter.txt";
            string fileNameDiet = "dietFilter.txt";
            string fileNameHealth = "healthFilter.txt"; 

            string appID = "fdb4202d"; //App ID
            string appKey = "45e0fc9234e74461ff88774111579eae"; //App Key
            string fromCalories = await LocalStorage.ReadTextFileAsync(fileNameFrom); //Whatever is in the fileNameFrom(fromCaloriesFilter.txt) put it in a string "fromCalories"
            string toCalories = await LocalStorage.ReadTextFileAsync(fileNameTo);
            string maxIngreds = await LocalStorage.ReadTextFileAsync(fileNameIngreds);
            string diet = await LocalStorage.ReadTextFileAsync(fileNameDiet);
            string health = await LocalStorage.ReadTextFileAsync(fileNameHealth);

            var http = new HttpClient();
            var response = await http.GetAsync($"https://api.edamam.com/search?q={foodName}&app_id={appID}&app_key={appKey}&from=0&to=20&calories={fromCalories}-{toCalories}&ingr={maxIngreds}&{diet}{health}");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data; //using the string the user has searched and making an api call based on it
        }

        public async static Task<List<SingleRootObject>> GetRecipeFromUri(string Uri) //Receving a specific Uri for a specific food to get more of its results
        {
            string appID = "fdb4202d"; //App ID
            string appKey = "45e0fc9234e74461ff88774111579eae"; //App Key
            List<SingleRootObject> newData = new List<SingleRootObject>();

            var http = new HttpClient();
            string betterUri = Uri.Replace("#", "%23");  
            var response = await http.GetAsync($"https://api.edamam.com/search?r={betterUri}&app_key=45e0fc9234e74461ff88774111579eae&app_id=fdb4202d");
            var result = await response.Content.ReadAsStringAsync();
            var objData = JsonConvert.DeserializeObject<List<SingleRootObject>>(result);

            return objData; //using the specific uri to get more info of the specific food
        }

        [DataContract]
        public class Recipe //All model converted from json for public api
        {
            [DataMember]
            public string uri { get; set; }
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public string image { get; set; }
            [DataMember]
            public string source { get; set; }
            [DataMember]
            public string url { get; set; }
            [DataMember]
            public string shareAs { get; set; }
            [DataMember]
            public int yield { get; set; }
            [DataMember]
            public List<string> dietLabels { get; set; }
            [DataMember]
            public List<string> healthLabels { get; set; }
            [DataMember]
            public List<string> cautions { get; set; }
            [DataMember]
            public List<string> ingredientLines { get; set; }
            [DataMember]
            public List<Ingredient> ingredients { get; set; }
            [DataMember]
            public double calories { get; set; }
            [DataMember]
            public double totalWeight { get; set; }
            [DataMember]
            public int totalTime { get; set; }
            [DataMember]
            public TotalNutrients totalNutrients { get; set; }
            [DataMember]
            public TotalDaily totalDaily { get; set; }
            [DataMember]
            public List<Digest> digest { get; set; }
        }

        [DataContract]
        public class Hit
        {
            [DataMember]
            public Recipe recipe { get; set; }
            [DataMember]
            public bool bookmarked { get; set; }
            [DataMember]
            public bool bought { get; set; }
        }

        [DataContract]
        public class RootObject
        {
            [DataMember]
            public string q { get; set; }
            [DataMember]
            public int from { get; set; }
            [DataMember]
            public int to { get; set; }
            [DataMember]
            public bool more { get; set; }
            [DataMember]
            public int count { get; set; }
            [DataMember]
            public List<Hit> hits { get; set; }
        }
        [DataContract]
        public class Ingredient
        {
            [DataMember]
            public string text { get; set; }
            [DataMember]
            public double weight { get; set; }
        }

        [DataContract]
        public class ENERCKCAL
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FAT
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FASAT
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FATRN
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FAMS
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FAPU
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class CHOCDF
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FIBTG
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class SUGAR
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class PROCNT
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }

        }

        [DataContract]
        public class CHOLE
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class NA
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class CA
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class MG
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class K
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FE
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class ZN
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class P
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITARAE
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITC
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class THIA
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class RIBF
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class NIA
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITB6A
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FOLDFE
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FOLFD
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITB12
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITD
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class TOCPHA
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITK1
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class WATER
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class TotalNutrients
        {
            [DataMember]
            public ENERCKCAL ENERC_KCAL { get; set; }
            [DataMember]
            public FAT FAT { get; set; }
            [DataMember]
            public FASAT FASAT { get; set; }
            [DataMember]
            public FATRN FATRN { get; set; }
            [DataMember]
            public FAMS FAMS { get; set; }
            [DataMember]
            public FAPU FAPU { get; set; }
            [DataMember]
            public CHOCDF CHOCDF { get; set; }
            [DataMember]
            public FIBTG FIBTG { get; set; }
            [DataMember]
            public SUGAR SUGAR { get; set; }
            [DataMember]
            public PROCNT PROCNT { get; set; }
            [DataMember]
            public CHOLE CHOLE { get; set; }
            [DataMember]
            public NA NA { get; set; }
            [DataMember]
            public CA CA { get; set; }
            [DataMember]
            public MG MG { get; set; }
            [DataMember]
            public K K { get; set; }
            [DataMember]
            public FE FE { get; set; }
            [DataMember]
            public ZN ZN { get; set; }
            [DataMember]
            public P P { get; set; }
            [DataMember]
            public VITARAE VITA_RAE { get; set; }
            [DataMember]
            public VITC VITC { get; set; }
            [DataMember]
            public THIA THIA { get; set; }
            [DataMember]
            public RIBF RIBF { get; set; }
            [DataMember]
            public NIA NIA { get; set; }
            [DataMember]
            public VITB6A VITB6A { get; set; }
            [DataMember]
            public FOLDFE FOLDFE { get; set; }
            [DataMember]
            public FOLFD FOLFD { get; set; }
            [DataMember]
            public VITB12 VITB12 { get; set; }
            [DataMember]
            public VITD VITD { get; set; }
            [DataMember]
            public TOCPHA TOCPHA { get; set; }
            [DataMember]
            public VITK1 VITK1 { get; set; }
            [DataMember]
            public WATER WATER { get; set; }
        }

        [DataContract]
        public class ENERCKCAL2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FAT2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FASAT2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class CHOCDF2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FIBTG2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class PROCNT2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class CHOLE2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class NA2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class CA2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class MG2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class K2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FE2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class ZN2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class P2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITARAE2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITC2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class THIA2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class RIBF2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class NIA2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITB6A2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class FOLDFE2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITB122
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITD2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class TOCPHA2
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class VITK12
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public double quantity { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class TotalDaily
        {
            [DataMember]
            public ENERCKCAL2 ENERC_KCAL { get; set; }
            [DataMember]
            public FAT2 FAT { get; set; }
            [DataMember]
            public FASAT2 FASAT { get; set; }
            [DataMember]
            public CHOCDF2 CHOCDF { get; set; }
            [DataMember]
            public FIBTG2 FIBTG { get; set; }
            [DataMember]
            public PROCNT2 PROCNT { get; set; }
            [DataMember]
            public CHOLE2 CHOLE { get; set; }
            [DataMember]
            public NA2 NA { get; set; }
            [DataMember]
            public CA2 CA { get; set; }
            [DataMember]
            public MG2 MG { get; set; }
            [DataMember]
            public K2 K { get; set; }
            [DataMember]
            public FE2 FE { get; set; }
            [DataMember]
            public ZN2 ZN { get; set; }
            [DataMember]
            public P2 P { get; set; }
            [DataMember]
            public VITARAE2 VITA_RAE { get; set; }
            [DataMember]
            public VITC2 VITC { get; set; }
            [DataMember]
            public THIA2 THIA { get; set; }
            [DataMember]
            public RIBF2 RIBF { get; set; }
            [DataMember]
            public NIA2 NIA { get; set; }
            [DataMember]
            public VITB6A2 VITB6A { get; set; }
            [DataMember]
            public FOLDFE2 FOLDFE { get; set; }
            [DataMember]
            public VITB122 VITB12 { get; set; }
            [DataMember]
            public VITD2 VITD { get; set; }
            [DataMember]
            public TOCPHA2 TOCPHA { get; set; }
            [DataMember]
            public VITK12 VITK1 { get; set; }
        }

        [DataContract]
        public class Sub
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public string tag { get; set; }
            [DataMember]
            public string schemaOrgTag { get; set; }
            [DataMember]
            public double total { get; set; }
            [DataMember]
            public bool hasRDI { get; set; }
            [DataMember]
            public double daily { get; set; }
            [DataMember]
            public string unit { get; set; }
        }

        [DataContract]
        public class Digest
        {
            [DataMember]
            public string label { get; set; }
            [DataMember]
            public string tag { get; set; }
            [DataMember]
            public string schemaOrgTag { get; set; }
            [DataMember]
            public double total { get; set; }
            [DataMember]
            public bool hasRDI { get; set; }
            [DataMember]
            public double daily { get; set; }
            [DataMember]
            public string unit { get; set; }
            [DataMember]
            public List<Sub> sub { get; set; }
        }
    }
}
