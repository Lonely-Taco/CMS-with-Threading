using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class Workout
    {
        DateTime startDate;
        DateTime endDate;
        List<WeekDay> scheduledDays;
        String workoutName;
        String description;
        int expectedCaloriesBurned;
        List<WorkoutSession> workoutSessions;
    }
}
