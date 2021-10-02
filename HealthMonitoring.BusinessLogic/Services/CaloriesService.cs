using HealthMonitoring.DataAccessLayer.Models;
using HealthMonitoring.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthMonitoring.BusinessLogic.Services
{
    public class CaloriesService
    {
        private CaloriesRepository _caloriesRepository;
        private HealthMonitoringContext _healthMonitoringContext;
        public CaloriesService()
        {
            _healthMonitoringContext = new HealthMonitoringContext();
            _caloriesRepository = new CaloriesRepository(_healthMonitoringContext);
        }
        public int GetExpendedDayCalories(int userId)
        {
            int calories = _caloriesRepository.GetExpendedDayCalories(userId);
            return calories;
        }
        public int GetReceivedDayCalories(int userId)
        {
            int calories = _caloriesRepository.GetReceivedDayCalories(userId);
            return calories;
        }
        public int GetExpendedCaloriesPerWeek(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var expendedCalories = _caloriesRepository.GetAllExpendedCalories(userId).
                Where(e=>e.Date <= dateTime && e.Date > dateTime.AddDays(-7)).
                ToList();
            var groups = (from u in expendedCalories
                          group u by u.Date into g
                          select new
                          {
                              g.Key,
                              Count = g.Count()
                          }).ToList();
            int calories = 0;
            foreach (var e in expendedCalories)
            {
                calories += e.ExpendedCalories;
            }
            if (groups.Count != 0)
            {
                calories /= groups.Count;
            }
            return calories;
        }
        public int GetExpendedCaloriesPerYear(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var expendedCalories = _caloriesRepository.GetAllExpendedCalories(userId).
                Where(e => e.Date <= dateTime && e.Date > dateTime.AddDays(-365)).
                ToList();
            var groups = (from u in expendedCalories
                          group u by u.Date into g
                         select new
                         {
                             g.Key,
                             Count = g.Count()
                         }).ToList();
            int calories = 0;
            foreach (var e in expendedCalories)
            {
                calories += e.ExpendedCalories;
            }
            if (groups.Count != 0)
            {
                calories /= groups.Count;
            }
            return calories;
        }
        public int GetReceivedCaloriesPerWeek(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var receivedCalories = _caloriesRepository.GetAllReceivedCalories(userId).
                Where(e => e.Date <= dateTime && e.Date > dateTime.AddDays(-7)).
                ToList();
            var groups = (from u in receivedCalories
                          group u by u.Date into g
                          select new
                          {
                              g.Key,
                              Count = g.Count()
                          }).ToList();
            int calories = 0;
            foreach (var e in receivedCalories)
            {
                calories += e.ReceivedCalories;
            }
            if (groups.Count != 0)
            {
                calories /= groups.Count;
            }
            return calories;
        }
        public int GetReceivedCaloriesPerYear(int userId)
        {
            DateTime dateTime = DateTime.Now;
            var receivedCalories = _caloriesRepository.GetAllReceivedCalories(userId).
                Where(e => e.Date <= dateTime && e.Date > dateTime.AddDays(-365)).
                ToList();
            var groups = (from u in receivedCalories
                          group u by u.Date into g
                          select new
                          {
                              g.Key,
                              Count = g.Count()
                          }).ToList();
            int calories = 0;
            foreach (var e in receivedCalories)
            {
                calories += e.ReceivedCalories;
            }
            if (groups.Count != 0)
            {
                calories /= groups.Count;
            }
            return calories;
        }
    }
}
