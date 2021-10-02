using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class CompletedExercise
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ExerciseId { get; set; }
        public int ExpendedTime { get; set; }
        public DateTime Date { get; set; }
        public int DistanceTraveled { get; set; }
        public int ExpendedCalories { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual User User { get; set; }
    }
}
