using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class Dish
    {
        public Dish()
        {
            CharacteristicsOfTheDishes = new HashSet<CharacteristicsOfTheDish>();
            CompositionOfTheDishes = new HashSet<CompositionOfTheDish>();
            EatenDishes = new HashSet<EatenDish>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CharacteristicsOfTheDish> CharacteristicsOfTheDishes { get; set; }
        public virtual ICollection<CompositionOfTheDish> CompositionOfTheDishes { get; set; }
        public virtual ICollection<EatenDish> EatenDishes { get; set; }
    }
}
