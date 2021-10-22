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
        private IUserRepository _userRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        IMapper _mapper;

        public ExercisesService()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _exercisesRepository = new ExercisesRepository(_healthMonitoringContext);
            _userRepository = new UserRepository(_healthMonitoringContext);
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
            var exerciseId = _exercisesRepository.ExerciseId(completedExercise.Exercise);
            var user = _userRepository.GetUserInformation(completedExercise.UserLogin);
            var exercise = new CompletedExercise
            {
                Date = completedExercise.Date,
                DistanceTraveled = completedExercise.DistanceTraveled,
                ExpendedCalories = completedExercise.ExpendedCalories,
                ExpendedTime = completedExercise.ExpendedTime,
                ExerciseId = exerciseId,
                UserId = user.Id
            };
            _exercisesRepository.AddCompletedExercise(exercise);
            _healthMonitoringContext.SaveChanges();
        }
        public List<CompletedExerciseModel> AllCompletedExercise(int id)
        {
            var allExercises = _exercisesRepository.AllCompletedExercise(id);
            var mapped = new List<CompletedExerciseModel>();
            foreach (var ex in allExercises)
            {
                mapped.Add(_mapper.Map<CompletedExerciseModel>(ex));
            }
            return mapped;
        }
    }
}
