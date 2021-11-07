using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Services;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private IExercisesService _exerciseService;
        private IUserServices _userServices;
        private CaloriesExpensesServices _caloriexExpensis;
        public ActivityController(IExercisesService exerciseService, IUserServices userServices, CaloriesExpensesServices caloriexExpensis)
        {
            _exerciseService = exerciseService;
            _userServices = userServices;
            _caloriexExpensis = caloriexExpensis;
        }

        [HttpGet]
        public IActionResult ActivitiesControl()
        {
            var model = CreateExtendedExerciseViewModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult ActivitiesControl(CompletedExerciseViewModel model)
        {
            var userLogin = User.FindFirst(ClaimTypes.Name).Value;
            var userInfo = _userServices.GetUserInformation(userLogin);

            if (ModelState.IsValid && userInfo.Name != null)
            {
                var calories = _caloriexExpensis.BurnedCalories(model.DistanceTraveled, model.ExpendedTime, userInfo.Weight, userInfo.Growth, model.Exercise);
                var completedExercise = new CompletedExerciseModel
                {
                    Date = model.Date,
                    DistanceTraveled = model.DistanceTraveled,
                    Exercise = model.Exercise,
                    ExpendedTime = model.ExpendedTime,
                    UserLogin = userLogin,
                    ExpendedCalories = calories
                };
                _exerciseService.AddCompletedExercise(completedExercise);
                return RedirectToAction("ActivitiesControl");
            }
            return NoContent();
        }
        private ExtendedExerciseViewModel CreateExtendedExerciseViewModel()
        {
            var userLogin = User.FindFirst(ClaimTypes.Name).Value;
            var allExercises = _exerciseService.GetAllExercises();

            var allActivities = new List<ExerciseViewModel>();
            var allCompletedExercises = new List<CompletedExerciseViewModel>();

            var userInfo = _userServices.GetUserInformation(userLogin);
            var completedExercises = _exerciseService.AllCompletedExercise(userInfo.Id);

            foreach (var activ in allExercises)
            {
                allActivities.Add(new ExerciseViewModel { Name = activ.Name, Id = activ.Id });
            }
            foreach (var completedEx in completedExercises)
            {
                allCompletedExercises.Add(new CompletedExerciseViewModel
                {
                    Date = completedEx.Date,
                    DistanceTraveled = completedEx.DistanceTraveled,
                    Exercise = completedEx.Exercise,
                    ExpendedCalories = completedEx.ExpendedCalories,
                    ExpendedTime = completedEx.ExpendedTime
                });
            }

            var viewModel = new ExtendedExerciseViewModel
            {
                CompletedExercises = allCompletedExercises,
                Exercises = allActivities
            };
            return viewModel;
        }
    }
}
