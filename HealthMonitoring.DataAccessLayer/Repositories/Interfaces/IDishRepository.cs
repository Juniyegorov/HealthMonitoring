using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.ParameterModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories.Interfaces
{
    public interface IDishRepository
    {
        void AddDish(CreateDishParameterModel dish);
        void AddCharacteristicsOfTheDish(CharacteristicsOfTheDish characteristicsOfTheDish);
        void AddCompositionOfTheDish(CompositionOfTheDish compositionOfTheDish);
        int GetDishId(string dishName);
        List<Dish> ToList();
        void EatenDish(EatenDish eatenDish);
        CharacteristicsOfTheDish GetDish(int id);
    }
}
