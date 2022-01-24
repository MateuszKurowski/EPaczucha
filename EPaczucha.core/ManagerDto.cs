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
        private readonly IDestinationRepository _destinationRepository;
        private readonly MapperDto _mappersDto;

        public ManagerDto(ICustomerRepository customerRepository,
                          IPackageRepository packageRepository,
                          IPackageTypeRepository packageTypeRepository,
                          IPackagePriceRepository packagePriceRepository,
                          ISendMethodRepository sendMethodRepository,
                          IDestinationRepository destinationRepository,
                          MapperDto mappersDto)
        {
            _customerRepository = customerRepository;
            _packageRepository = packageRepository;
            _packageTypeRepository = packageTypeRepository;
            _packagePriceRepository = packagePriceRepository;
            _sendMethodRepository = sendMethodRepository;
            _mappersDto = mappersDto;
            _destinationRepository = destinationRepository;
        }

        public List<CustomerDto> GetCustomers(string filterString)
        {
            var customerEntities = _customerRepository.GetCustomers();

            if (!string.IsNullOrEmpty(filterString))
            {
                customerEntities = customerEntities.Where(x => x.FirstName.Contains(filterString) || x.LastName.Contains(filterString));
            }

            return _mappersDto.Map(customerEntities.ToList());
        }

        public decimal GetPriceFromPackageType(int typeId) => _packageTypeRepository.GetById(typeId).Price;

        public decimal GetPriceFromSendMethod(int sendMethodId) => _sendMethodRepository.GetById(sendMethodId).Price;

        public List<PackageDto> GetPackagesByCustomer(int customerId, string filterString)
        {
            var packageEntities = _packageRepository.GetPackage().Where(x => x.CustomerId == customerId);

            if (!string.IsNullOrEmpty(filterString))
            {
                packageEntities = packageEntities.Where(x => x.SimpleName.Contains(filterString));
            }

            return _mappersDto.Map(packageEntities.ToList());
        }

        public int AddNewPackages(PackageDto package, int customerId, int packageTypeId, int packagePriceId, int sendMethodId, int destinationId)
        {
            var entity = _mappersDto.Map(package);
            entity.CustomerId = customerId;
            entity.PackageTypeID = packageTypeId;
            if (entity.PackageType?.Id != null)
                entity.PackageType = null;
            entity.PackagePriceID = packagePriceId;
            entity.SendMethodID = sendMethodId;
            if (entity.SendMethod?.Id != null)
                entity.SendMethod = null;
            entity.DestinationId = destinationId;
            if (entity.Destination?.Id != null)
                entity.Destination = null;

            var i = _packageRepository.Create(entity);
            _packageRepository.SaveChanges();
            return i;
        }

        public int AddNewCustomer(CustomerDto customer)
        {
            var entity = _mappersDto.Map(customer);
            
            var i = _customerRepository.Create(entity);
            _customerRepository.SaveChanges();
            return i;
        }

        public bool DeleteCustomer(CustomerDto customer)
        {
            var entity = _mappersDto.Map(customer);
            _customerRepository.Delete(entity);
            return _customerRepository.SaveChanges();
        }

        public bool DeletePackage(PackageDto package)
        {
            var entity = _mappersDto.Map(package);
            _packageRepository.Delete(entity);
            return _packageRepository.SaveChanges();
        }

        public PackageDto GetPackageById(int packageId)
        {
            var entity = _packageRepository.GetById(packageId);
            entity.Destination = _destinationRepository.GetById(entity.DestinationId);
            entity.SendMethod = _sendMethodRepository.GetById(entity.SendMethodID);
            entity.PackageType = _packageTypeRepository.GetById(entity.PackageTypeID);
            entity.PackagePrice = _packagePriceRepository.GetById(entity.PackagePriceID);
            return _mappersDto.Map(entity);
        }

        public int AddNewPackagePrice(PackagePriceDto packagePrice)
        {
            var entity = _mappersDto.Map(packagePrice);
             var i = _packagePriceRepository.Create(entity);
            _packagePriceRepository.SaveChanges();
            return i;
        }

        public void EditCustomer(CustomerDto customer)
        {
            var customerEntity = _mappersDto.Map(customer);
            _customerRepository.Update(customerEntity);
        }

        public int AddNewDestination(DestinationDto destination)
        {
            var entity = _mappersDto.Map(destination);
            var i = _destinationRepository.Create(entity);
            _destinationRepository.SaveChanges();
            return i;
        }

        public bool DeleteDestination(DestinationDto destination)
        {
            var entity = _mappersDto.Map(destination);
            _destinationRepository.Delete(entity);
            return _destinationRepository.SaveChanges();
        }

        public PackageTypeDto GetPackageTypeById(int packageTypeById)
        {
            var entity = _packageTypeRepository.GetById(packageTypeById);
            return _mappersDto.Map(entity);
        }

        public SendMethodDto GetSendMethodById(int sendMethodById)
        {
            var entity = _sendMethodRepository.GetById(sendMethodById);
            return _mappersDto.Map(entity);
        }


        public void AddDefaultSendMethod(bool areYouSure = false)
        {
            if (_sendMethodRepository.GetAll() != null)
                return;

            if (areYouSure)
            {
                _sendMethodRepository.Create(new SendMethod { Id = 1, MethodName = "Paczka ekonomincza", Price = 8 });
                _sendMethodRepository.Create(new SendMethod { Id = 2, MethodName = "Paczka priorytetowa", Price = 13 });
                _sendMethodRepository.Create(new SendMethod { Id = 3, MethodName = "Kurier", Price = 18 });
            }
        }
        public void AddDefaultPackageType(bool areYouSure = false)
        {
            if (_packageTypeRepository.GetAll() != null)
                return;

            if (areYouSure)
            {
                _packageTypeRepository.Create(new PackageType { Id = 1, TypeName = "Typ A", Price = 5 , Width = 10.ToString(), Height = 10.ToString()});
                _packageTypeRepository.Create(new PackageType { Id = 2, TypeName = "Typ B", Price = 9, Width = 15.ToString(), Height = 20.ToString() });
                _packageTypeRepository.Create(new PackageType { Id = 3, TypeName = "Typ C", Price = 14, Width = 40.ToString(), Height = 30.ToString() });
            }
        }
    }
}