using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using webApplication.Models;

namespace webApplication.Controllers
{
    public class CarListingController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to inject the ApplicationDbContext
        public CarListingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult CarsListingPagePremium()
        {
            IEnumerable<CarDetails> carDetails = _context.CarDetails.ToList();
            return View(carDetails);
        }


        public IActionResult CarsListingPage()
        {
            return View();
        }

        public IActionResult ConfirmBookingPage()
        {
            return View();
        }

        public IActionResult CarBookingPage(int id)
        {
            var car = _context.CarDetails.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult CarBookingPage()
        {

            var carModel = new RentalDetails
            {
                FromDateTime = TempData["FromDateTime"] != null ? (DateTime)TempData["FromDateTime"] : DateTime.Now,
                ToDateTime = TempData["ToDateTime"] != null ? (DateTime)TempData["ToDateTime"] : DateTime.Now,
                RentalDuration = HttpContext.Session.GetInt32("duration") ?? 0,
                Location = TempData["Location"] != null ? TempData["Location"].ToString() : string.Empty,
                UserId = HttpContext.Session.GetInt32("UserId") ?? 0,
                CarId = HttpContext.Session.GetInt32("CarId") ?? 0
            };
            _context.RentalDetails.Add(carModel);
            return View(carModel);
        }
    }
}
