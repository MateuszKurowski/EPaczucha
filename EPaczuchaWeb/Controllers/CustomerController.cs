using System;
using System.Collections.Generic;
using System.Linq;

using EPaczucha.core;
using EPaczucha.database;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MapperViewModel _mapperViewModel;
        private readonly IManagerDto _managerDto;

        public CustomerController(MapperViewModel mapperViewModel, IManagerDto managerDto)
        {
            _mapperViewModel = mapperViewModel;
            _managerDto = managerDto;
        }

        public IActionResult Index()
        {
            var dtos = _managerDto.GetCustomers(null);
            return View(_mapperViewModel.Map(dtos));
        }

        public IActionResult Details(int id)
        {
            var dto =_managerDto.GetCustomers(null).FirstOrDefault(x => x.Id == id);

            return View(_mapperViewModel.Map(dto));
        }

        public IActionResult Edit(int id)
        {
            var dto = _managerDto.GetCustomers(null).FirstOrDefault(x => x.Id == id);

            return View("Edit", _mapperViewModel.Map(dto));
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel customer)
        {
            var dto =_mapperViewModel.Map(customer);

            _managerDto.EditCustomer(dto);

            return RedirectToAction("Details", customer);
        }

        public IActionResult Delete(int id)
        {
            _managerDto.DeleteCustomer(new CustomerDto { Id = id });

            return RedirectToAction("Index");
        }

        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(CustomerViewModel customer)
        {
            var dto = _mapperViewModel.Map(customer);
            _managerDto.AddNewCustomer(dto);

            return RedirectToAction("Index");
        }
    }
}