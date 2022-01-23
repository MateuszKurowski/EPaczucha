using System.Collections.Generic;

using AutoMapper;

using EPaczucha.database;

namespace EPaczucha.core
{
    public class MapperDto
    {
        private IMapper _mapper;

        public MapperDto()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerDto>()
                      .ReverseMap();
                config.CreateMap<Package, PackageDto>()
                      .ReverseMap();
                config.CreateMap<PackagePrice, PackagePriceDto>()
                      .ReverseMap();
                config.CreateMap<PackageType, PackageTypeDto>()
                      .ReverseMap();
                config.CreateMap<SendMethod, SendMethodDto>()
                      .ReverseMap();
            }).CreateMapper();
        }

        #region Customer
        public CustomerDto Map(Customer customer) => _mapper.Map<CustomerDto>(customer);
        public List<CustomerDto> Map(List<Customer> customers)
            => _mapper.Map<List<CustomerDto>>(customers);

        public Customer Map(CustomerDto customer) => _mapper.Map<Customer>(customer);
        public List<Customer> Map(List<CustomerDto> customers)
            => _mapper.Map<List<Customer>>(customers);
        #endregion

        #region Package
        public PackageDto Map(Package Package) => _mapper.Map<PackageDto>(Package);
        public List<PackageDto> Map(List<Package> Packages)
            => _mapper.Map<List<PackageDto>>(Packages);

        public Package Map(PackageDto Package) => _mapper.Map<Package>(Package);
        public List<Package> Map(List<PackageDto> Packages)
            => _mapper.Map<List<Package>>(Packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageType PackageType) => _mapper.Map<PackageTypeDto>(PackageType);
        public List<PackageTypeDto> Map(List<PackageType> PackageTypes)
            => _mapper.Map<List<PackageTypeDto>>(PackageTypes);

        public PackageType Map(PackageTypeDto PackageType) => _mapper.Map<PackageType>(PackageType);
        public List<PackageType> Map(List<PackageTypeDto> PackageTypes)
            => _mapper.Map<List<PackageType>>(PackageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePrice PackagePrice) => _mapper.Map<PackagePriceDto>(PackagePrice);
        public List<PackagePriceDto> Map(List<PackagePrice> PackagePrices)
            => _mapper.Map<List<PackagePriceDto>>(PackagePrices);

        public PackagePrice Map(PackagePriceDto PackagePrice) => _mapper.Map<PackagePrice>(PackagePrice);
        public List<PackagePrice> Map(List<PackagePriceDto> PackagePrices)
            => _mapper.Map<List<PackagePrice>>(PackagePrices);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethod SendMethod) => _mapper.Map<SendMethodDto>(SendMethod);
        public List<SendMethodDto> Map(List<SendMethod> SendMethods)
            => _mapper.Map<List<SendMethodDto>>(SendMethods);

        public SendMethod Map(SendMethodDto SendMethod) => _mapper.Map<SendMethod>(SendMethod);
        public List<SendMethod> Map(List<SendMethodDto> SendMethods)
            => _mapper.Map<List<SendMethod>>(SendMethods);
        #endregion
    }
}
