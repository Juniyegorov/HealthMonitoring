using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.DataModels
{
    public class ReceivedCaloriesDataModel
    {
        public DateTime Date { get; set; }
        public int ReceivedCalories { get; set; }
    }
}
