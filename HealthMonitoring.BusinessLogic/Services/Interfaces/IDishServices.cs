using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Models.ParameterModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services.Interfaces
{
    public interface IDishServices
    {
        void AddDish(string dishName);
        void AddCompositionOfTheDish(CompositionOfTheDishModel compositionOfTheDishModel);
        void AddCharacteristicsOfTheDish(CharacteristicsOfTheDishModel characteristicsOfTheDishModel);
        int GetDishId(string dishName);
        List<DishModel> ToList();
        CharacteristicsOfTheDishModel GetDish(int id);
        void EatenDish(EatenDishModel eatenDishModel);
        void EatenDish(string dishName, int weight, DateTime date, int userid);
        List<DishComponentsModel> GetDishComponents(int id);
        void AddDish(string dishName, List<CompositionOfTheDishParameterModel> compositionOfTheDishParameterModels);
        List<EatenDishDTO> EatenDishByUserId(int userId);
    }
}
