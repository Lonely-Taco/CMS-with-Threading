using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdamamApiClient.data_objects
{
    public class FoodDataObject
    {
        public string FoodName { get; set; }
        public FoodDataObject()
        {
            this.FoodName = "Hamburger";
        }
    }
}