﻿using System;
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

        public CustomerController(ICustomerRepository customerRepository,
                                 IPackageRepository packageRepository,
                                 IPackagePriceRepository packagePriceRepository,
                                 IPackageTypeRepository packageTypeRepository,
                                 ISendMethodRepository sendMethodRepository,
                                 IServiceProvider serviceProvider,
                                 MapperViewModel mapperViewModel,
                                 IManagerDto managerDto)
        {
            _customerRepository = customerRepository;
            _packageRepository = packageRepository;
            _packagePriceRepository = packagePriceRepository;
            _packageTypeRepository = packageTypeRepository;
            _sendMethodRepository = sendMethodRepository;
            _serviceProvider = serviceProvider;
            _mapperViewModel = mapperViewModel;
            _managerDto = managerDto;
        }

        public IActionResult Index()
        {
            var dtos = _managerDto.GetCustomers(null);
            return View(_mapperViewModel.Map(dtos));
        }

        public IActionResult Details(int customerId)
        {
            var dto =_managerDto.GetCustomers(null).Where(x => x.Id == customerId).FirstOrDefault();

            return View(_mapperViewModel.Map(dto));
        }

        [HttpPut]
        public IActionResult Edit(int customerId)
        {
            _managerDto.EditCustomer(customerId);

            return RedirectToAction("Details");
        }

        [HttpDelete]
        public IActionResult Delete(int customerId)
        {
            _managerDto.DeleteCustomer(new CustomerDto { Id = customerId });

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