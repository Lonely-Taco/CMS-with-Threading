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

namespace CMS
{
    /// <summary>
    /// The page containing references to the other pages in the application
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly FontFamily iconFont;

        public MainPage()
        {
            this.InitializeComponent();
            iconFont = new FontFamily("Segoe MDL2 Assets");
            InitializeMenuItems();
        }

        private void InitializeMenuItems()
        {
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

            NavigationViewItem loginItem = new NavigationViewItem()
            {
                Content = "Select user",
                Icon = new FontIcon()
                {
                    FontFamily = iconFont,
                    Glyph = "\xE748"
                }
            };


            this.mainNavigationView.MenuItems.Add(browseItem);
            this.mainNavigationView.MenuItems.Add(workoutItem);
            this.mainNavigationView.MenuItems.Add(loginItem);

            this.mainNavigationView.SelectionChanged += MainNavigationView_SelectionChanged;

        }

        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            try
            {
                if (!(args.SelectedItem is NavigationViewItem item)) return;
                switch (item.Content)
                {
                    case "Browse":
                        selectedItemFrame.Content = new BrowsePage();
                        break;
                    case "Workout":
                        selectedItemFrame.Content = new WorkoutPage();
                        break;
                    case "Select user":
                        selectedItemFrame.Content = new LoginPage();
                        break;
                    case "Settings":
                        selectedItemFrame.Content = new UserSettingsPage();
                        break;
                    default:
                        break;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        private void selectedItemFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
