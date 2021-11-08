using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebAPI.Models
{
    public class CompletedExercise
    {
        [Required]
        public string UserLogin { get; set; }

        [Required]
        public string Exercise { get; set; }

        [Required]
        public int ExpendedTime { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int DistanceTraveled { get; set; }

        [Required]
        public int ExpendedCalories { get; set; }
    }
}
