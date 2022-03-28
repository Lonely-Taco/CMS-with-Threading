using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class User
    {
        UserSettings userSettings;
        Diet currentDiet;
        List<Workout> workouts;
        List<FoodIntake> foodIntakes;

        public User(UserSettings userSettings, Diet currentDiet, List<Workout> workouts, List<FoodIntake> foodIntakes)
        {
            this.userSettings = userSettings;
            this.currentDiet = currentDiet;
            this.workouts = workouts;
            this.foodIntakes = foodIntakes;
        }

        internal List<FoodIntake> FoodIntakes { get => foodIntakes; set => foodIntakes = value; }
        internal List<Workout> Workouts { get => workouts; set => workouts = value; }
        internal Diet CurrentDiet { get => currentDiet; set => currentDiet = value; }
        internal UserSettings UserSettings { get => userSettings; set => userSettings = value; }
    }
}
