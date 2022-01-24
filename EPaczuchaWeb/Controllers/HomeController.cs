using EPaczucha.core;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerDto _managerDto;

        public HomeController(IManagerDto managerDto) => _managerDto = managerDto;
        public IActionResult Index()
        {
            _managerDto.AddDefaultPackageType(true);
            _managerDto.AddDefaultSendMethod(true);
            return View();
            //return RedirectToAction(nameof(CustomerController.Index), "Customer");
        }
    }
}