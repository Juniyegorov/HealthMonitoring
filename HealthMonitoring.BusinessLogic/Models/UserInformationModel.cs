using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Models
{
    public class UserInformationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
    }
}
