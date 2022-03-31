using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        public List<Food> MakeAPIRequest()
        {
            return new List<Food>();
        }
    }
}
