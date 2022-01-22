using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class PackageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}