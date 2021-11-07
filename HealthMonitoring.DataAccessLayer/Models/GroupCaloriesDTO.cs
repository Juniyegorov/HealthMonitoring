using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Models
{
    public class GroupCaloriesDTO
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int Calories { get; set; }
    }
}
