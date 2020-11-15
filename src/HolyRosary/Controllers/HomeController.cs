using System;
using Microsoft.AspNetCore.Mvc;

using HolyRosary.Services;

namespace HolyRosary.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly DateService dateService;
        private readonly RosaryService rosaryService;

        public HomeController(DateService dateService, RosaryService rosaryService)
        {
            this.rosaryService = rosaryService; 
            this.dateService = dateService;
        }

        [Route("{date:datetime?}")]
        public IActionResult Index(DateTime? date)
        {
            if(date == null)
            {
                date = dateService.GetToday();
            }

            var viewModel = rosaryService.GetRosaryForDay(date);
            return View(viewModel);
        }
    }
}
