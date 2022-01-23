using AutoMapper;

using EPaczucha.database;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class PackagePriceMapper
    {
        IMapper _mapper;

        public PackagePriceMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<PackagePrice, PackagePriceViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        public PackagePriceViewModel Map(PackagePrice user)
        {
            return _mapper.Map<PackagePriceViewModel>(user);
        }

        public PackagePrice Map(PackagePriceViewModel user)
        {
            return _mapper.Map<PackagePrice>(user);
        }
    }
}
