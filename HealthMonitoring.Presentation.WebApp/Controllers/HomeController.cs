using HealthMonitoring.BusinessLogic.Services;
using HealthMonitoring.BusinessLogic.Services.Interfaces;
using HealthMonitoring.Presentation.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthMonitoring.Presentation.WebApp.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		private CaloriesService _caloriesService;
		private IUserServices _userServices;

		public HomeController(CaloriesService caloriesService, IUserServices userServices)
        {
			_caloriesService = caloriesService;
			_userServices = userServices;
        }

		public IActionResult Index()
		{
			var userLogin = User.FindFirst(ClaimTypes.Name).Value;
			var user = _userServices.GetUserInformation(userLogin);

			var receivedCalories = _caloriesService.GetAllReceivedCaloriesDate(user.Id);
			var expendedCalories = _caloriesService.GetAllExpendedCaloriesDate(user.Id);

			List<DataPoint> dataPointsReceived = new List<DataPoint>();
			List<DataPoint> dataPointsExpended = new List<DataPoint>();

			Dictionary<int, List<DataPoint>> received = new Dictionary<int, List<DataPoint>>();
			Dictionary<int, List<DataPoint>> expended = new Dictionary<int, List<DataPoint>>();

            if (receivedCalories.Count > 0)
			{
				int lastYearReceived = receivedCalories[0].Year;
				foreach (var date in receivedCalories)
				{
					if (lastYearReceived == date.Year)
					{
						var month = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(date.Month);
						dataPointsReceived.Add(new DataPoint(month, date.Calories));
						if (date == receivedCalories[receivedCalories.Count - 1])
						{
							received.Add(lastYearReceived, dataPointsReceived);
						}
					}
					else
					{
						received.Add(lastYearReceived, dataPointsReceived);
						dataPointsReceived = new List<DataPoint>();
						lastYearReceived = date.Year;
						var month = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(date.Month);
						dataPointsReceived.Add(new DataPoint(month, date.Calories));
						if (date == receivedCalories[receivedCalories.Count - 1])
						{
							received.Add(lastYearReceived, dataPointsReceived);
						}
					}
				}
			}

            if (expendedCalories.Count > 0)
            {
				int lastYearExpended = expendedCalories[0].Year;
				foreach (var date in expendedCalories)
				{
					if (lastYearExpended == date.Year)
					{
						var month = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(date.Month);
						dataPointsExpended.Add(new DataPoint(month, date.Calories));
						if (date == expendedCalories[expendedCalories.Count - 1])
						{
							expended.Add(lastYearExpended, dataPointsExpended);
						}
					}
					else
					{
						expended.Add(lastYearExpended, dataPointsExpended);
						dataPointsExpended = new List<DataPoint>();
						lastYearExpended = date.Year;
						var month = CultureInfo.GetCultureInfo("en-US").DateTimeFormat.GetMonthName(date.Month);
						dataPointsExpended.Add(new DataPoint(month, date.Calories));
						if (date == expendedCalories[expendedCalories.Count - 1])
						{
							expended.Add(lastYearExpended, dataPointsExpended);
						}
					}
				}
			}
			
			Dictionary<int, List<DataPoint>>[] model = { received, expended };
			ViewBag.DataPoints = JsonConvert.SerializeObject(model);
			return View(model);
		}
	}
}