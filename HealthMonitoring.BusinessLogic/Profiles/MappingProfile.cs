using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserInformationDataModel, UserInformationModel>();
            CreateMap<UserInformationModel, UserInformationDataModel>();
            CreateMap<CategoriesOfProductModel, CategoriesOfProductDataModel>();
            CreateMap<CategoriesOfProductDataModel, CategoriesOfProductModel>();
            CreateMap<ProductModel, ProductDataModel>();
            CreateMap<ProductDataModel, ProductModel>();
            CreateMap<CompositionOfTheDishModel, CompositionOfTheDish>();
            CreateMap<CompositionOfTheDish, CompositionOfTheDishModel>();
            CreateMap<CharacteristicsOfTheDishModel, CharacteristicsOfTheDish>();
            CreateMap<CharacteristicsOfTheDish, CharacteristicsOfTheDishModel>();
            CreateMap<DishModel, Dish>();
            CreateMap<Dish, DishModel>();
            CreateMap<EatenDish, EatenDishModel>();
            CreateMap<EatenDishModel, EatenDish>();
            CreateMap<ExerciseModel, ExerciseDataModel>();
            CreateMap<ExerciseDataModel, ExerciseModel>();
            CreateMap<CompletedExercise, CompletedExerciseModel>();
            CreateMap<CompletedExerciseModel, CompletedExercise>();
            CreateMap<CompletedExerciseDataModel, CompletedExerciseModel>();
            CreateMap<CompletedExerciseModel, CompletedExerciseDataModel>();
            CreateMap<DishComponentsDataModel, DishComponentsModel>();
            CreateMap<DishComponentsModel, DishComponentsDataModel>();
            CreateMap<EatenDishDTO, EatenDishDataModel>();
            CreateMap<EatenDishDataModel, EatenDishDTO>();
        }
    }
}
