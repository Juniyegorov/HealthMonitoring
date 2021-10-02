using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class CompositionOfTheDishModel
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Calories { get; set; }
    }
}
