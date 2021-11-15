using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Models.ParameterModels;
using HealthMonitoring.BusinessLogic.Profiles;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.ParameterModels;
using HealthMonitoring.DataAccessLayer.Repositories;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class DishServices : IDishServices
    {
        private IDishRepository _dishRepository;
        private IProductRepository _productRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        IMapper _mapper;

        public DishServices()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _productRepository = new ProductRepository(_healthMonitoringContext);
            _dishRepository = new DishRepository(_healthMonitoringContext);
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }

        public void AddDish(string dishName)
        {
            var dish = new CreateDishParameterModel() { Name = dishName };
            _dishRepository.AddDish(dish);
            _healthMonitoringContext.SaveChanges();
        }

        public void AddDish(string dishName, List<CompositionOfTheDishParameterModel> compositionOfTheDishParameterModels)
        {
            var products = _productRepository.GetAllProducts();
            var dishComposition = new List<CompositionOfTheDish>();
            var charactcharacteristicsOfTheDish = new CharacteristicsOfTheDishModel
            {
                Calories = 0,
                Weight = 0
            };

            foreach (var prod in compositionOfTheDishParameterModels)
            {
                var product = products.Where(p => p.Name == prod.Name).FirstOrDefault();
                var composition = new CompositionOfTheDish
                {
                    Count = prod.Weight,
                    ProductId = product.Id,
                    Calories = product.Calories * prod.Weight / 100
                };
                charactcharacteristicsOfTheDish.Calories += composition.Calories;
                charactcharacteristicsOfTheDish.Weight += composition.Count;
                dishComposition.Add(composition);
            }
            var mappedCharact = _mapper.Map<CharacteristicsOfTheDish>(charactcharacteristicsOfTheDish);

            if (dishComposition.Count > 0)
            {
                _dishRepository.CreateDish(dishName, mappedCharact, dishComposition);
                _healthMonitoringContext.SaveChanges();
            }
        }
        public void AddCompositionOfTheDish(CompositionOfTheDishModel compositionOfTheDishModel)
        {
            var mappedDish = _mapper.Map<CompositionOfTheDish>(compositionOfTheDishModel);
            _dishRepository.AddCompositionOfTheDish(mappedDish);
            _healthMonitoringContext.SaveChanges();
        }
        public void AddCharacteristicsOfTheDish(CharacteristicsOfTheDishModel characteristicsOfTheDishModel)
        {
            var mapped = _mapper.Map<CharacteristicsOfTheDish>(characteristicsOfTheDishModel);
            _dishRepository.AddCharacteristicsOfTheDish(mapped);
            _healthMonitoringContext.SaveChanges();
        }
        public int GetDishId(string dishName)
        {
            var dishId = _dishRepository.GetDishId(dishName);
            return dishId;
        }
        public List<DishModel> ToList()
        {
            var dishes = _dishRepository.ToList();
            List<DishModel> dishModels = new List<DishModel>();
            foreach (var i in dishes)
            {
                var mapped = _mapper.Map<DishModel>(i);
                dishModels.Add(mapped);
            }
            return dishModels;
        }
        public void EatenDish(EatenDishModel eatenDishModel)
        {
            var mapped = _mapper.Map<EatenDish>(eatenDishModel);
            _dishRepository.EatenDish(mapped);
            _healthMonitoringContext.SaveChanges();
        }
        public void EatenDish(string dishName, int weight, DateTime date, int userid)
        {
            _dishRepository.EatenDish(dishName, weight, date, userid);
            _healthMonitoringContext.SaveChanges();
        }
        public CharacteristicsOfTheDishModel GetDish(int id)
        {
            var dish = _dishRepository.GetDish(id);
            var mapped = _mapper.Map<CharacteristicsOfTheDishModel>(dish);
            return mapped;
        }
        public List<DishComponentsModel> GetDishComponents(int id)
        {
            List<DishComponentsModel> dishComponents = new List<DishComponentsModel>();
            var components = _dishRepository.GetDishComponents(id);
            foreach (var component in components)
            {
                var mapped = _mapper.Map<DishComponentsModel>(component);
                dishComponents.Add(mapped);
            }
            return dishComponents;
        }
        public List<EatenDishDTO> EatenDishByUserId(int userId)
        {
            var mapped = new List<EatenDishDTO>();
            var eatenDishes = _dishRepository.EatenDishByUserId(userId);
            foreach (var dish in eatenDishes)
            {
                var map = _mapper.Map<EatenDishDTO>(dish);
                mapped.Add(map);
            }
            return mapped;
        }
    }
}
