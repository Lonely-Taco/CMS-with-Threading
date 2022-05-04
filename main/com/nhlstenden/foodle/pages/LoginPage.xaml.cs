﻿using System;
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
            updateCombobox(retrieveUsers());
        }

        private void CreateUser(String userName)
        {
            // Create connection to database
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String connetionString =
                "Data Source = DESKTOP - PIVKCNJ; Initial Catalog = Foodle; User ID = 'SQL Login'; Password = SQLLogin";
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateUser(UserNameInput.Text);
            updateCombobox(retrieveUsers());
        }

        private List<String> retrieveUsers()
        {
            // Create connection to database
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            List<String> users = new List<String>();
            String connetionString =
                // IMPORTANT!! ADD MSSMS PC name \|/
                "Data Source=**Insert own MSSMS PC name** ;Initial Catalog=foodle;User Id=Ramonb2; Password=Password321";
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
