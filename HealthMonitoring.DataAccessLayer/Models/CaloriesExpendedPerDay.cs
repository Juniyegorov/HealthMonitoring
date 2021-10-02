using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class CaloriesExpendedPerDay
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }

        public virtual User User { get; set; }
    }
}
