using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.DataModels
{
    public class CompletedExerciseDataModel
    {
        public string Exercise { get; set; }
        public int ExpendedTime { get; set; }
        public DateTime Date { get; set; }
        public int DistanceTraveled { get; set; }
        public int ExpendedCalories { get; set; }
    }
}
