using HealthMonitoring.BusinessLogic.Models;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HealthMonitoring.Presentation.WebAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ActivityController : ControllerBase
    {
        private IExercisesService _exercisesService;
        private IUserServices _userServices;

        public ActivityController(IExercisesService exercisesService, IUserServices userServices)
        {
            _exercisesService = exercisesService;
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetExercises()
        {
            var exercises = _exercisesService.GetAllExercises();
            return Ok(exercises);
        }

        [HttpGet]
        public IActionResult GetAllCompletedExercises()
        {
            var userLogin = User.FindFirst(ClaimTypes.Name).Value;
            var userInfo = _userServices.GetUserInformation(userLogin);
            var exercises = _exercisesService.AllCompletedExercise(userInfo.Id);
            return Ok(exercises);
        }

        [HttpPost]
        public IActionResult AddCompletExercise([FromBody]CompletedExercise model)
        {
            if (ModelState.IsValid)
            {
                var completedExercise = new CompletedExerciseModel
                {
                    Date = model.Date,
                    DistanceTraveled = model.DistanceTraveled,
                    Exercise = model.Exercise,
                    ExpendedCalories = model.ExpendedCalories,
                    ExpendedTime = model.ExpendedTime,
                    UserLogin = User.FindFirst(ClaimTypes.Name).Value
                };
                _exercisesService.AddCompletedExercise(completedExercise);
                return Ok();
            }

            return BadRequest(ModelState);
        }
    }
}
