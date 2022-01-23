using System.Collections.Generic;

using AutoMapper;

using EPaczucha.core;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class MapperViewModel
    {
        private IMapper _mapper;

        public MapperViewModel()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<CustomerViewModel, CustomerDto>()
                      .ReverseMap();
                config.CreateMap<PackageViewModel, PackageDto>()
                      .ReverseMap();
                config.CreateMap<PackagePriceViewModel, PackagePriceDto>()
                      .ReverseMap();
                config.CreateMap<PackageTypeViewModel, PackageTypeDto>()
                      .ReverseMap();
                config.CreateMap<SendMethodViewModel, SendMethodDto>()
                      .ReverseMap();
                config.CreateMap<DestinationViewModel, DestinationDto>()
                      .ReverseMap();
            }).CreateMapper();
        }

        #region Customer
        public CustomerDto Map(CustomerViewModel customer) => _mapper.Map<CustomerDto>(customer);
        public List<CustomerDto> Map(List<CustomerViewModel> customers)
            => _mapper.Map<List<CustomerDto>>(customers);

        public CustomerViewModel Map(CustomerDto customer) => _mapper.Map<CustomerViewModel>(customer);
        public List<CustomerViewModel> Map(List<CustomerDto> customers)
            => _mapper.Map<List<CustomerViewModel>>(customers);
        #endregion

        #region Package
        public PackageDto Map(PackageViewModel packages) => _mapper.Map<PackageDto>(packages);
        public List<PackageDto> Map(List<PackageViewModel> packages)
            => _mapper.Map<List<PackageDto>>(packages);

        public PackageViewModel Map(PackageDto packages) => _mapper.Map<PackageViewModel>(packages);
        public List<PackageViewModel> Map(List<PackageDto> packages)
            => _mapper.Map<List<PackageViewModel>>(packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageTypeViewModel packageTypes) => _mapper.Map<PackageTypeDto>(packageTypes);
        public List<PackageTypeDto> Map(List<PackageTypeViewModel> packageTypes)
            => _mapper.Map<List<PackageTypeDto>>(packageTypes);

        public PackageTypeViewModel Map(PackageTypeDto packageTypes) => _mapper.Map<PackageTypeViewModel>(packageTypes);
        public List<PackageTypeViewModel> Map(List<PackageTypeDto> packageTypes)
            => _mapper.Map<List<PackageTypeViewModel>>(packageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePriceViewModel packagePrices) => _mapper.Map<PackagePriceDto>(packagePrices);
        public List<PackagePriceDto> Map(List<PackagePriceViewModel> packagePrices)
            => _mapper.Map<List<PackagePriceDto>>(packagePrices);

        public PackagePriceViewModel Map(PackagePriceDto packagePrices) => _mapper.Map<PackagePriceViewModel>(packagePrices);
        public List<PackagePriceViewModel> Map(List<PackagePriceDto> packagePrices)
            => _mapper.Map<List<PackagePriceViewModel>>(packagePrices);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethodViewModel sendMethods) => _mapper.Map<SendMethodDto>(sendMethods);
        public List<SendMethodDto> Map(List<SendMethodViewModel> sendMethods)
            => _mapper.Map<List<SendMethodDto>>(sendMethods);

        public SendMethodViewModel Map(SendMethodDto sendMethods) => _mapper.Map<SendMethodViewModel>(sendMethods);
        public List<SendMethodViewModel> Map(List<SendMethodDto> sendMethods)
            => _mapper.Map<List<SendMethodViewModel>>(sendMethods);
        #endregion

        #region Destination
        public DestinationDto Map(DestinationViewModel destination) => _mapper.Map<DestinationDto>(destination);
        public List<DestinationDto> Map(List<DestinationViewModel> destination)
            => _mapper.Map<List<DestinationDto>>(destination);

        public DestinationViewModel Map(DestinationDto destination) => _mapper.Map<DestinationViewModel>(destination);
        public List<DestinationViewModel> Map(List<DestinationDto> destination)
            => _mapper.Map<List<DestinationViewModel>>(destination);
        #endregion

    }
}
