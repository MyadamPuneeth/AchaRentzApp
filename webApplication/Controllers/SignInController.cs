using Microsoft.AspNetCore.Mvc;
using webApplication.Models;

public class SignInController : Controller
{
    private readonly AppDbContext _context;

    public SignInController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Show the login form
    [HttpGet]
    public IActionResult LoginPage()
    {
        return View();
    }

    // POST: Handle login and set session
    [HttpPost]
    public IActionResult LoginPage(SignInViewModel model)
    {
        // Check if the user exists in the database
        var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);

        if (user == null)
        {
            // User not found, prompt to sign up
            ModelState.AddModelError("", "User does not exist. Please sign up first.");
            return View();
        }
        else
        {
            // User exists, now check the password
            if (user.Password == model.Password)
            {
                // Password matches, set session and redirect to home page
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("UserName", user.UserName);
                //HttpContext.Session.SetString("UserType", user.IsPremium ? "Premium" : "NonPremium");

                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                // Password does not match
                ModelState.AddModelError("", "Incorrect password. Please try again.");
                return View();
            }
        }
    }


    // Sign out method
    public IActionResult SignOut()
    {
        HttpContext.Session.Clear(); // Clear session data
        return RedirectToAction("LoginPage");
    }
}
