using CMS.main.com.nhlstenden.foodle;
using CMS.main.com.nhlstenden.foodle.pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CMS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private FontFamily iconFont;

        public MainPage()
        {
            this.InitializeComponent();
            iconFont = new FontFamily("Segoe MDL2 Assets");
            InitializeMenuItems();
        }

        private void InitializeMenuItems()
        {
            NavigationViewItem homeItem = new NavigationViewItem()
            {
                Content = "Home",
                Icon = new FontIcon()
                {
                    FontFamily = iconFont,
                    Glyph = "\xE80F"
                }
            };

            NavigationViewItem browseItem = new NavigationViewItem()
            {
                Content = "Browse",
                Icon = new FontIcon()
                {
                    FontFamily = iconFont,
                    Glyph = "\xE80F"
                }
            };

            NavigationViewItem workoutItem = new NavigationViewItem()
            {
                Content = "Workout",
                Icon = new FontIcon()
                {
                    FontFamily = iconFont,
                    Glyph = "\xE80F"
                }
            };



            this.mainNavigationView.MenuItems.Add(homeItem);
            this.mainNavigationView.MenuItems.Add(browseItem);
            this.mainNavigationView.MenuItems.Add(workoutItem);

            this.mainNavigationView.SelectionChanged += MainNavigationView_SelectionChanged;

        }

        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                if (args.SelectedItem is NavigationViewItem item)
                {
                    switch (item.Content)
                    {
                        case "Home":
                            selectedItemFrame.Content = new HomePage();
                            break;
                        case "Browse":
                            selectedItemFrame.Content = new BrowsePage();
                            break;
                        case "Workout":
                            selectedItemFrame.Content = new WorkoutPage();
                            break;
                        case "Settings":
                            selectedItemFrame.Content = new UserSettingsPage();
                            break;
                        default:
                            break;
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Opens a page given the page type as a new window.
        /// </summary>
        /// <param name="t"></param>
        private async Task<bool> OpenPageAsWindowAsync(Type t)
        {
            var view = CoreApplication.CreateNewView();
            int id = 0;

            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(t, null);
                Window.Current.Content = frame;
                Window.Current.Activate();
                id = ApplicationView.GetForCurrentView().Id;
            });

            return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ApiConnector.InitializeClient();

            using (HttpResponseMessage response = await ApiConnector.ApiClient.GetAsync(ApiConnector.CreateUrlOnName()))
            {

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    
                    JObject js = JObject.Parse(json);

               
                    EdamamResponseObject rootobject = JsonConvert.DeserializeObject<EdamamResponseObject>(json);

                    //Food myDeserializedClass = JsonConvert.DeserializeObject<Food>((string)js["parsed"]);

                    foreach (EdamamResponseObject.Food food in rootobject.getFoods())
                    {
                        string fname = food.label;
                    }
        
                }
            }
        }
    }
}
