using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.DataModels
{
    public class ProductDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Calories { get; set; }
        public int CategoryOfProductId { get; set; }
    }
}
