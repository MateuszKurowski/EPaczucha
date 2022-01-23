using AutoMapper;

using EPaczucha.database;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class PackageMapper
    {
        IMapper _mapper;

        public PackageMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Package, PackageViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        public PackageViewModel Map(Package user)
        {
            return _mapper.Map<PackageViewModel>(user);
        }

        public Package Map(PackageViewModel user)
        {
            return _mapper.Map<Package>(user);
        }
    }
}
