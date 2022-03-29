using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    public class Food
    {
        String foodId;
        String foodName;
        List<String> labels;
        Uri imageLocation;
        List<Nutrient> nutrients;

        public Food(string foodId, string foodName, String imageLocation = "missing_image.jpg")
        {
            this.foodId = foodId;
            this.foodName = foodName;
            this.labels = new List<string>();
            this.imageLocation = null;
            this.nutrients = new List<Nutrient>();
        }

        public string FoodId { get => foodId; set => foodId = value; }
        public string FoodName { get => foodName; set => foodName = value;}
        public List<string> Labels { get => labels; set => labels = value; }
        public Uri ImageLocation { get => imageLocation; set => imageLocation = value; }
        internal List<Nutrient> Nutrients { get => nutrients; set => nutrients = value; }
    }
}
