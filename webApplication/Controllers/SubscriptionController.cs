using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using webApplication.Models;

public class SubscriptionController : Controller
{
    private readonly AppDbContext _context;
    public SubscriptionController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Subscribe()
    {
        return View();
    }

    [HttpPost]
    public IActionResult BuySubscription(User model)
    {
        if (ModelState.IsValid)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            if (user != null)
            {
                user.UserType = model.UserType;
                HttpContext.Session.SetString("UserType", user.UserType);
            }

            _context.SaveChanges();
            return RedirectToAction("HomePage", "Home");
        }   
        return View();
    }

    public IActionResult SubscriptionSuccess()
    {
        return View(); 
    }
}
