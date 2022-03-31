using System;
using System.Collections.Generic;
using System.Linq;
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

        public static List<Food> GetFoodListFromApi(SearchFilter searchFilter)
        {
            //TODO: replace this with actual API reponse, dummy data for now
            List<Food> foodList = new List<Food>();
            Uri uri = new Uri("https://www.edamam.com/food-img/651/6512e82417bce15c2899630c1a2799df.jpg");
            List<Nutrient> nutrientList = new List<Nutrient>()
            {
                new Nutrient(77, NutrientType.ENRC_KAL),
                new Nutrient(2.02f, NutrientType.PRONCT),
                new Nutrient(0.09f, NutrientType.FAT),
                new Nutrient(17.47f, NutrientType.CHOCDF),
                new Nutrient(2.2f, NutrientType.FIBTG)

            };


            foodList.Add(new Food("food_abiw5baauresjmb6xpap2bg3otzu", "Potato", "Generic foods", "", uri, nutrientList));

            Uri uri2 = new Uri("https://www.edamam.com/food-img/9fe/9fef4d110a45649abc60adc7f28104bc.jpg");
            List <Nutrient> nutrientList2 = new List<Nutrient>()
            {
                new Nutrient(69, NutrientType.ENRC_KAL),
                new Nutrient(1.68f, NutrientType.PRONCT),
                new Nutrient(0.1f, NutrientType.FAT),
                new Nutrient(15.71f, NutrientType.CHOCDF),
                new Nutrient(2.4f, NutrientType.FIBTG)

            };

            foodList.Add(new Food("food_bghwdgza5sev19ah92ss0afudx73", "White Potato", "Generic foods", "", uri2, nutrientList2));

            return foodList;
        }
    }
}
