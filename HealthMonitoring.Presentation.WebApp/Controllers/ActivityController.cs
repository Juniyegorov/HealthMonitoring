using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
    public class ActivityController : Controller
    {
        private IExercisesService _exerciseService;
        public ActivityController(IExercisesService exerciseService)
        {
            _exerciseService = exerciseService;
        }
        public IActionResult AllActivities()
        {            
            var allActivities = _exerciseService.GetAllExercises();
            var allActivitiesView = new List<ActivitiesViewModel>();
            foreach (var activ in allActivities)
            {
                allActivitiesView.Add(new ActivitiesViewModel { Name = activ.Name });
            }
            return View(allActivitiesView);
        }
    }
}
