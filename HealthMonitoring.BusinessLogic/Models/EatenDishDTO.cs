using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class EatenDishDTO
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }
}
