using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DAL.Models;
using DAL.Data;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> Logger;

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }

        public IActionResult LocationPage()
        {
            HttpContext.Session.SetInt32("LandingPage", 1);
            return View();
        }

        [HttpPost]
        public IActionResult LocationPage(string SelectedCity)
        {
            
            if (!string.IsNullOrEmpty(SelectedCity))
            {
                HttpContext.Session.SetInt32("LandingPage", 0);
                return RedirectToAction("HomePage", new { city = SelectedCity });
            }

            ViewBag.Message = "Please select a city.";
            return View();
        }
        public IActionResult HomePage(string city)
        {
            ViewBag.City = city;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HomePage(RentalDetail rdModel)
        {
            rdModel.RentalDuration = (rdModel.ToDateTime - rdModel.FromDateTime).TotalHours;
            HttpContext.Session.SetInt32("duration", (int)Math.Round((double)rdModel.RentalDuration));
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
