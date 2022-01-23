﻿using System.Collections.Generic;
using System.Linq;

using EPaczucha.database;

namespace EPaczucha.core
{
    public class ManagerDto : IManagerDto
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPackageRepository _packageRepository;
        private readonly IPackageTypeRepository _packageTypeRepository;
        private readonly IPackagePriceRepository _packagePriceRepository;
        private readonly ISendMethodRepository _sendMethodRepository;
        private readonly MapperDto _mappersDto;

        public ManagerDto(ICustomerRepository customerRepository,
                          IPackageRepository packageRepository,
                          IPackageTypeRepository packageTypeRepository,
                          IPackagePriceRepository packagePriceRepository,
                          ISendMethodRepository sendMethodRepository,
                          MapperDto mappersDto)
        {
            _customerRepository = customerRepository;
            _packageRepository = packageRepository;
            _packageTypeRepository = packageTypeRepository;
            _packagePriceRepository = packagePriceRepository;
            _sendMethodRepository = sendMethodRepository;
            _mappersDto = mappersDto;
        }

        public IEnumerable<CustomerDto> GetCustomers(string filterString)
        {
            var customerEntities = _customerRepository.GetCustomers();

            if (string.IsNullOrEmpty(filterString))
            {
                customerEntities = customerEntities.Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString));
            }

            return _mappersDto.Map(customerEntities);
        }

        public decimal GetPriceFromPackageType(int typeId) => _packageTypeRepository.GetById(typeId).Price;

        public decimal GetPriceFromSendMethod(int sendMethodId) => _sendMethodRepository.GetById(sendMethodId).Price;

        public IEnumerable<PackageDto> GetPackagesByCustomer(int customerId, string filterString)
        {
            var packageEntities = _packageRepository.GetPackage().Where(x => x.Id == customerId);

            if (string.IsNullOrEmpty(filterString))
            {
                packageEntities = packageEntities.Where(x => x.SimpleName.Contains(filterString));
            }

            return _mappersDto.Map(packageEntities);
        }

        public void AddNewPackages(PackageDto package, int userId, int sendMethodId, int packagePriceId, int packageTypeId)
        {
            var entity = _mappersDto.Map(package);

            entity.UserId = userId;
            entity.PackageTypeID = packageTypeId;
            entity.PackagePriceID = packagePriceId;
            entity.SendMethodID = sendMethodId;

            _packageRepository.Create(entity);
        }

        public void AddNewCustomer(CustomerDto customer)
        {
            var entity = _mappersDto.Map(customer);

            _customerRepository.Create(entity);
        }

        public bool DeleteCustomer(CustomerDto customer)
        {
            var entity = _mappersDto.Map(customer);
            return _customerRepository.Delete(entity);
        }

        public bool DeletePackage(PackageDto package)
        {
            var entity = _mappersDto.Map(package);
            return _packageRepository.Delete(entity);
        }

        public PackageDto GetPackageById(int packageId)
        {
            var entity = _packageRepository.GetById(packageId);
            return _mappersDto.Map(entity);
        }

        public int? AddNewPackagePrice(PackagePriceDto packagePrice)
        {
            var entity = _mappersDto.Map(packagePrice);

            _packagePriceRepository.Create(entity);

            return _packagePriceRepository.GetAll().Where(x => x.Gross == entity.Gross && x.Net == entity.Net)?.FirstOrDefault()?.Id;
        }

        public void EditCustomer(int customerId)
        {
            var customer = _customerRepository.GetById(customerId);
            _customerRepository.Update(customer);
        }
    }
}