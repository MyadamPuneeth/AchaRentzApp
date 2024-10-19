using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webApplication.Controllers
{
    public class CarListingController : Controller
    { 
        public IActionResult CarsListingPagePremium()
        {
            return View();
        }

        
        public IActionResult CarsListingPage()
        {
            return View();
        }
    }
}
