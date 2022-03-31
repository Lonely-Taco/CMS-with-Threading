using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public static string CreateUrlOnName(string foodName)
        {

            string appId = "59faa57b";
            string appKey = "e36918a1dec4a492e9a75de375a6f2b8";
            string baseUrl = String.Format("https://api.edamam.com/api/food-database/v2/parser");
            string appSecurityString = String.Format("?app_id={0}&app_key={1}", appId, appKey);
            string nameString = String.Format("&ingr={0}&nutrition-type=cooking", foodName);
            return baseUrl + appSecurityString + nameString;
        }
        

        public List<Food> MakeAPIRequest()
        {
            return new List<Food>();
        }
    }
}
