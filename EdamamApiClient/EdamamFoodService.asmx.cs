using EdamamApiClient.data_objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Json;
using EdamamApiClient.edamam_client_api.data_objects;
using System.Web.Script.Serialization;
using EdamamApiClient.edamam_client_api.filter.types;
using EdamamApiClient.edamam_client_api.filter;

namespace EdamamApiClient
{
    /// <summary>
    /// Summary description for EdamamFoodService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EdamamFoodService : WebService
    {

        [WebMethod]
        public List<EdamamResponseObject.Food> GetFood(SearchFilter searchFilter)
        {
            string apiUrl = CreateUrl(searchFilter);
            return GetResponse(apiUrl);

        }

        [WebMethod]
        public List<EdamamResponseObject.Food> GetFoodOnName(string foodName)
        {
            string apiUrl = CreateUrlOnName(foodName);
            return GetResponse(apiUrl);
        }

        public List<EdamamResponseObject.Food> GetResponse(string apiUrl)
        {
            using (WebClient clinet = new WebClient())
            {
                WebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                WebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);

                string responseString = responseReader.ReadToEnd();
                EdamamResponseObject responseObject = new JavaScriptSerializer().Deserialize<EdamamResponseObject>(responseString);
                return responseObject.getFood();
            }
        }

        private string CreateUrl(SearchFilter searchFilter)
        {
            return CreateUrlOnName(searchFilter.TextFilter) + getFilterUrlString(searchFilter);
        }

        private string CreateUrlOnName(string foodName)
        {
            string fileName = "edamam_client_api/resources/secrets.json";
            string path = Path.Combine(Server.MapPath("~/"), fileName);

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

        private string getFilterUrlString(SearchFilter searchFilter)
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
