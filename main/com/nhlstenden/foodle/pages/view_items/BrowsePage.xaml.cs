using CMS.main.com.nhlstenden.foodle.filter.types;
using CMS.main.com.nhlstenden.foodle.pages.windows;
using EdamamApiClient.edamam_client_api.filter.types;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace CMS.main.com.nhlstenden.foodle.pages
{
    //Browse page used for finding a food item from the Edamam API
    public sealed partial class BrowsePage : UserControl
    {
        public BrowsePage()
        {
            this.InitializeComponent();
            HealthLabelMultiSelectComboBox.ItemsSource = HealthLabel.getHealthLabels();
            CategoryTypeMultiSelectComboBox.ItemsSource = CategoryType.getCategoryTypes();
        }

        private void OpenFoodInfoWindow(Food food)
        {
            string foodAsParam = JsonConvert.SerializeObject(food);
            OpenPageAsWindowAsync(typeof(FoodInfoWindow), foodAsParam);
        }

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
                int input = -1;
                int.TryParse(newText, out input);
                //set the maximum number that can be input to 9999
                input = Math.Min(input, 9999);
                //change the text in the textbox
                sender.Text = input.ToString();
                //set the cursor to the end
                sender.SelectionStart = sender.Text.Length;
            }
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FoodGrid.ItemsSource = await GetFoodResult();
        }

        private async Task<List<Food>> GetFoodResult()
        {
            string foodName = this.FoodNameInput.Text;

            //if calorie input is not a number value gets set to -1, otherwise it will get parsed to the correct number
            int minCal = int.TryParse(this.MinCalInput.Text, out minCal) ? minCal : -1;
            int maxCal = int.TryParse(this.MaxCalInput.Text, out maxCal) ? maxCal : -1;

            List<string> healthLabels = HealthLabelMultiSelectComboBox.SelectedItems.Cast<string>().ToList();
            List<string> categoryTypes = CategoryTypeMultiSelectComboBox.SelectedItems.Cast<string>().ToList();
            SearchFilter searchFilter = new SearchFilter(foodName, minCal, maxCal, healthLabels, categoryTypes);
            List<Food> foodList = await ApiConnector.GetFoodListFromApi(searchFilter);

            return foodList;
        }

        private void FoodDataTableInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Food food = (Food)button.DataContext;
            OpenFoodInfoWindow(food);
        }

        private void FoodGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Modify the header of the "Name" column
            if (e.Column.Header.ToString() == "ImageLocation" || e.Column.Header.ToString() == "Nutrients" || e.Column.Header.ToString() == "FoodId")
            {
                e.Cancel = true;
            }
            //Disable user input inside cells 
            e.Column.IsReadOnly = true;
        }
    }
}
