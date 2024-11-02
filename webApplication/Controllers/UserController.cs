using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

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
                await UserService.AddUserAsync(user); // Use the service to add user
                HttpContext.Session.SetInt32("UserId", user.UserId);
                return RedirectToAction("ExtraDetails", new { id = user.UserId });
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ExtraDetails(int id)
        {
            var user = await UserService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new ExtraDetailsViewModel
            {
                Address = user.Address,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber ?? 0,
                AlternatePhoneNumber = user.AlternatePhoneNumber ?? 0
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ExtraDetails(int id, ExtraDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the user from the service
                var user = await UserService.GetUserByIdAsync(id);
                if (user == null)
                { 
                    return NotFound();
                }

                // Map ExtraDetailsViewModel data back to User
                user.Address = model.Address;
                user.Email = model.Email;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.AlternatePhoneNumber = model.AlternatePhoneNumber;
                user.UserType = "User";

                await UserService.UpdateUserAsync(id, user);
                return RedirectToAction("RegistrationSuccessPage"); 
            }

            return View();
        }

        public IActionResult RegistrationSuccessPage()
        {
            return View();
        }

    }
}
