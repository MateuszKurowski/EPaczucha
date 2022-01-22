using System.Collections.Generic;
using System.Linq;

using EPaczucha.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class PackageController : Controller
    {
        private int packageId;

        private List<Package> packages;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int packageId)
        {
            var user = packages.FirstOrDefault(x => x.Id == packageId);

            return View(user);
        }

        public IActionResult Edit(Package packageId)
        {
            var package = packages.FirstOrDefault(x => x.Id == packageId.Id);

            return RedirectToAction("Index", "Delivery");
        }

        public IActionResult Details(int packageId)
        {
            var user = packages.FirstOrDefault(x => x.Id == packageId);

            return View(user);
        }
    }
}