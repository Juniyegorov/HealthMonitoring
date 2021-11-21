using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserServices _userServices;
        private string _message;
        public AccountController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registerSuccess = _userServices.RegisterUser(model.UserName, model.Password);
                if (registerSuccess)
                {
                    await Authenticate(model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "This login is taken");
                    return View();
                }
            }

            return View();
            
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            LoginViewModel model = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = GoogleDefaults.AuthorizationEndpoint              
            };
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                new { ReturnUrl = returnUrl });
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return new ChallengeResult(provider, properties);
        }

        [Authorize]
        public async Task<IActionResult> ExternalLoginCallback()
        {
            var userName = User.FindFirst(ClaimTypes.Email).Value;
            var user = _userServices.CheckUser(userName, "0");

            LoginViewModel model = new LoginViewModel
            {
                UserName = userName,
                Password = "0"
            };

            if (!user)
            {
                await Register(model);
            }
            else
            {
                await Login(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool user = _userServices.CheckUser(model.UserName, model.Password);
                if (user)
                {
                    await Authenticate(model.UserName);
 
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login and (or) password");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public IActionResult ChangePersonalInformation(UserInformationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userLogin = User.FindFirst(ClaimTypes.Name).Value;
                var userInformation = _userServices.GetUserInformation(userLogin);

                userInformation.Name = model.Name;
                userInformation.Surname = model.Surname;
                userInformation.Weight = model.Weight;
                userInformation.Growth = model.Height;

                _userServices.SetUserInformation(userInformation);
            }
            
            return NoContent();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
