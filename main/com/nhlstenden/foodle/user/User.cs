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
        List<Recipe> savedRecipes;
        Dictionary<DateTime, FoodIntake> foodIntakes;

        public User(UserSettings userSettings, Diet currentDiet, List<Workout> workouts, List<Recipe> savedRecipes, Dictionary<DateTime, FoodIntake> foodIntakes)
        {
            this.userSettings = userSettings;
            this.currentDiet = currentDiet;
            this.workouts = workouts;
            this.savedRecipes = savedRecipes;
            this.foodIntakes = foodIntakes;
        }

        internal Dictionary<DateTime, FoodIntake> FoodIntakes { get => foodIntakes; set => foodIntakes = value; }
        internal List<Recipe> SavedRecipes { get => savedRecipes; set => savedRecipes = value; }
        internal List<Workout> Workouts { get => workouts; set => workouts = value; }
        internal Diet CurrentDiet { get => currentDiet; set => currentDiet = value; }
        internal UserSettings UserSettings { get => userSettings; set => userSettings = value; }
    }
}
