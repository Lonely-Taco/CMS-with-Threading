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


    }
}
