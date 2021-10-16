using AutoMapper;
using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Profiles;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class ExercisesService : IExercisesService
    {
        private IExercisesRepository _exercisesRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        IMapper _mapper;

        public ExercisesService()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _exercisesRepository = new ExercisesRepository(_healthMonitoringContext);
            var config = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            _mapper = mapper;
        }
        public List<ExerciseModel> GetAllExercises()
        {
            var exercises = _exercisesRepository.GetAllExercises();
            List<ExerciseModel> exerciseModels = new List<ExerciseModel>();
            foreach (var e in exercises)
            {
                var mapped = _mapper.Map<ExerciseModel>(e);
                exerciseModels.Add(mapped);
            }
            return exerciseModels;
        }
        public void AddCompletedExercise(CompletedExerciseModel completedExercise)
        {
            var mapped = _mapper.Map<CompletedExercise>(completedExercise);
            _exercisesRepository.AddCompletedExercise(mapped);
            _healthMonitoringContext.SaveChanges();
        }
    }
}
