using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class EatenDishModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DishId { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }
}
