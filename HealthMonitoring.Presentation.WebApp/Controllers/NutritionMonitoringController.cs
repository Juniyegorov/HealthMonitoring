using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
    [Authorize]
    public class NutritionMonitoringController : Controller
    {
        private IDishServices _dishServices;
        private IUserServices _userServices;
        public NutritionMonitoringController(IUserServices userServices, IDishServices dishServices)
        {
            _dishServices = dishServices;
            _userServices = userServices;
        }
        [HttpGet]
        public IActionResult Control()
        {
            var dishes = _dishServices.ToList();            
            var userLogin = HttpContext.User.Claims.Where(u => u.Type == "Login").Select(u => u.Value).FirstOrDefault();
            var userInfo = _userServices.GetUserInformation(userLogin);
            var eatenDish = _dishServices.EatenDishByUserId(userInfo.Id);

            var model = new RationControlViewModel();
            model.EatenDishes = new List<EatenDishViewModel>();
            model.DishesName = new List<string>();
            foreach (var dish in dishes)
            {
                model.DishesName.Add(dish.Name);
            }
            foreach (var eat in eatenDish)
            {
                model.EatenDishes.Add(new EatenDishViewModel
                {
                    Name = eat.Name,
                    Calories = eat.Calories,
                    Date = eat.Date,
                    Weight = eat.Weight
                });
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Control(EatenDishViewModel model)
        {
            var userLogin = HttpContext.User.Claims.Where(u => u.Type == "Login").Select(u => u.Value).FirstOrDefault();
            var userInfo = _userServices.GetUserInformation(userLogin);
            _dishServices.EatenDish(model.Name, model.Weight, model.Date, userInfo.Id);
            return RedirectToAction("Control");
        }
    }
}
