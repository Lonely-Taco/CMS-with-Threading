using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class Recipe
    {
        List<FoodAmount> ingredients;

        public Recipe(List<FoodAmount> ingredients)
        {
            this.ingredients = ingredients;
        }

        internal List<FoodAmount> Ingredients { get => ingredients; set => ingredients = value; }
    }
}
