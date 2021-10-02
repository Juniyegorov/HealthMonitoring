using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private HealthMonitoringContext _healthMonitoringContext;
        public ProductRepository(HealthMonitoringContext healthMonitoringContext)
        {
            _healthMonitoringContext = healthMonitoringContext;
        }
        public List<CategoriesOfProductDataModel> GetAllCategories()
        {
            var categoriesOfProductDataModels = (from c in _healthMonitoringContext.CategoriesOfProducts
                                      select new CategoriesOfProductDataModel
                                      {
                                          Id = c.Id,
                                          Name = c.Name
                                      }).ToList();
            return categoriesOfProductDataModels;
        }
        public List<ProductDataModel> GetProductsByCategory(string category)
        {
            var selectProducts = (from p in _healthMonitoringContext.Products
                                 join c in _healthMonitoringContext.CategoriesOfProducts on p.CategoryOfProductId equals c.Id
                                 where c.Name == category
                                 select new ProductDataModel
                                 {
                                     Id = p.Id,
                                     Calories = p.Calories,
                                     Name = p.Name,
                                     Weight = p.Weight,
                                     CategoryOfProductId = p.CategoryOfProductId
                                 }).ToList();
            return selectProducts;
        }
    }
}
