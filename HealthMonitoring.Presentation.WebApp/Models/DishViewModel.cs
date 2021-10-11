using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Calories { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
