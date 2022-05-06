using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

namespace CMS.main.com.nhlstenden.foodle.pages.windows
{
    public sealed partial class FoodInfoWindow : Page
    {
        private Food food;
        public FoodInfoWindow()
        {
            this.InitializeComponent();
            this.FoodNameLabel.Text = "No food loaded";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            food = JsonConvert.DeserializeObject<Food>((string)e.Parameter);
            if (food != null)
            {
                this.FoodNameLabel.Text = food.GetTitle();
                this.FoodIdLabel.Text = food.FoodId;
                this.NutrientPieSeries.ItemsSource = food.Nutrients;
                this.FoodImageSource.UriSource = food.ImageLocation;
            }
            base.OnNavigatedTo(e);
        }
    }
}
