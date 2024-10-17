using Microsoft.AspNetCore.Mvc;
using webApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
namespace webApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Display the form
        [HttpGet]
        public IActionResult RegistrationPage()
        {
            return View();
        }

        // POST: Save form data to the database
        [HttpPost]
        public async Task<IActionResult> RegistrationPage(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user); // Add user to the DbSet
                await _context.SaveChangesAsync(); // Save changes to the database
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("ExtraDetails", new {id = user.UserId}); // Redirect after successful save
            }
            return View(user); // Return the same view if model state is invalid
        }

        // Optionally create an Index view to list users (not required but useful)
        /*public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }*/

        // GET: Edit User (hardcoded id=1)
        [HttpGet]
        public async Task<IActionResult> ExtraDetails(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId ==id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Pass the user data to the Edit view
        }

        // POST: 
        [HttpPost]
        public async Task<IActionResult> ExtraDetails(int id, User model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == id);  // Fetch the user by id

                if (user != null) // Check if the user exists in the database
                {
                    // Update user details
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.AlternatePhoneNumber = model.AlternatePhoneNumber;

                    _context.SaveChanges(); // Save changes to the database

                    return RedirectToAction("HomePage", "Home"); // Redirect on successful update
                }
                else
                {
                    return NotFound(); // Return 404 if the user was not found
                }
            }

            return View(model); // Return the view with the model if validation fails
        }
    }
}


