using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class UserCharacteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Growth { get; set; }
        public int Weight { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
