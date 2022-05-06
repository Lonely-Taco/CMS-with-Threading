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
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace CMS.main.com.nhlstenden.foodle.pages
{
    public sealed partial class LoginPage : UserControl
    {
        public LoginPage()
        {
            this.InitializeComponent();
            updateCombobox(retrieveUsers());
        }

        private void CreateUser(String userName)
        {
            // Create connection to database
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String connetionString =
                "Data Source = (your PC name here); Initial Catalog = Foodle; User ID = 'SQLLogin1'; Password = SQLLogin";
            SqlConnection cnn = new SqlConnection(connetionString);
            String sql = $"INSERT INTO users (window_color_hex, username) values('light', '{userName}')";
            try
            {
                // Open connection
                cnn.Open();
                // Execute sql
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
            CreateUser(UserNameInput.Text);
            updateCombobox(retrieveUsers());
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("User has been created.");

            // Show the message dialog
            await messageDialog.ShowAsync();
        }




        private List<String> retrieveUsers()
        {
            // Create connection to database
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<String> users = new List<String>();
            String connetionString =
                // IMPORTANT!! ADD MSSMS PC name \|/
                "Data Source=(your PC name here);Initial Catalog=foodle;User Id=SQLLogin1; Password=SQLLogin";
            SqlConnection cnn = new SqlConnection(connetionString);
            String sql = $"SELECT username FROM users";
            try
            {
                // Open connection
                cnn.Open();
                // Execute sql
                SqlCommand command = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    users.Add(dataReader.GetString(0));
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return users;
        }

        private void updateCombobox(List<String> users)
        {
            UsernameComboBox.ItemsSource = users;
        }

        private void UsernameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Not implmented YET
        }
    }
}
