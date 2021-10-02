using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class CharacteristicsOfTheDishModel
    {
        public int Id { get; set; }
        public int? DishId { get; set; }
        public int Weight { get; set; }
        public int Calories { get; set; }
    }
}
