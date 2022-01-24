
using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //return RedirectToAction(nameof(CustomerController.Index), "Customer");
        }
    }
}