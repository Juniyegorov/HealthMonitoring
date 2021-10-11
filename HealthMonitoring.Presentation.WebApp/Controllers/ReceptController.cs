using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
    public class ReceptController : Controller
    {
        private IDishServices _dishServices;
        private List<DishViewModel> _dishes;
        public ReceptController(IDishServices dishServices)
        {
            _dishServices = dishServices;
            _dishes = new List<DishViewModel>();
        }
        public IActionResult Dishes()
        {
            UpdateDishesList();
            return View(_dishes);
        }
        private void UpdateDishesList()
        {
            var dishes = _dishServices.ToList();
            foreach (var dish in dishes)
            {
                var dishComponents = _dishServices.GetDishComponents(dish.Id);
                var dishCharact = _dishServices.GetDish(dish.Id);
                var products = new List<ProductDTO>();
                foreach (var comp in dishComponents)
                {
                    products.Add(new ProductDTO
                    {
                        Name = comp.Name,
                        Weight = comp.Weight,
                        Calories = comp.Calories
                    });
                }
                _dishes.Add(new DishViewModel
                {
                    Id = dish.Id,
                    Name = dish.Name,
                    Calories = dishCharact.Calories,
                    Weight = dishCharact.Weight,
                    Products = products                    
                });
            }
        }
    }
}
