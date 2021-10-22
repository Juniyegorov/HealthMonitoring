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
        public List<CompletedExerciseDataModel> AllCompletedExercise(int id)
        {
            var completedExercises = (from c in _healthMonitoringContext.CompletedExercises
                                     join e in _healthMonitoringContext.Exercises on c.ExerciseId equals e.Id
                                     where c.UserId == id
                                     select new CompletedExerciseDataModel
                                     {
                                         Date = c.Date,
                                         DistanceTraveled = c.DistanceTraveled,
                                         Exercise = e.Name,
                                         ExpendedCalories = c.ExpendedCalories,
                                         ExpendedTime = c.ExpendedTime
                                     }).ToList();
            return completedExercises;
        }
        public int ExerciseId(string exercise)
        {
            var id = _healthMonitoringContext.Exercises.Where(e => e.Name == exercise).Select(e=>e.Id).FirstOrDefault();
            return id;
        }
    }
}
