using Microsoft.AspNetCore.Mvc;
using PresentationLayer.ViewModels;
using DAL.Data;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

public class SignInController : Controller
{
    private readonly AppDbContext Context;
    private readonly IAuthService AuthService;

    public SignInController(AppDbContext context, IAuthService authService)
    {
        Context = context;
        AuthService = authService;
    }

    // GET: Show the login form

    [HttpGet]
    public IActionResult LoginPage()
    {
        if (HttpContext.Session.GetInt32("UserName")!= null)
        {
            return RedirectToAction("HomePage","Home");
        }
        return View();
    }

    // POST: Handle login and set session
    [HttpPost]
    public IActionResult LoginPage(SignInViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Map ViewModel to DTO
            var signInDto = new SignInDto
            {
                UserName = model.UserName,
                Password = model.Password
            };

            var user = AuthService.AuthenticateUser(signInDto);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password.");
                return View();
            }

            // Set session on successful login
            HttpContext.Session.SetInt32("IsUserLoggedIn", 1);
            HttpContext.Session.SetInt32("UserId", user.UserId);
            HttpContext.Session.SetString("UserName", user.UserName);
            HttpContext.Session.SetString("UserType", user.UserType);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("HomePage", "Home");
        }

        return View();
    }

    public async Task GoogleLogin()
{
    var properties = new AuthenticationProperties
    {
        RedirectUri = Url.Action("GoogleResponse")
    };

    // Trigger the Google authentication challenge
    await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, properties);
}

public async Task<IActionResult> GoogleResponse()
{
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

    if (!result.Succeeded)
    {
        return RedirectToAction("Login"); // Redirect to login if authentication fails
    }

    var claims = result.Principal.Identities.FirstOrDefault()?.Claims.Select(claim => new
    {
        claim.Issuer,
        claim.OriginalIssuer,
        claim.Type,
        claim.Value
    });
        HttpContext.Session.SetString("UserName", claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
        HttpContext.Session.SetString("UserEmail", claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);

        return RedirectToAction("HomePage", "Home");
}

    // Sign out method
    public IActionResult SignOut()
    {
        HttpContext.Session.Clear(); // Clear session data
        HttpContext.SignOutAsync();
        return RedirectToAction("LoginPage");
    }
}
