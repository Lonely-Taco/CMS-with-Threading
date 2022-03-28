using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class UserSettings
    {
        List<SearchFilter> favouritedFilters;
        Color windowBorderColor;

        public UserSettings(List<SearchFilter> favouritedFilters, Color windowBorderColor)
        {
            this.favouritedFilters = favouritedFilters;
            this.windowBorderColor = windowBorderColor;
        }

        public Color WindowBorderColor { get => windowBorderColor; set => windowBorderColor = value; }
        internal List<SearchFilter> FavouritedFilters { get => favouritedFilters; set => favouritedFilters = value; }
    }
}
