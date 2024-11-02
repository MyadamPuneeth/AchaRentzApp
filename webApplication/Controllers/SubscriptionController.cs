using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.Data;

public class SubscriptionController : Controller
{
    private readonly AppDbContext Context;
    public SubscriptionController(AppDbContext context)
    {
        Context = context;
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
            var user = Context.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));

            if (user != null)
            {
                user.UserType = model.UserType;
                HttpContext.Session.SetString("UserType", user.UserType);
            }

            Context.SaveChanges();
            return RedirectToAction("HomePage", "Home");
        }   
        return View();
    }

    public IActionResult SubscriptionSuccess()
    {
        return View(); 
    }
}
