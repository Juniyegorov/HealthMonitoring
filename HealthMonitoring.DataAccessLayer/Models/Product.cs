using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class Product
    {
        public Product()
        {
            CompositionOfTheDishes = new HashSet<CompositionOfTheDish>();
            EatenProducts = new HashSet<EatenProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Calories { get; set; }
        public int CategoryOfProductId { get; set; }

        public virtual CategoriesOfProduct CategoryOfProduct { get; set; }
        public virtual ICollection<CompositionOfTheDish> CompositionOfTheDishes { get; set; }
        public virtual ICollection<EatenProduct> EatenProducts { get; set; }
    }
}
