using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.DataModels
{
    public class DishComponentsDataModel
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Weight { get; set; }
    }
}
