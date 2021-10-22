using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models
{
    public class ExtendedExerciseViewModel
    {
        public List<ExerciseViewModel> Exercises { get; set; }
        public List<CompletedExerciseViewModel> CompletedExercises { get; set; }
    }
}
