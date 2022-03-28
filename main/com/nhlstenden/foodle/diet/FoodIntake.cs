using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle.main.com.nhlstenden.foodle
{
    internal class FoodIntake
    {
        List<FoodAmount> foodEaten;
        List<Recipe> recipesEaten;

        public FoodIntake(List<FoodAmount> foodEaten, List<Recipe> recipesEaten)
        {
            this.foodEaten = foodEaten;
            this.recipesEaten = recipesEaten;
        }

        internal List<FoodAmount> FoodEaten { get => foodEaten; set => foodEaten = value; }
        internal List<Recipe> RecipesEaten { get => recipesEaten; set => recipesEaten = value; }
    }
}
