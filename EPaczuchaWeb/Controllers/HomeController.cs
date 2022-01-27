using EPaczucha.core;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IManagerDto _managerDto;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IManagerDto managerDto, UserManager<IdentityUser> userManager)
        {
            _managerDto = managerDto;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            _managerDto.AddDefaultPackageType(true);
            _managerDto.AddDefaultSendMethod(true);
            return RedirectToAction("HomePage");
            //return RedirectToAction(nameof(CustomerController.Index), "Customer");
        }

        [AllowAnonymous]
        public IActionResult HomePage() => View();

        [Authorize]
        public IActionResult LoginManager()
        {
            var userGuid = _userManager.GetUserId(HttpContext.User);
            var userName = _userManager.GetUserName(HttpContext.User);
            var userId = _managerDto.GetCustomerIdByGuid(userGuid);
            if ((userId == null || userId == 0) && (userName != "admin@admin.pl" && userName != "mod@mod.pl"))
                userId = _managerDto.AddNewCustomer(new CustomerDto() { Guid = userGuid, Login = userName });
            if(User.IsInRole("admin"))
            {
                return RedirectToAction("Index", "Customer");
            }
            else if(User.IsInRole("mod"))
            {
                return RedirectToAction("Index", "Customer");
            }
            else
            {
                return RedirectToAction("lista", "paczki", new { id = userId });
            }
        }
    }
}