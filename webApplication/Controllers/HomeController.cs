using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using webApplication.Filters;
using webApplication.Models;
using System;
using Newtonsoft.Json;

namespace webApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HomePage(RentalDetails rdModel)
        {
            rdModel.RentalDuration = (rdModel.ToDateTime - rdModel.FromDateTime).TotalHours;
            HttpContext.Session.SetInt32("duration", (int)Math.Round(rdModel.RentalDuration));
            TempData["ToDateTime"] = rdModel.ToDateTime;  
            TempData["FromDateTime"] = rdModel.FromDateTime; 
            TempData["Location"] = rdModel.Location;
            return RedirectToAction("CarsListingPagePremium", "CarListing");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
