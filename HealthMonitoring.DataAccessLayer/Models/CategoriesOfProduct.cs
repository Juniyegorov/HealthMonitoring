using System;
using System.Collections.Generic;

#nullable disable

namespace HealthMonitoring.DataAccessLayer.Models
{
    public partial class CategoriesOfProduct
    {
        public CategoriesOfProduct()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
