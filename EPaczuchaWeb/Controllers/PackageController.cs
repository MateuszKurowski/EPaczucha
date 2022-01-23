using System;
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
        private readonly IDestinationRepository _destinationRepository;

        private readonly IServiceProvider _serviceProvider;
        private readonly MapperViewModel _mapperViewModel;
        private readonly IManagerDto _managerDto;

        public PackageController(ICustomerRepository customerRepository,
                                 IPackageRepository packageRepository,
                                 IPackagePriceRepository packagePriceRepository,
                                 IPackageTypeRepository packageTypeRepository,
                                 ISendMethodRepository sendMethodRepository,
                                 IDestinationRepository destinationRepository,
                                 IServiceProvider serviceProvider,
                                 MapperViewModel mapperViewModel,
                                 IManagerDto managerDto)
        {
            _serviceProvider = serviceProvider;
            _mapperViewModel = mapperViewModel;
            _managerDto = managerDto;
            _customerRepository = customerRepository;
            _packageRepository = packageRepository;
            _packagePriceRepository = packagePriceRepository;
            _packageTypeRepository = packageTypeRepository;
            _sendMethodRepository = sendMethodRepository;
            _destinationRepository = destinationRepository;
        }

        [HttpGet]
        public IActionResult Index(int id, string filetString = null)
        {
            if (id != 0)
                TempData["customerId"] = id;
            else if (TempData["customerId"] != null)
                id = int.Parse(TempData["customerId"].ToString());
            else
                id = 1;

            var dtos = _managerDto.GetPackagesByCustomer(id, filetString);
            var viewModels = _mapperViewModel.Map(dtos);

            return View(viewModels);
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(PackageViewModel packageVM)
        {
            var typePrice = _managerDto.GetPriceFromPackageType(packageVM.PackageType.Id);
            var methodPrice = _managerDto.GetPriceFromSendMethod(packageVM.SendMethod.Id);
            var net = typePrice + methodPrice;
            var packagePriceId = _managerDto.AddNewPackagePrice(new PackagePriceDto()
            {
                VAT = 23,
                Net = net,
                Gross = net * 23
            });
            var destinationId = _managerDto.AddNewDestination(new DestinationDto()
            {
                ApartmentNumber = packageVM.DestinationApartmentNumber,
                BuildingNumber = packageVM.DestinationBuildingNumber,
                City = packageVM.DestinationCity,
                Street = packageVM.DestinationStreet,
                ZipCode = packageVM.DestinationZipCode
            });
            packageVM.EndDate = packageVM.StartDate.AddDays(packageVM.SendMethod.Id == 1 ? 7 : packageVM.SendMethod.Id == 2 ? 4 : 2);

            var packageDto = _mapperViewModel.Map(packageVM);
            var customerId = TempData["customerId"] == null ? _managerDto.GetCustomers(null).FirstOrDefault().Id : int.Parse(TempData["customerId"].ToString());

            _managerDto.AddNewPackages(packageDto, customerId, packageDto.PackageType.Id, packagePriceId, packageDto.SendMethod.Id, destinationId);

            return RedirectToAction("Index", new { customerId = int.Parse(TempData["customerId"].ToString()) });
        }

        public IActionResult Details(int id)
        {
            var dtos =_managerDto.GetPackageById(id);
            var viewModel = _mapperViewModel.Map(dtos);

            ViewBag.SendMethod = viewModel.SendMethod.MethodName;
            ViewBag.PackageType = viewModel.PackageType.TypeName;
            ViewBag.PackagePrice = viewModel.PackagePrice.Gross;
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _managerDto.DeletePackage(new PackageDto { Id = id });

            return RedirectToAction("Index");
        }
    }
}