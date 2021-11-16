using AutoMapper;
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
    public class DishController : ControllerBase
    {
        private IDishServices _dishServices;
        private IUserServices _userServices;
        private IMapper _mapper;

        public DishController(IDishServices dishServices, IUserServices userServices, IMapper mapper)
        {
            _dishServices = dishServices;
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDishes()
        {
            var dishes = _dishServices.ToList();
            return Ok(dishes);
        }

        [HttpGet]
        public IActionResult GetAllEatenDishes()
        {
            var userLogin = User.FindFirst(ClaimTypes.Name).Value;
            var user = _userServices.GetUserInformation(userLogin);
            var dishes = _dishServices.EatenDishByUserId(user.Id);
            var mapped = _mapper.Map<List<EatenDish>>(dishes);
            return Ok(mapped);
        }

        [HttpPost]
        public IActionResult AddEatenDish([FromBody] EatenDish model)
        {
            if (ModelState.IsValid)
            {
                var userLogin = User.FindFirst(ClaimTypes.Name).Value;
                var user = _userServices.GetUserInformation(userLogin);
                _dishServices.EatenDish(model.Name, model.Weight, model.Date, user.Id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
