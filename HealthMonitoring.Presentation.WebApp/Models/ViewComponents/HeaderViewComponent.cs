using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Models.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private bool _authorize;
        public Task<IViewComponentResult> InvokeAsync()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                _authorize = true;
            } 
               
            return Task.FromResult((IViewComponentResult)View("Default", _authorize));
        }
    }
}
