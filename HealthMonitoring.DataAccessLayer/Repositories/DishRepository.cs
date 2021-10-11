using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.ParameterModels;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories
{
    public class DishRepository : IDishRepository
    {
        private HealthMonitoringContext _healthMonitoringContext;
        public DishRepository(HealthMonitoringContext healthMonitoringContext)
        {
            _healthMonitoringContext = healthMonitoringContext;
        }
        public void AddDish(CreateDishParameterModel dish)
        {
            var dishEntity = new Dish
            {
                Name = dish.Name
            };

            _healthMonitoringContext.Dishes.Add(dishEntity);
        }
        public void AddCharacteristicsOfTheDish(CharacteristicsOfTheDish characteristicsOfTheDish)
        {
            _healthMonitoringContext.CharacteristicsOfTheDishes.Add(characteristicsOfTheDish);
        }
        public void AddCompositionOfTheDish(CompositionOfTheDish compositionOfTheDish)
        {
            _healthMonitoringContext.CompositionOfTheDishes.Add(compositionOfTheDish);
        }
        public int GetDishId(string dishName)
        {
            var dishId = _healthMonitoringContext.Dishes.Where(d => d.Name == dishName).Select(d=>d.Id).FirstOrDefault();
            return dishId;
        }
        public List<Dish> ToList()
        {
            var dishes = _healthMonitoringContext.Dishes.ToList();
            return dishes;
        }
        public void EatenDish(EatenDish eatenDish)
        {
            _healthMonitoringContext.EatenDishes.Add(eatenDish);
        }
        public CharacteristicsOfTheDish GetDish(int id)
        {
            CharacteristicsOfTheDish dish = _healthMonitoringContext.CharacteristicsOfTheDishes.
                Where(c => c.DishId == id).FirstOrDefault();
            return dish;
        }
        public List<DishComponentsDataModel> GetDishComponents(int id)
        {
            var dishComponents = (from c in _healthMonitoringContext.CompositionOfTheDishes
                     join p in _healthMonitoringContext.Products on c.ProductId equals p.Id
                     where c.DishId == id
                     select new DishComponentsDataModel
                     {
                         Name = p.Name,
                         Calories = c.Calories,
                         Weight = c.Count
                     }).ToList();
            return dishComponents;
        }
    }
}
