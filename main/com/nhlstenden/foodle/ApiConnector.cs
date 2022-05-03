using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using CMS.main.com.nhlstenden.foodle.filter;
using System.Threading.Tasks;
using CMS.main.com.nhlstenden.foodle.utility;
using CMS.main.com.nhlstenden.foodle.resources;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class ApiConnector
    {
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

        public async static Task<List<Food>> GetFoodListFromApi(SearchFilter searchFilter)
        {
            InitializeClient();

            using (HttpResponseMessage response = await ApiClient.GetAsync(CreateUrl(searchFilter)))
            {

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    EdamamResponseObject rootobject = JsonConvert.DeserializeObject<EdamamResponseObject>(json);
                    return FoodParser.FoodResponseObjectListToFoodList(rootobject.getFoods());
                }
                else
                {
                    //TODO: Add exception here
                    return null;
                }
            }
        }

        private static string CreateUrl(SearchFilter searchFilter)
        {
            return CreateUrlOnName(searchFilter.TextFilter) + getFilterUrlString(searchFilter) + GetCalorieFilterString(searchFilter);
        }


        public static string CreateUrlOnName(string foodName)
        {
            string appId = Secrets.app_id;
            string appKey = Secrets.app_key;
            string baseUrl = String.Format("https://api.edamam.com/api/food-database/v2/parser");
            string appSecurityString = String.Format("?app_id={0}&app_key={1}", appId, appKey);
            string nameString = String.Format("&ingr={0}&nutrition-type=cooking", foodName);
            return baseUrl + appSecurityString + nameString;
        }

        private static string getFilterUrlString(SearchFilter searchFilter)
        {
            string filterUrlString = "";

            foreach (FilterObject filter in searchFilter.getFilters())
            {
                filterUrlString += String.Format("&{0}={1}", filter.FilterType, filter.FilterName);
            }
            return filterUrlString;
        }   

        private static string GetCalorieFilterString(SearchFilter searchFilter)
        {
            if(searchFilter.MinCal != -1 && searchFilter.MaxCal != -1)
            {
                return String.Format("&calories={0}-{1}", searchFilter.MinCal, searchFilter.MaxCal);
            }else if(searchFilter.MinCal != -1)
            {
                return String.Format("&calories={0}%2B", searchFilter.MinCal);
            }
            else if (searchFilter.MaxCal != -1)
            {
                return String.Format("&calories={0}", searchFilter.MaxCal);
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
