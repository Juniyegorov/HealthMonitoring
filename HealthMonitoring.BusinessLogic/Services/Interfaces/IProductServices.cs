using HealthMonitoring.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services.Interfaces
{
    public interface IProductServices
    {
        List<CategoriesOfProductModel> GetAllCategories();
        List<ProductModel> GetProductsByCategory(string category);
    }
}
