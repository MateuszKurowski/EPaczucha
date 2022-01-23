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
            }).CreateMapper();
        }

        #region Customer
        public CustomerDto Map(CustomerViewModel customer) => _mapper.Map<CustomerDto>(customer);
        public IEnumerable<CustomerDto> Map(IEnumerable<CustomerViewModel> customers)
            => _mapper.Map<IEnumerable<CustomerDto>>(customers);

        public CustomerViewModel Map(CustomerDto customer) => _mapper.Map<CustomerViewModel>(customer);
        public IEnumerable<CustomerViewModel> Map(IEnumerable<CustomerDto> customers)
            => _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        #endregion

        #region Package
        public PackageDto Map(PackageViewModel Package) => _mapper.Map<PackageDto>(Package);
        public IEnumerable<PackageDto> Map(IEnumerable<PackageViewModel> Packages)
            => _mapper.Map<IEnumerable<PackageDto>>(Packages);

        public PackageViewModel Map(PackageDto Package) => _mapper.Map<PackageViewModel>(Package);
        public IEnumerable<PackageViewModel> Map(IEnumerable<PackageDto> Packages)
            => _mapper.Map<IEnumerable<PackageViewModel>>(Packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageTypeViewModel PackageType) => _mapper.Map<PackageTypeDto>(PackageType);
        public IEnumerable<PackageTypeDto> Map(IEnumerable<PackageTypeViewModel> PackageTypes)
            => _mapper.Map<IEnumerable<PackageTypeDto>>(PackageTypes);

        public PackageTypeViewModel Map(PackageTypeDto PackageType) => _mapper.Map<PackageTypeViewModel>(PackageType);
        public IEnumerable<PackageTypeViewModel> Map(IEnumerable<PackageTypeDto> PackageTypes)
            => _mapper.Map<IEnumerable<PackageTypeViewModel>>(PackageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePriceViewModel PackagePrice) => _mapper.Map<PackagePriceDto>(PackagePrice);
        public IEnumerable<PackagePriceDto> Map(IEnumerable<PackagePriceViewModel> PackagePrices)
            => _mapper.Map<IEnumerable<PackagePriceDto>>(PackagePrices);

        public PackagePriceViewModel Map(PackagePriceDto PackagePrice) => _mapper.Map<PackagePriceViewModel>(PackagePrice);
        public IEnumerable<PackagePriceViewModel> Map(IEnumerable<PackagePriceDto> PackagePrices)
            => _mapper.Map<IEnumerable<PackagePriceViewModel>>(PackagePrices);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethodViewModel SendMethod) => _mapper.Map<SendMethodDto>(SendMethod);
        public IEnumerable<SendMethodDto> Map(IEnumerable<SendMethodViewModel> SendMethods)
            => _mapper.Map<IEnumerable<SendMethodDto>>(SendMethods);

        public SendMethodViewModel Map(SendMethodDto SendMethod) => _mapper.Map<SendMethodViewModel>(SendMethod);
        public IEnumerable<SendMethodViewModel> Map(IEnumerable<SendMethodDto> SendMethods)
            => _mapper.Map<IEnumerable<SendMethodViewModel>>(SendMethods);
        #endregion
    }
}
