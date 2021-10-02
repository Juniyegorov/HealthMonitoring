using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.DataModels
{
    public class UserInformationDataModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public int Id { get; set; }
    }
}
