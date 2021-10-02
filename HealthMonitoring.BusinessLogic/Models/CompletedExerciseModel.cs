using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class CompletedExerciseModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ExerciseId { get; set; }
        public int ExpendedTime { get; set; }
        public DateTime Date { get; set; }
        public int DistanceTraveled { get; set; }
        public int ExpendedCalories { get; set; }
    }
}
