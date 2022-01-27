using System.Collections.Generic;
using System.Linq;

using EPaczucha.core;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    [Authorize]
    [Route("kilienci")]
    public class CustomerController : Controller
    {
        private readonly MapperViewModel _mapperViewModel;
        private readonly IManagerDto _managerDto;

        public CustomerController(MapperViewModel mapperViewModel, IManagerDto managerDto)
        {
            _mapperViewModel = mapperViewModel;
            _managerDto = managerDto;
        }

        [Authorize(Roles = "admin, mod")]
        [HttpGet]
        [Route("lista")]
        public IActionResult Index()
        {
            var dtos = _managerDto.GetCustomers(null);
            return View(_mapperViewModel.Map(dtos ?? new List<CustomerDto>()));
        }

        [Authorize(Roles = "admin, mod")]
        [HttpGet]
        [Route("szczegoly")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Details(int id)
        {
            var dto =_managerDto.GetCustomers(null)?.FirstOrDefault(x => x.Id == id);

            return View(_mapperViewModel.Map(dto ?? new CustomerDto()));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("edycja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(int id)
        {
            var dto = _managerDto.GetCustomers(null)?.FirstOrDefault(x => x.Id == id);

            return View("Edit", _mapperViewModel.Map(dto ?? new CustomerDto()));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("edycja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(CustomerViewModel customer)
        {
            var dto =_mapperViewModel.Map(customer);

            _managerDto.EditCustomer(dto);

            return RedirectToAction("Details", customer);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [Route("usun")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _managerDto.DeleteCustomer(new CustomerDto { Id = id });

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("dodaj")]
        public IActionResult Add() => View();

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("dodaj")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(CustomerViewModel customer)
        {
            if (customer.Login == null && customer.Email != null)
                customer.Login = customer.Email;
            else if (customer.Login != null && customer.Email == null)
                customer.Email = customer.Login;
            var dto = _mapperViewModel.Map(customer);
            _managerDto.AddNewCustomer(dto);

            return RedirectToAction("Index");
        }
    }
}