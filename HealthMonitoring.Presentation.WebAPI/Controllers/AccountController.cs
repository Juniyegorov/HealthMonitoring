using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebAPI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class AccountController : ControllerBase
    {
        private IUserServices _userServices;
        private string _message;
        public AccountController(IUserServices userServises)
        {
            _userServices = userServises;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool user = _userServices.CheckUser(model.Login, model.Password);
                if (user)
                {
                    Authenticate(model.Login);
                    return Ok();
                }
                ModelState.AddModelError("msg", "Incorrect login and (or) password");
                return BadRequest(ModelState);
            }
            else
            {
                return BadRequest(ModelState);
            }            
        }

        [HttpPost]
        public IActionResult Register([FromBody] LoginModel model)
        {
            Action<string> action = AddMessageEror;
            _userServices.RegisterUser(model.Login, model.Password, action);
            if (_message == "Registration successful")
            {
                Authenticate(model.Login);
                return Ok(_message);
            }
            else
            {
                return BadRequest(_message);
            }
        }

        [Authorize]
        public  IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        private void Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        private void AddMessageEror(string message)
        {
            ModelState.AddModelError("", message);
            _message = message;
        }
    }
}
