using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class DietNutrient
    {
        NutrientType nutrientType;
        int recommendedAmount;

        public DietNutrient(NutrientType nutrientType, int recommendedAmount)
        {
            this.nutrientType = nutrientType;
            this.recommendedAmount = recommendedAmount;
        }

        public int RecommendedAmount { get => recommendedAmount; set => recommendedAmount = value; }
        internal NutrientType NutrientType { get => nutrientType; set => nutrientType = value; }
    }
}
