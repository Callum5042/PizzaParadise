using Microsoft.AspNetCore.Mvc;

namespace PizzaParadise.Mvc.Site.Accounts
{
    public class AccountsController : Controller
    {
        public IActionResult Login()
        {
            var model = new LoginModel();
            return View("~/site/accounts/login.cshtml", model);
        }
    }
}
