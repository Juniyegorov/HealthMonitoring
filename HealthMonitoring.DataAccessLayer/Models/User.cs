using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class User
    {
        public User()
        {
            CaloriesExpendedPerDays = new HashSet<CaloriesExpendedPerDay>();
            CaloriesReceivedPerDays = new HashSet<CaloriesReceivedPerDay>();
            CompletedExercises = new HashSet<CompletedExercise>();
            EatenDishes = new HashSet<EatenDish>();
            EatenProducts = new HashSet<EatenProduct>();
            UserCharacteristics = new HashSet<UserCharacteristic>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<CaloriesExpendedPerDay> CaloriesExpendedPerDays { get; set; }
        public virtual ICollection<CaloriesReceivedPerDay> CaloriesReceivedPerDays { get; set; }
        public virtual ICollection<CompletedExercise> CompletedExercises { get; set; }
        public virtual ICollection<EatenDish> EatenDishes { get; set; }
        public virtual ICollection<EatenProduct> EatenProducts { get; set; }
        public virtual ICollection<UserCharacteristic> UserCharacteristics { get; set; }
    }
}
