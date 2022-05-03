using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    public class Nutrient
    {
        public int ENERC_KCAL { get; set; }
        public double PROCNT { get; set; }
        public double FAT { get; set; }
        public double CHOCDF { get; set; }
        public int FIBTG { get; set; }

        float nutrientAmount;
        NutrientType nutrientType;

        public Nutrient(float nutrientAmount, NutrientType nutrientType)
        {
            this.nutrientAmount = nutrientAmount;
            this.nutrientType = nutrientType;
        }

        public float NutrientAmount { get => nutrientAmount; set => nutrientAmount = value; }
        public NutrientType NutrientType { get => nutrientType; set => nutrientType = value; }
        public string NutrientName { get => nutrientType.ToString();}
    }
}
