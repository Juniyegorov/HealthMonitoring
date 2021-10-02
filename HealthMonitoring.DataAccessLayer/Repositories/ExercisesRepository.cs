using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories
{
    public class ExercisesRepository : IExercisesRepository
    {
        private HealthMonitoringContext _healthMonitoringContext;
        public ExercisesRepository(HealthMonitoringContext healthMonitoringContext)
        {
            _healthMonitoringContext = healthMonitoringContext;
        }
        public List<ExerciseDataModel> GetAllExercises()
        {
            var exercises = _healthMonitoringContext.Exercises.Select(e => new ExerciseDataModel
            {
                Id = e.Id,
                Name = e.Name
            }).ToList();
            return exercises;
        }
        public void AddCompletedExercise(CompletedExercise completedExercise)
        {
            _healthMonitoringContext.Add(completedExercise);
        }
    }
}
