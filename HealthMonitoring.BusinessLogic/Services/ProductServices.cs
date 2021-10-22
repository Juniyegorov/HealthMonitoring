using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Profiles;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class ProductServices : IProductServices
    {
        private IProductRepository _productRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        IMapper _mapper;

        public ProductServices()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _productRepository = new ProductRepository(_healthMonitoringContext);
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }
        public List<CategoriesOfProductModel> GetAllCategories()
        {
            List<CategoriesOfProductModel> categoriesOfProductModels = new List<CategoriesOfProductModel>();
            var categoties = _productRepository.GetAllCategories();
            foreach (var caterory in categoties)
            {
                var mappedUserInformation = _mapper.Map<CategoriesOfProductModel>(caterory);
                categoriesOfProductModels.Add(mappedUserInformation);
            }
            return categoriesOfProductModels;
        }
        public List<ProductModel> GetProductsByCategory(string category)
        {
            List<ProductModel> productModels = new List<ProductModel>();
            var selectProducts = _productRepository.GetProductsByCategory(category);
            foreach (var product in selectProducts)
            {
                var mappedProducts = _mapper.Map<ProductModel>(product);
                productModels.Add(mappedProducts);
            }
            return productModels;
        }
        public List<ProductModel> GetAllProducts()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            var selectProducts = _productRepository.GetAllProducts();
            foreach (var product in selectProducts)
            {
                var mappedProducts = _mapper.Map<ProductModel>(product);
                productModels.Add(mappedProducts);
            }
            return productModels;
        }
        public List<string> GetAllProductsName()
        {
            var selectProducts = _productRepository.GetAllProductsName();
            return selectProducts;
        }
    }
}
