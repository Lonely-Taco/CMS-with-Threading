using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class Nutrient
    {
        float nutrientAmount;
        NutrientType nutrientType;

        public Nutrient(float nutrientAmount, NutrientType nutrientType)
        {
            this.nutrientAmount = nutrientAmount;
            this.nutrientType = nutrientType;
        }

        public float NutrientAmount { get => nutrientAmount; set => nutrientAmount = value; }
        internal NutrientType NutrientType { get => nutrientType; set => nutrientType = value; }
    }
}
