using System;
using System.Collections;
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
        String workoutName;
        String description;
        int expectedCaloriesBurned;
        List<WorkoutSession> workoutSessions;

        public Workout(DateTime startDate, DateTime endDate, string workoutName, string description, int expectedCaloriesBurned)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.workoutName = workoutName;
            this.description = description;
            this.expectedCaloriesBurned = expectedCaloriesBurned;
            workoutSessions = new List<WorkoutSession>();
        }

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string WorkoutName { get => workoutName; set => workoutName = value; }
        public string Description { get => description; set => description = value; }
        public int ExpectedCaloriesBurned { get => expectedCaloriesBurned; set => expectedCaloriesBurned = value; }
        public List<WorkoutSession> GetWorkoutSessions { get => workoutSessions; }

        public void AddWorkoutSession(WorkoutSession workoutSession)
        {
            workoutSessions.Add(workoutSession);
        }

    }
}
