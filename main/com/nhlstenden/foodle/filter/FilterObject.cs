using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.main.com.nhlstenden.foodle.filter
{
    public class FilterObject
    {
        public string FilterName { get; set; }
        public string FilterType { get; set; }

        public FilterObject(string filterName, string filterType)
        {
            FilterName = filterName;
            FilterType = filterType;
        }
    }
}