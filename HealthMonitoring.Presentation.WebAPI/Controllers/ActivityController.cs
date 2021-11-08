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
        public ActivityController(IExercisesService exercisesService)
        {
            _exercisesService = exercisesService;
        }

        [HttpGet]
        public IEnumerable<object> GetExercises()
        {
            var exercises = _exercisesService.GetAllExercises();
            return exercises;
        }

        [HttpGet("{id}")]
        public IEnumerable<object> GetExercises(int id)
        {
            var exercises = _exercisesService.GetAllExercises().Where(e=>e.Id == id);
            return exercises;
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
