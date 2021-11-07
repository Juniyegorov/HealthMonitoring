using HealthMonitoring.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private IUserServices _userServices;

        UserInformationViewModel _viewModel;
        public SidebarViewComponent(IUserServices userServices, UserInformationViewModel viewModel)
        {
            _userServices = userServices;
            _viewModel = viewModel;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userLogin = User.Identity.Name;
                
                var userInformation = _userServices.GetUserInformation(userLogin);
                _viewModel.Name = userInformation.Name;
                _viewModel.Surname = userInformation.Surname;
                _viewModel.Height = userInformation.Growth;
                _viewModel.Weight = userInformation.Weight;
                return Task.FromResult((IViewComponentResult)View("Default", _viewModel));
            }
            return Task.FromResult((IViewComponentResult)View("Empty"));
        }
    }
}
