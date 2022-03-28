using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class Diet
    {
        List<DietNutrient> dietNutrients;
        String dietName;
        String description;

        public Diet(List<DietNutrient> dietNutrients, string dietName, string description)
        {
            this.dietNutrients = dietNutrients;
            this.dietName = dietName;
            this.description = description;
        }

        public string DietName { get => dietName; set => dietName = value; }
        public string Description { get => description; set => description = value; }
        internal List<DietNutrient> DietNutrients { get => dietNutrients; set => dietNutrients = value; }


    }
}
