using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebAPI.Models
{
    public class EatenDish
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Calories { get; set; }
    }
}
