using HealthMonitoring.DataAccessLayer.DataModels;
using HealthMonitoring.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.DataAccessLayer.Repositories
{
    public class CaloriesRepository
    {
        private HealthMonitoringContext _healthMonitoringContext;
        public CaloriesRepository(HealthMonitoringContext healthMonitoringContext)
        {
            _healthMonitoringContext = healthMonitoringContext;
        }
        public int GetExpendedDayCalories(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var expended = _healthMonitoringContext.CompletedExercises.
                Where(e => e.UserId == userId && e.Date == dateTime).
                Select(e => e.ExpendedCalories).ToList();
            int calories = 0;
            foreach (var e in expended)
            {
                calories += e;
            }
            return calories;
        }
        public int GetReceivedDayCalories(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var expended = _healthMonitoringContext.EatenDishes.
                Where(e => e.UserId == userId && e.Date == dateTime).
                Select(e => e.Calories).ToList();
            int calories = 0;
            foreach (var e in expended)
            {
                calories += e;
            }
            return calories;
        }
        public List<ExpendedCaloriesDataModel> GetAllExpendedCalories(int userId)
        {
            var expended = _healthMonitoringContext.CompletedExercises.
                Where(e => e.UserId == userId).Select(e => new ExpendedCaloriesDataModel
                {
                    Date = e.Date,
                    ExpendedCalories = e.ExpendedCalories
                }).ToList();
            return expended;
        }
        public List<ReceivedCaloriesDataModel> GetAllReceivedCalories(int userId)
        {
            var expended = _healthMonitoringContext.EatenDishes.
                Where(e => e.UserId == userId).Select(e => new ReceivedCaloriesDataModel
                {
                    Date = e.Date,
                    ReceivedCalories = e.Calories
                }).ToList();
            return expended;
        }
    }
}
