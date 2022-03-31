using CMS.main.com.nhlstenden.foodle.filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class SearchFilter
    {
        string textFilter;
        int minCal;
        int maxCal;
        List<string> healthFilters;
        List<string> categoryTypes;

        public SearchFilter(string textFilter, int minCal, int maxCal, List<string> healthFilters, List<string> categoryTypes)
        {
            this.textFilter = textFilter;
            this.minCal = minCal;
            this.maxCal = maxCal;
            this.healthFilters = healthFilters;
            this.categoryTypes = categoryTypes;
        }



        public string TextFilter { get => textFilter; set => textFilter = value; }
        public int MinCal { get => minCal; set => minCal = value; }
        public int MaxCal { get => maxCal; set => maxCal = value; }
        public List<string> HealthFilters { get => healthFilters; set => healthFilters = value; }
        public List<string> CategoryType { get => categoryTypes; set => categoryTypes = value; }
    }
}
