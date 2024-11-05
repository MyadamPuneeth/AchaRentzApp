using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.Data;

namespace PresentationLayer.Controllers
{
    public class CarListingController : Controller
    {
        private readonly AppDbContext Context;

        // Constructor to inject the ApplicationDbContext
        public CarListingController(AppDbContext context)
        {
            Context = context;
        }

        public IActionResult CarsListingPagePremium()
        {
            IEnumerable<CarDetail> CarDetail = Context.CarDetail.ToList();
            if(CarDetail == null)
            {
                return View(CarDetail);
            }
            return View(CarDetail);
        }
                
        /*public IActionResult CarsListingPage()
        {
            return View();
        }*/

        public IActionResult CarBookingPage(int id)
        {
            var car = Context.CarDetail.FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public IActionResult CarBookingPage()
        {

            var carModel = new RentalDetail
            {
                FromDateTime = TempData["FromDateTime"] != null ? (DateTime)TempData["FromDateTime"] : DateTime.Now,
                ToDateTime = TempData["ToDateTime"] != null ? (DateTime)TempData["ToDateTime"] : DateTime.Now,
                RentalDuration = HttpContext.Session.GetInt32("duration") ?? 0,
                Location = TempData["Location"] != null ? TempData["Location"].ToString() : string.Empty,
                UserId = HttpContext.Session.GetInt32("UserId") ?? 0,
                CarId = HttpContext.Session.GetInt32("CarId") ?? 0
            };
            Context.RentalDetails.Add(carModel);
            return View(carModel);
        }
    }
}
