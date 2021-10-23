using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models
{
    public class EatenDishViewModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }
}
