using EdamamApiClient.edamam_client_api.filter.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class SearchFilter
    {
        String textFilter;
        int minCal;
        int maxCal;
        List<string> healthFilters;
        List<string> dishTypeFilters;
        List<string> cuisineTypeFilters;
        List<string> mealTypeFilters;
        List<string> dietTypeFilters;

        public SearchFilter(string textFilter, int minCal, int maxCal, List<string> healthFilters, 
            List<string> dishTypeFilters, List<string> cuisineTypeFilters, List<string> mealTypeFilters, 
            List<string> dietTypeFilters)
        {
            this.textFilter = textFilter;
            this.minCal = minCal;
            this.maxCal = maxCal;
            this.healthFilters = healthFilters;
            this.dishTypeFilters = dishTypeFilters;
            this.cuisineTypeFilters = cuisineTypeFilters;
            this.mealTypeFilters = mealTypeFilters;
            this.dietTypeFilters = dietTypeFilters;
        }

        public string TextFilter { get => textFilter; set => textFilter = value; }
        public int MinCal { get => minCal; set => minCal = value; }
        public int MaxCal { get => maxCal; set => maxCal = value; }
        public List<string> HealthFilters { get => healthFilters; set => healthFilters = value; }
        public List<string> DishTypeFilters { get => dishTypeFilters; set => dishTypeFilters = value; }
        public List<string> CuisineTypeFilters { get => cuisineTypeFilters; set => cuisineTypeFilters = value; }
        public List<string> MealTypeFilters { get => mealTypeFilters; set => mealTypeFilters = value; }
        public List<string> DietTypeFilters { get => dietTypeFilters; set => dietTypeFilters = value; }
    }
}
