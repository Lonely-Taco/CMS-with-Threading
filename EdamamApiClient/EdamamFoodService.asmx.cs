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
using CMS.main.com.nhlstenden.foodle;
using EdamamApiClient.edamam_client_api.data_objects;
using System.Web.Script.Serialization;

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
    public class EdamamFoodService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<EdamamResponseObject.Food> GetFood(string foodName)
        {
            using (WebClient clinet = new WebClient())
            {
                string apiUrl = CreateUrl(foodName);
                WebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
                WebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader responseReader = new StreamReader(responseStream);

                string responseString = responseReader.ReadToEnd();
                EdamamResponseObject responseObject = new JavaScriptSerializer().Deserialize<EdamamResponseObject>(responseString);
                return responseObject.getFood();
            }

        }

        private string CreateUrl(string foodName)
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
                string appIdString = String.Format("?app_id={0}&app_key={1}", appId, appKey);
                string ingredientString = String.Format("&ingr={0}&nutrition-type=cooking", foodName);
                return baseUrl + appIdString + ingredientString;
            }

            throw new Exception("Could not find file secrets.json");
        }

        //private string getFilterUrlString(SearchFilter searchFilter)
        //{
        //    for()
        //    searchFilter.HealthFilters
        //}

    }
}
