using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class CharacteristicsOfTheDish
    {
        public int Id { get; set; }
        public int? DishId { get; set; }
        public int Weight { get; set; }
        public int Calories { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
