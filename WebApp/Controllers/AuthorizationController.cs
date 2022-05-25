using AutoMapper;
using Db;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAdminsDbStorage adminsDbStorage;
        private readonly IMapper mapper;

        public AuthorizationController(IAdminsDbStorage adminsDbStorage, IMapper mapper)
        {
            this.adminsDbStorage = adminsDbStorage;
            this.mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> LoginAsync(AdminViewModel model)
        {
            var result = await adminsDbStorage.TryGetByMailAsync(model.Mail);
            if (result == null)
            {
                ModelState.AddModelError("", "Такого пользователя не существует!");
                return View(model);
            }
            if (result.Password == model.Password)
            {
                return RedirectToAction(nameof(MessagesController.Index), "Messages");
            }
            ModelState.AddModelError("", "Логин и/или пароль неверные!");
            return View(model);
        }
    }
}
