using EPaczucha.core;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    [Authorize]
    [Route("paczki")]
    public class PackageController : Controller
    {
        private readonly MapperViewModel _mapperViewModel;
        private readonly IManagerDto _managerDto;

        public PackageController(MapperViewModel mapperViewModel,
                                 IManagerDto managerDto)
        {
            _mapperViewModel = mapperViewModel;
            _managerDto = managerDto;
        }

        [HttpGet("{id}")]
        [Route("lista/{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Index(int id, string filterString = null)
        {
            if (id == 0)
                return BadRequest();
            var dtos = _managerDto.GetPackagesByCustomer(id, filterString);
            var viewModels = _mapperViewModel.Map(dtos);
            ViewBag.CustomerId = id;

            return View(viewModels);
        }

        [HttpGet]
        [Route("nowy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(int id)
        {
            ViewBag.CustomerId = id;
            return View();
        }

        [HttpPost]
        [Route("nowy")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(PackageViewModel packageVM, int id)
        {
            var typePrice = _managerDto.GetPriceFromPackageType(packageVM.PackageType.Id);
            var methodPrice = _managerDto.GetPriceFromSendMethod(packageVM.SendMethod.Id);
            var net = typePrice + methodPrice;
            var packagePriceId = _managerDto.AddNewPackagePrice(new PackagePriceDto()
            {
                VAT = 0.23M,
                Net = net,
                Gross = (net * 0.23M) + net
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
            var customerId = id;

            _managerDto.AddNewPackages(packageDto, customerId, packageDto.PackageType.Id, packagePriceId, packageDto.SendMethod.Id, destinationId);

            return RedirectToAction("Index", new { id });
        }

        [HttpGet]
        [Route("szczegoly")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Details(int id, int customerId)
        {
            ViewBag.CustomerId = customerId;

            var dtos =_managerDto.GetPackageById(id);
            var viewModel = _mapperViewModel.Map(dtos);

            return View(viewModel);
        }

        [HttpDelete("{id}")]
        [Route("usun")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id, int customerId)
        {
            _managerDto.DeletePackage(new PackageDto { Id = id });

            return RedirectToAction("Index", new { id = customerId });
        }
    }
}