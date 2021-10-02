using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.Presentation.WinForms.Models
{
    public class UserInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
    }
}
