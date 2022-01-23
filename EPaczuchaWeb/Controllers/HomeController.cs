
using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(CustomerController.Index), "Customer");
        }
    }
}