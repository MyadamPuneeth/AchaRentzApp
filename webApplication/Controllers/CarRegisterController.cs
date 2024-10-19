using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApplication.Models;

namespace webApplication.Controllers
{
    public class CarRegisterController : Controller
    {
        private readonly AppDbContext _context;

        public CarRegisterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegisterACarPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterACarPage(CarDetails model)
        {
            if (ModelState.IsValid)
            {
                _context.CarDetails.Add(model); 
                await _context.SaveChangesAsync();
                return RedirectToAction("CarDetailsPage", new { id = model.CarId});
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CarDetailsPage(int id)
        {
            var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> CarDetailsPage(int id, CarDetails model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.CarDetails.SingleOrDefaultAsync(c => c.CarId == id);
                if (user != null)
                {
                    user.Address = model.Address;
                    user.PricePerDay = model.PricePerDay;
                    user.Status = model.Status;
                    user.CarCompany = model.CarCompany;

                    _context.SaveChanges();

                    return RedirectToAction("HomePage", "Home");
                }
                else
                {
                    return NotFound(); // Return 404 if the user was not found
                }
            }
            return View();
        }
    }
    
}
