using EPaczucha.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(UserController.Index), nameof(User));
        }
    }
}