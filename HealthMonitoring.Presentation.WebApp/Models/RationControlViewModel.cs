using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models
{
    public class RationControlViewModel
    {
        public List<string> DishesName { get; set; }
        public List<EatenDishViewModel> EatenDishes {get; set;}
    }
}
