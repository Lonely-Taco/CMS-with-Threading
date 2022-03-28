using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodle.main.com.nhlstenden.foodle
{
    internal class WorkoutSession
    {
        DateTime startTime;
        DateTime endTime;
        int caloriesBurned;

        public WorkoutSession(DateTime startTime, DateTime endTime, int caloriesBurned)
        {
            this.StartTime = startTime;
            this.endTime = endTime;
            this.caloriesBurned = caloriesBurned;
        }

        public DateTime StartTime { get => startTime; set => startTime = value; }
        public DateTime EndTime { get => endTime; set => endTime = value; }
        public int CaloriesBurned { get => caloriesBurned; set => caloriesBurned = value; }
    }
}
