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
        }


    }
}
