using CMS.main.com.nhlstenden.foodle.pages.windows;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CMS.main.com.nhlstenden.foodle.pages
{
    public sealed partial class BrowsePage : UserControl
    {
        public BrowsePage()
        {
            this.InitializeComponent();
        }

        private void OpenFoodInfoWindow()
        {
            Food food = new Food("#123456", "Hamburger");
            string foodAsParam = JsonConvert.SerializeObject(food);
            OpenPageAsWindowAsync(typeof(FoodInfoWindow), foodAsParam);
        }

        public void FoodInfo_Click(object sender, RoutedEventArgs e)
        {
            OpenFoodInfoWindow();
        }

        /// <summary>
        /// Opens a page given the page type as a new window.
        /// </summary>
        /// <param name="t"></param>
        private async void OpenPageAsWindowAsync(Type t, string param)
        {
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(
                            CoreDispatcherPriority.Normal,
                            async () =>
                            {
                                var newWindow = Window.Current;
                                var newAppView = ApplicationView.GetForCurrentView();
                                newAppView.Title = "New window";

                                var frame = new Frame();
                                frame.Navigate(t, param);
                                newWindow.Content = frame;
                                newWindow.Activate();

                                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
                                    newAppView.Id,
                                    ViewSizePreference.UseMinimum,
                                    currentAV.Id,
                                    ViewSizePreference.UseMinimum);
                            });
        }
    }
}
