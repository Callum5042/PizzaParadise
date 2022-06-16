using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(LoginModel model)
        {
            return Redirect("/");
        }
    }
}
