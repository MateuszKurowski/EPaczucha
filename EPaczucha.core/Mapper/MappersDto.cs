using System.Collections.Generic;

using AutoMapper;

using EPaczucha.database;

namespace EPaczucha.core
{
    public class MappersDto
    {
        private IMapper _mapper;

        public MappersDto()
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
        public IEnumerable<CustomerDto> Map(IEnumerable<Customer> customers) 
            => _mapper.Map<IEnumerable<CustomerDto>>(customers);

        public Customer Map(CustomerDto customer) => _mapper.Map<Customer>(customer);
        public IEnumerable<Customer> Map(IEnumerable<CustomerDto> customers)
            => _mapper.Map<IEnumerable<Customer>>(customers);
        #endregion

        #region Package
        public PackageDto Map(Package Package) => _mapper.Map<PackageDto>(Package);
        public IEnumerable<PackageDto> Map(IEnumerable<Package> Packages)
            => _mapper.Map<IEnumerable<PackageDto>>(Packages);

        public Package Map(PackageDto Package) => _mapper.Map<Package>(Package);
        public IEnumerable<Package> Map(IEnumerable<PackageDto> Packages)
            => _mapper.Map<IEnumerable<Package>>(Packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageType PackageType) => _mapper.Map<PackageTypeDto>(PackageType);
        public IEnumerable<PackageTypeDto> Map(IEnumerable<PackageType> PackageTypes)
            => _mapper.Map<IEnumerable<PackageTypeDto>>(PackageTypes);

        public PackageType Map(PackageTypeDto PackageType) => _mapper.Map<PackageType>(PackageType);
        public IEnumerable<PackageType> Map(IEnumerable<PackageTypeDto> PackageTypes)
            => _mapper.Map<IEnumerable<PackageType>>(PackageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePrice PackagePrice) => _mapper.Map<PackagePriceDto>(PackagePrice);
        public IEnumerable<PackagePriceDto> Map(IEnumerable<PackagePrice> PackagePrices)
            => _mapper.Map<IEnumerable<PackagePriceDto>>(PackagePrices);

        public PackagePrice Map(PackagePriceDto PackagePrice) => _mapper.Map<PackagePrice>(PackagePrice);
        public IEnumerable<PackagePrice> Map(IEnumerable<PackagePriceDto> PackagePrices)
            => _mapper.Map<IEnumerable<PackagePrice>>(PackagePrices);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethod SendMethod) => _mapper.Map<SendMethodDto>(SendMethod);
        public IEnumerable<SendMethodDto> Map(IEnumerable<SendMethod> SendMethods)
            => _mapper.Map<IEnumerable<SendMethodDto>>(SendMethods);

        public SendMethod Map(SendMethodDto SendMethod) => _mapper.Map<SendMethod>(SendMethod);
        public IEnumerable<SendMethod> Map(IEnumerable<SendMethodDto> SendMethods)
            => _mapper.Map<IEnumerable<SendMethod>>(SendMethods);
        #endregion
    }
}
