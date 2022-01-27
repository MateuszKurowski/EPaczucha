using System.Collections.Generic;
using System.Linq;

using EPaczucha.core;

using EPaczuchaWeb.Exceptions;
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
            if (dtos.Count == 0)
            {
                Response.StatusCode = 204;
                return NotFound();
            }
            Response.StatusCode = 200;
            return View(_mapperViewModel.Map(dtos ?? new List<CustomerDto>()));
        }

        [Authorize(Roles = "admin, mod")]
        [HttpGet]
        [Route("szczegoly")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Details(int id)
        {
            var dto =_managerDto.GetCustomers(null)?.FirstOrDefault(x => x.Id == id);
            if (dto == null)
            {
                Response.StatusCode = 204;
                return NotFound();
            }
            return View(_mapperViewModel.Map(dto ?? new CustomerDto()));
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("edycja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [NoId]
        public IActionResult Edit(int id)
        {
            var dto = _managerDto.GetCustomers(null)?.FirstOrDefault(x => x.Id == id);
            if (dto == null)
            {
                Response.StatusCode = 304;
                return NotFound();
            }
            else
                ViewBag.customerId = id;
            return View("Edit", _mapperViewModel.Map(dto ?? new CustomerDto()));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("edycja")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Edit(CustomerViewModel customer, int id)
        {
            customer.Id = id;
            var dto =_mapperViewModel.Map(customer);

            _managerDto.EditCustomer(dto);

            return RedirectToAction("Details", new { id = customer.Id});
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [Route("usun")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [NoId]
        public IActionResult Delete(int id)
        {
            var deleted = _managerDto.DeleteCustomer(new CustomerDto { Id = id });
            if (!deleted)
            {
                Response.StatusCode = 204;
                return NotFound();
            }
            Response.StatusCode = 200;
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
            
            if (_managerDto.AddNewCustomer(dto) == 0)
            {
                Response.StatusCode = 405;
                return NotFound();
            }

            Response.StatusCode = 201;
            return RedirectToAction("Index");
        }
    }
}