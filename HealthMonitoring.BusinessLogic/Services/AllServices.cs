using HealthMonitoring.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class AllServices
    {
        public IUserServices UserServices { get; set; }
        public IDishServices DishServices { get; set; }
        public IExercisesService ExercisesService { get; set; }

        public AllServices(IUserServices userServices, IDishServices dishServices, IExercisesService exercisesService)
        {
            DishServices = dishServices;
            UserServices = userServices;
            ExercisesService = exercisesService;
        }
    }
}
