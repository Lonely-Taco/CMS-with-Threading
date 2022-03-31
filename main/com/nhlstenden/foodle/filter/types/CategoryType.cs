using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle.filter.types
{
    public static class CategoryType
    {
        public static readonly string GENERIC_FOODS = "generic-foods";
        public static readonly string GENERIC_MEALS = "generic-meals";
        public static readonly string PACKAGED_FOODS = "packaged-foods";
        public static readonly string FAST_FOODS = "fast-foods";

        public static List<string> getCategoryTypes()
        {
            return new List<string>
            {
                GENERIC_FOODS,
                GENERIC_MEALS,
                PACKAGED_FOODS,
                FAST_FOODS,
            };
        }
    }
}
