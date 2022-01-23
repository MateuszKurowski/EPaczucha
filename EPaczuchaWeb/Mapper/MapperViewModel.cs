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
        public List<CustomerDto> Map(List<CustomerViewModel> customers)
            => _mapper.Map<List<CustomerDto>>(customers);

        public CustomerViewModel Map(CustomerDto customer) => _mapper.Map<CustomerViewModel>(customer);
        public List<CustomerViewModel> Map(List<CustomerDto> customers)
            => _mapper.Map<List<CustomerViewModel>>(customers);
        #endregion

        #region Package
        public PackageDto Map(PackageViewModel Package) => _mapper.Map<PackageDto>(Package);
        public List<PackageDto> Map(List<PackageViewModel> Packages)
            => _mapper.Map<List<PackageDto>>(Packages);

        public PackageViewModel Map(PackageDto Package) => _mapper.Map<PackageViewModel>(Package);
        public List<PackageViewModel> Map(List<PackageDto> Packages)
            => _mapper.Map<List<PackageViewModel>>(Packages);
        #endregion

        #region PackageType
        public PackageTypeDto Map(PackageTypeViewModel PackageType) => _mapper.Map<PackageTypeDto>(PackageType);
        public List<PackageTypeDto> Map(List<PackageTypeViewModel> PackageTypes)
            => _mapper.Map<List<PackageTypeDto>>(PackageTypes);

        public PackageTypeViewModel Map(PackageTypeDto PackageType) => _mapper.Map<PackageTypeViewModel>(PackageType);
        public List<PackageTypeViewModel> Map(List<PackageTypeDto> PackageTypes)
            => _mapper.Map<List<PackageTypeViewModel>>(PackageTypes);
        #endregion

        #region PackagePrice
        public PackagePriceDto Map(PackagePriceViewModel PackagePrice) => _mapper.Map<PackagePriceDto>(PackagePrice);
        public List<PackagePriceDto> Map(List<PackagePriceViewModel> PackagePrices)
            => _mapper.Map<List<PackagePriceDto>>(PackagePrices);

        public PackagePriceViewModel Map(PackagePriceDto PackagePrice) => _mapper.Map<PackagePriceViewModel>(PackagePrice);
        public List<PackagePriceViewModel> Map(List<PackagePriceDto> PackagePrices)
            => _mapper.Map<List<PackagePriceViewModel>>(PackagePrices);
        #endregion

        #region SendMethod
        public SendMethodDto Map(SendMethodViewModel SendMethod) => _mapper.Map<SendMethodDto>(SendMethod);
        public List<SendMethodDto> Map(List<SendMethodViewModel> SendMethods)
            => _mapper.Map<List<SendMethodDto>>(SendMethods);

        public SendMethodViewModel Map(SendMethodDto SendMethod) => _mapper.Map<SendMethodViewModel>(SendMethod);
        public List<SendMethodViewModel> Map(List<SendMethodDto> SendMethods)
            => _mapper.Map<List<SendMethodViewModel>>(SendMethods);
        #endregion
    }
}
