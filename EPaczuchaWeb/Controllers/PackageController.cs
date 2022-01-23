﻿using System;
using System.Linq;

using EPaczucha.core;
using EPaczucha.database;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class PackageController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IPackagePriceRepository _packagePriceRepository;
        private readonly IPackageTypeRepository _packageTypeRepository;
        private readonly ISendMethodRepository _sendMethodRepository;

        private readonly IServiceProvider _serviceProvider;
        private readonly MapperViewModel _mapperViewModel;
        private readonly IManagerDto _managerDto;

        private int _packageId;
        private int _customerId;

        public PackageController(ICustomerRepository customerRepository, 
                                 IPackageRepository packageRepository, 
                                 IPackagePriceRepository packagePriceRepository, 
                                 IPackageTypeRepository packageTypeRepository, 
                                 ISendMethodRepository sendMethodRepository, 
                                 IServiceProvider serviceProvider, 
                                 MapperViewModel mapperViewModel)
        {
            _serviceProvider = serviceProvider;
            _mapperViewModel = mapperViewModel;

            _customerRepository = customerRepository;
            _packageRepository = packageRepository;
            _packagePriceRepository = packagePriceRepository;
            _packageTypeRepository = packageTypeRepository;
            _sendMethodRepository = sendMethodRepository;
        }

        [HttpGet]
        public IActionResult Index(int customerId, string filetString = null)
        {
            _customerId = customerId;

            var dtos = _managerDto.GetPackagesByCustomer(customerId, filetString);
            var viewModels = _mapperViewModel.Map(dtos);

            return View(viewModels);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(PackageViewModel packageVM, int packageTypeId, int sendMethodId)
        {
            var packageDto = _mapperViewModel.Map(packageVM);

            var typePrice = _managerDto.GetPriceFromPackageType(packageDto.PackageType.Id);
            var methodPrice = _managerDto.GetPriceFromSendMethod(packageDto.SendMethod.Id);
            var net = typePrice + methodPrice;
            var packagePrice = new PackagePriceDto
            {
                VAT = 23,
                Net = net,
                Gross = net * 23
            };
            var packagePriceId = _managerDto.AddNewPackagePrice(packagePrice);
            if (packagePriceId == 0)
                packagePriceId = 5;

            _managerDto.AddNewPackages(packageDto, _customerId, sendMethodId, (int)packagePriceId, packageTypeId);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int packageId)
        {
            var dtos =_managerDto.GetPackageById(packageId);
            var viewModel = _mapperViewModel.Map(dtos);

            ViewBag.SendMethod = viewModel.SendMethod.MethodName;
            ViewBag.PackageType = viewModel.PackageType.TypeName;
            ViewBag.PackagePrice = viewModel.PackagePrice.Gross;
            return View(viewModel);
        }

        [HttpDelete]
        public IActionResult Delete(int packageId)
        {
            _managerDto.DeletePackage(new PackageDto { Id = packageId });
            
            return RedirectToAction("Index");
        }
    }
}