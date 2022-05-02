using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CMS.main.com.nhlstenden.foodle.filter;
using System.Threading;
using System.Threading.Tasks;
using System.Json;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class ApiConnector
    {
        private static string API_ENDPOINT = "";

        public ApiConnector()
        {
            
        }
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static string CreateUrlOn(SearchFilter searchFilter)
        {
            //string filePath = "main/com/nhlstenden/foodle/resources/secrets.json";

            //string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName, filePath);

            //using (StreamReader r = new StreamReader(path))
            //{

            //string json = r.ReadToEnd();
            //JObject js = JObject.Parse(json);

            //string appId = (string) js["app_secret"]["app_"]; 
            //string appKey = (string)js["app_secret"]["app_key"];
            string appId = "59faa57b";
            string appKey = '';
                string baseUrl = String.Format("https://api.edamam.com/api/food-database/v2/parser");
                string appSecurityString = String.Format("?app_id={0}&app_key={1}", appId, appKey);
                string nameString = String.Format("&ingr={0}&nutrition-type=cooking", searchFilter.TextFilter);
                return baseUrl + appSecurityString + nameString;
            //}
        }

        public async static Task<List<EdamamResponseObject.Food>> GetFoodListFromApi(SearchFilter searchFilter)
        {

            List<EdamamResponseObject.Food> foodList = new List<EdamamResponseObject.Food>();

            InitializeClient();

            using (HttpResponseMessage response = await ApiClient.GetAsync(CreateUrl(searchFilter)))
            {

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    JObject js = JObject.Parse(json);


                    EdamamResponseObject rootobject = JsonConvert.DeserializeObject<EdamamResponseObject>(json);

                   return rootobject.getFood();
                }
            }

            ////TODO: replace this with actual API reponse, dummy data for now
 
            //Uri uri = new Uri("https://www.edamam.com/food-img/651/6512e82417bce15c2899630c1a2799df.jpg");
            //List<Nutrient> nutrientList = new List<Nutrient>()
            //{
            //    new Nutrient(77, NutrientType.ENRC_KAL),
            //    new Nutrient(2.02f, NutrientType.PRONCT),
            //    new Nutrient(0.09f, NutrientType.FAT),
            //    new Nutrient(17.47f, NutrientType.CHOCDF),
            //    new Nutrient(2.2f, NutrientType.FIBTG)

            //};


            //foodList.Add(new Food("food_abiw5baauresjmb6xpap2bg3otzu", "Potato", "Generic foods", "", uri, nutrientList));

            //Uri uri2 = new Uri("https://www.edamam.com/food-img/9fe/9fef4d110a45649abc60adc7f28104bc.jpg");
            //List <Nutrient> nutrientList2 = new List<Nutrient>()
            //{
            //    new Nutrient(69, NutrientType.ENRC_KAL),
            //    new Nutrient(1.68f, NutrientType.PRONCT),
            //    new Nutrient(0.1f, NutrientType.FAT),
            //    new Nutrient(15.71f, NutrientType.CHOCDF),
            //    new Nutrient(2.4f, NutrientType.FIBTG)

            //};

            //foodList.Add(new Food("food_bghwdgza5sev19ah92ss0afudx73", "White Potato", "Generic foods", "", uri2, nutrientList2));

            return foodList;
        }

        private static string CreateUrl(SearchFilter searchFilter)
        {
            return CreateUrlOnName(searchFilter.TextFilter) + getFilterUrlString(searchFilter);
        }

        public static string CreateUrlOnName(string foodName)
        {
            string fileName = "edamam_client_api/resources/secrets.json";
            string path = Path.Combine(S.MapPath("~/"), fileName);

            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonValue jsonArray = JsonValue.Parse(json);
                string appId = jsonArray["app_id"];
                string appKey = jsonArray["app_key"];
                string baseUrl = String.Format("https://api.edamam.com/api/food-database/v2/parser");
                string appSecurityString = String.Format("?app_id={0}&app_key={1}", appId, appKey);
                string nameString = String.Format("&ingr={0}&nutrition-type=cooking", foodName);
                return baseUrl + appSecurityString + nameString;
            }
        }

        private static string getFilterUrlString(SearchFilter searchFilter)
        {
            string filterUrlString = "";

            foreach (FilterObject filter in searchFilter.getFilters())
            {
                String.Format("&{0}={1}", filter.FilterType, filter.FilterName);
            }
            return filterUrlString;
        }

        
    }
}
