using System;
using System.Linq;

using EPaczucha.database;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class PackageController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly PackageMapper _packageMapper;

        public PackageController(IServiceProvider serviceProvider, IPackageRepository packageRepository, PackageMapper packageMapper)
        {
            _serviceProvider = serviceProvider;
            _packageRepository = packageRepository;
            _packageMapper = packageMapper;
        }

        public IActionResult Index()
        {
            //_packageRepository.GetAll().Where(x => x.)

            return View(_packageRepository.GetAll());
        }

        public IActionResult Index(string userId)
        {
            //_packageRepository.GetAll().Where(x => x.UserId == userId).;

            return View(_packageRepository.GetAll());
        }

        //[HttpGet]
        //public IActionResult Edit(int packageId)
        //{
        //    var user = packages.FirstOrDefault(x => x.Id == packageId);

        //    return View(user);
        //}

        //public IActionResult Edit(PackageVM packageId)
        //{
        //    var package = packages.FirstOrDefault(x => x.Id == packageId.Id);

        //    return RedirectToAction("Index", "Delivery");
        //}

        //public IActionResult Details(int packageId)
        //{
        //    var user = packages.FirstOrDefault(x => x.Id == packageId);

        //    return View(user);
        //}
    }
}