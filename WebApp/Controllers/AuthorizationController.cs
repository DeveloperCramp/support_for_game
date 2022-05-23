using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }
    }
}
