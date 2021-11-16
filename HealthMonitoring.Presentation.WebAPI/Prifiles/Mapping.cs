using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.Presentation.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebAPI.Prifiles
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EatenDishDTO, EatenDish>().ReverseMap();
        }
    }
}
