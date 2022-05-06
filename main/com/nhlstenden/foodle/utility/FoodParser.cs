using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle.utility
{
    internal class FoodParser
    {
        public static List<Food> FoodResponseObjectListToFoodList(List<EdamamResponseObject.Food> foodResponseObjectList)
        {
            List<Food> foodList = new List<Food>();
            foreach(EdamamResponseObject.Food foodResponseObject in foodResponseObjectList)
            {
                foodList.Add(FoodResponseObjectToFood(foodResponseObject));
            }
            return foodList;
        }

        private static Food FoodResponseObjectToFood(EdamamResponseObject.Food foodResponseObject)
        {
            Uri.TryCreate(foodResponseObject.image, UriKind.Absolute, out Uri uri);
            return new Food(
                foodResponseObject.foodId, 
                foodResponseObject.label, 
                foodResponseObject.category, 
                foodResponseObject.brand,
                uri, 
                NutrientsRepsonseObjectToNutrients(foodResponseObject.nutrients)
            );
        }

        private static List<Nutrient> NutrientsRepsonseObjectToNutrients(EdamamResponseObject.Nutrients nutrientsResponseObject)
        {
            List<Nutrient> nutrients = new List<Nutrient>
            {
                new Nutrient(nutrientsResponseObject.CHOCDF, NutrientType.CHOCDF),
                new Nutrient(nutrientsResponseObject.PROCNT, NutrientType.PRONCT),
                new Nutrient(nutrientsResponseObject.ENERC_KCAL, NutrientType.ENERC_KAL),
                new Nutrient(nutrientsResponseObject.FAT, NutrientType.FAT),
                new Nutrient(nutrientsResponseObject.FIBTG, NutrientType.FIBTG)
            };
            return nutrients;
        }
    }
}
