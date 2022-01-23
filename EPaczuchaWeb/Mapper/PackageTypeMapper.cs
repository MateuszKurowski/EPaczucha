using AutoMapper;

using EPaczucha.database;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class PackageTypeMapper
    {
        IMapper _mapper;

        public PackageTypeMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<PackageType, PackageTypeViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        public PackageTypeViewModel Map(PackageType user)
        {
            return _mapper.Map<PackageTypeViewModel>(user);
        }

        public PackageType Map(PackageTypeViewModel user)
        {
            return _mapper.Map<PackageType>(user);
        }
    }
}
