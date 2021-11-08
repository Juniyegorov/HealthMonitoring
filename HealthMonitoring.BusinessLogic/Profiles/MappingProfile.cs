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
            CreateMap<UserInformationDataModel, UserInformationModel>().ReverseMap();
            CreateMap<CategoriesOfProductModel, CategoriesOfProductDataModel>().ReverseMap();
            CreateMap<ProductModel, ProductDataModel>().ReverseMap();
            CreateMap<CompositionOfTheDishModel, CompositionOfTheDish>().ReverseMap();
            CreateMap<CharacteristicsOfTheDishModel, CharacteristicsOfTheDish>().ReverseMap();
            CreateMap<DishModel, Dish>().ReverseMap();
            CreateMap<EatenDish, EatenDishModel>().ReverseMap();
            CreateMap<ExerciseModel, ExerciseDataModel>().ReverseMap();
            CreateMap<CompletedExercise, CompletedExerciseModel>().ReverseMap();
            CreateMap<CompletedExerciseDataModel, CompletedExerciseModel>().ReverseMap();
            CreateMap<DishComponentsDataModel, DishComponentsModel>().ReverseMap();
            CreateMap<EatenDishDTO, EatenDishDataModel>().ReverseMap();
        }
    }
}
