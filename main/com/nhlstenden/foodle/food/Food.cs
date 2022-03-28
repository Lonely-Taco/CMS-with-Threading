using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle.main.com.nhlstenden.foodle
{
    internal class Food
    {
        String foodId;
        List<String> labels;
        Uri imageLocation;
        List<Nutrient> nutrients;

        public Food(string foodId, List<string> labels, Uri imageLocation, List<Nutrient> nutrients)
        {
            this.foodId = foodId;
            this.labels = labels;
            this.imageLocation = imageLocation;
            this.nutrients = nutrients;
        }

        public string FoodId { get => foodId; set => foodId = value; }
        public List<string> Labels { get => labels; set => labels = value; }
        public Uri ImageLocation { get => imageLocation; set => imageLocation = value; }
        internal List<Nutrient> Nutrients { get => nutrients; set => nutrients = value; }
    }
}
