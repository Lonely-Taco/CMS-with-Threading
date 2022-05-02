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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CMS.main.com.nhlstenden.foodle.pages.windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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
                this.FoodNameLabel.Text = food.FoodName;
                this.FoodIdLabel.Text = food.FoodId;
                this.NutrientPieSeries.ItemsSource = food.Nutrients;
                this.FoodImageSource.UriSource = food.ImageLocation;
            }
            base.OnNavigatedTo(e);
        }
    }
}
