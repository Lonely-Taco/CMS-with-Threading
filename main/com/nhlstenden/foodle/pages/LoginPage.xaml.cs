using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void CreateUser(String userName)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String connetionString =
               @"Data Source=DESKTOP-PIVKCNJ;Initial Catalog=Foodle;Persist Security Info=True;User ID='SQL Login';Password='SQLLogin';";
            SqlConnection cnn = new SqlConnection(connetionString);
            String sql = "INSERT INTO users (window_color_hex, username) values('light', 'Ramon Brakels')";
            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(sql, cnn);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
               Console.Write(ex.Message); 
            }


        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser("test");
        }
    }
}
