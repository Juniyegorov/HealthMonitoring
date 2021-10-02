using HealthMonitoring.DataAccessLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<CategoriesOfProductDataModel> GetAllCategories();
        List<ProductDataModel> GetProductsByCategory(string category);
    }
}
