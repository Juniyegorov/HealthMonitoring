using HealthMonitoring.BusinessLogic.Models.ParameterModels;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
    [Authorize]
    public class ReceptController : Controller
    {
        private IDishServices _dishServices;
        private IProductServices _productServices;
        private List<DishViewModel> _dishes;
        public ReceptController(IDishServices dishServices, IProductServices productServices)
        {
            _dishServices = dishServices;
            _productServices = productServices;
            _dishes = new List<DishViewModel>();
        }
        public IActionResult Dishes()
        {
            UpdateDishesList();
            return View(_dishes);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var products = _productServices.GetAllProductsName();
            return View(products);
        }
        [HttpPost]
        public IActionResult Create(ProductDTO[] products, string receptName)
        {
            List<CompositionOfTheDishParameterModel> parameterModels = new List<CompositionOfTheDishParameterModel>();
            foreach (var prod in products)
            {
                parameterModels.Add(new CompositionOfTheDishParameterModel
                {
                    Name = prod.Name,
                    Weight = prod.Weight
                });
            }
            _dishServices.AddDish(receptName, parameterModels);
            return RedirectToAction("Dishes", "Recept");
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
