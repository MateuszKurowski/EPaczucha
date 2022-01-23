using System.Collections.Generic;
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
    }
}