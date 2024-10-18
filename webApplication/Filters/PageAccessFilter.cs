using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

public class PageAccessFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Check if the user is authenticated
        var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;

        // Get the requested controller and action names
        var controller = context.RouteData.Values["controller"].ToString();
        var action = context.RouteData.Values["action"].ToString();

        // If the user is not authenticated, restrict access to other pages
        if (!isAuthenticated)
        {
            // Allow only RegistrationPage, HomePage, LoginPage before login
            if (!(controller == "Home" && action == "HomePage") &&
                !(controller == "User" && action == "RegistrationPage") &&
                !(controller == "SignIn" && action == "LoginPage"))
            {
                // Redirect to the login page if the user tries to access any other page
                context.Result = new RedirectToActionResult("LoginPage", "SignIn", null);
            }
        }

        base.OnActionExecuting(context);
    }
}
