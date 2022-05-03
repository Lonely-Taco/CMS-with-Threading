using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CMS.main.com.nhlstenden.foodle.pages.windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkoutWindow : Page
    {
        public WorkoutWindow()
        {
            this.InitializeComponent();
        }

        private async Task<Workout> SaveWorkout()
        {
            string workoutName = this.WorkoutNameInput.Text;
            DateTime startDate = this.StartDateInput.Date.DateTime;
            DateTime endDate = this.EndDateInput.Date.DateTime;
            string workoutDescription = this.WorkoutDescriptionInput.Text;
            int amountOfCaloriesBurned = (int) this.AmountOfCaloriesBurned.Value;
            Workout workoutToAdd = new Workout(startDate, endDate, workoutName, workoutDescription, amountOfCaloriesBurned);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            String connetionString =
            "Data Source=DESKTOP-PIVKCNJ;Initial Catalog=foodle;User Id=SQL Login; Password=SQLLogin";
            SqlConnection cnn = new SqlConnection(connetionString);
            String sql = "INSERT INTO workout (user_id, start_date, end_date, name, description, amount_of_calories_burned) values(@user_id, @startDate, @endDate, @workoutName, @workoutDescription, @amountOfCaloriesBurned)";

            try
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@user_id", 1);
                command.Parameters.AddWithValue("@startDate", workoutToAdd.StartDate);
                command.Parameters.AddWithValue("@endDate", workoutToAdd.EndDate);
                command.Parameters.AddWithValue("@workoutName", workoutToAdd.WorkoutName);
                command.Parameters.AddWithValue("@workoutDescription", workoutToAdd.Description);
                command.Parameters.AddWithValue("@amountOfCaloriesBurned", workoutToAdd.ExpectedCaloriesBurned);
                command.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return workoutToAdd;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await SaveWorkout();
        }

    }

    
}
