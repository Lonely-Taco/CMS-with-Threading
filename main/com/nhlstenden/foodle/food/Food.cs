using CMS.main.com.nhlstenden.foodle.filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    public class Food
    {
        string foodId;
        string foodName;
        string category;
        string brand;
        Uri imageLocation;
        List<Nutrient> nutrients;

        public Food(string foodId, string foodName)
        {
            this.foodId = foodId;
            this.foodName = foodName;
            this.nutrients = new List<Nutrient>();
        }

        [JsonConstructor]
        public Food(string foodId, string foodName, string category, string brand, Uri imageLocation, List<Nutrient> nutrients)
        {
            this.foodId = foodId;
            this.foodName = foodName;
            this.category = category;
            this.brand = brand;
            this.imageLocation = imageLocation;
            this.nutrients = nutrients;
        }

        public string FoodId { get => foodId; set => foodId = value; }
        public string FoodName { get => foodName; set => foodName = value;}

        public Uri ImageLocation { get => imageLocation; set => imageLocation = value; }
        public string Category { get => category; set => category = value; }
        public string Brand { get => brand; set => brand = value; }
        public List<Nutrient> Nutrients { get => nutrients; set => nutrients = value; }

        public string GetTitle()
        {
            if (Brand != null)
            {
                return String.Format("{0} by {1}", FoodName, Brand);
            }
            else
            {
                return FoodName;
            }
        }
    }
}
