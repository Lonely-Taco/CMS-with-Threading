using CMS.main.com.nhlstenden.foodle.pages.windows;
using EdamamApiClient.edamam_client_api.filter.types;
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
            HealthLabelMultiSelectComboBox.ItemsSource = HealthTypes.getHealthLabels();
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

        //Make a text box only accept numbers
        private void NumberBox_OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            //remove any non-digits
            string newText = new string(sender.Text.Where(char.IsDigit).ToArray());
            //if empty string set an empty string
            if (string.Equals(newText, string.Empty))
            {
                sender.Text = newText;
            }
            else
            {
                float input = -1;
                float.TryParse(newText, out input);
                //set the maximum number that can be input to 9999
                input = Math.Min(input, 9999);
                //change the text in the textbox
                sender.Text = input.ToString();
                //set the cursor to the end
                sender.SelectionStart = sender.Text.Length;
            }
        }
    }
}
