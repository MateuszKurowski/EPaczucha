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
                config.CreateMap<PackagePrice, PackagePriceViewMode>()
                .ReverseMap();
            }).CreateMapper();
        }

        public PackagePriceViewMode Map(PackagePrice user)
        {
            return _mapper.Map<PackagePriceViewMode>(user);
        }

        public PackagePrice Map(PackagePriceViewMode user)
        {
            return _mapper.Map<PackagePrice>(user);
        }
    }
}
