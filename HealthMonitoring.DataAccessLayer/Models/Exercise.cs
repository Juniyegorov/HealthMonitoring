using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class Exercise
    {
        public Exercise()
        {
            CompletedExercises = new HashSet<CompletedExercise>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CompletedExercise> CompletedExercises { get; set; }
    }
}
