using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CMS.main.com.nhlstenden.foodle.pages
{
    public sealed partial class UserSettingsPage : UserControl
    {
        public UserSettingsPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string UserDirectory = @"c:\Users/Ramon/";

            using (StreamReader SourceReader = File.OpenText(UserDirectory + "BigFile.txt"))
            {
                using (StreamWriter DestinationWriter = File.CreateText(UserDirectory + "CopiedFile.txt"))
                {
                    await CopyFilesAsync(SourceReader, DestinationWriter);
                }
            }
        }

        public async Task CopyFilesAsync(StreamReader Source, StreamWriter Destination)
        {
            var buffer = new char[0x1000];
            int numRead;
            while ((numRead = await Source.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                await Destination.WriteAsync(buffer, 0, numRead);
            }
        }

        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add "using Windows.UI;" for Color and Colors.
            string theme = e.AddedItems[0].ToString();
            switch (theme)
            {
                case "Light":
                    if (Window.Current.Content is FrameworkElement frameworkElement0)
                        frameworkElement0.RequestedTheme = ElementTheme.Light;
                    break;
                case "Dark":
                    if (Window.Current.Content is FrameworkElement frameworkElement1)
                        frameworkElement1.RequestedTheme = ElementTheme.Dark;
                    break;
            }
        }
    }


}
