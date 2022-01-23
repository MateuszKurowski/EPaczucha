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
                config.CreateMap<DestinationDto, DestinationDto>()
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
        public PackageDto Map(Package package) => _mapper.Map<PackageDto>(package);
        public List<PackageDto> Map(List<Package> packages)
            => _mapper.Map<List<PackageDto>>(packages);

        public Package Map(PackageDto package) => _mapper.Map<Package>(package);
        public List<Package> Map(List<PackageDto> packages)
            => _mapper.Map<List<Package>>(packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageType packageType) => _mapper.Map<PackageTypeDto>(packageType);
        public List<PackageTypeDto> Map(List<PackageType> packageTypes)
            => _mapper.Map<List<PackageTypeDto>>(packageTypes);

        public PackageType Map(PackageTypeDto packageType) => _mapper.Map<PackageType>(packageType);
        public List<PackageType> Map(List<PackageTypeDto> packageTypes)
            => _mapper.Map<List<PackageType>>(packageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePrice packagePrice) => _mapper.Map<PackagePriceDto>(packagePrice);
        public List<PackagePriceDto> Map(List<PackagePrice> packagePrice)
            => _mapper.Map<List<PackagePriceDto>>(packagePrice);

        public PackagePrice Map(PackagePriceDto packagePrice) => _mapper.Map<PackagePrice>(packagePrice);
        public List<PackagePrice> Map(List<PackagePriceDto> packagePrice)
            => _mapper.Map<List<PackagePrice>>(packagePrice);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethod sendMethod) => _mapper.Map<SendMethodDto>(sendMethod);
        public List<SendMethodDto> Map(List<SendMethod> sendMethod)
            => _mapper.Map<List<SendMethodDto>>(sendMethod);

        public SendMethod Map(SendMethodDto sendMethod) => _mapper.Map<SendMethod>(sendMethod);
        public List<SendMethod> Map(List<SendMethodDto> sendMethod)
            => _mapper.Map<List<SendMethod>>(sendMethod);
        #endregion

        #region Destination
        public DestinationDto Map(Test destination) => _mapper.Map<DestinationDto>(destination);
        public List<DestinationDto> Map(List<Test> destination)
            => _mapper.Map<List<DestinationDto>>(destination);

        public Test Map(DestinationDto destination) => _mapper.Map<Test>(destination);
        public List<Test> Map(List<DestinationDto> destination)
            => _mapper.Map<List<Test>>(destination);
        #endregion
    }
}
