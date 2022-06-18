using Microsoft.AspNetCore.Mvc;

namespace PizzaParadise.React.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public bool Get()
        {
            return true;
        }

        //[HttpPost]
        //public IActionResult Login()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
