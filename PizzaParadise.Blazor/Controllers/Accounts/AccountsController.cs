using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PizzaParadise.Blazor.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View("~/controllers/accounts/login.cshtml", model);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginModel model)
        {
            // Set claims identity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.EmailAddress!)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync(claimsPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            });

            return Redirect("/");
        }
    }
}
