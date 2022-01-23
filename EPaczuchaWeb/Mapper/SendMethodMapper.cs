using AutoMapper;

using EPaczucha.database;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class SendMethodMapper
    {
        IMapper _mapper;

        public SendMethodMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<SendMethod, SendMethodViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        public CustomerViewModel Map(SendMethodViewModel user)
        {
            return _mapper.Map<CustomerViewModel>(user);
        }

        public SendMethodViewModel Map(CustomerViewModel user)
        {
            return _mapper.Map<SendMethodViewModel>(user);
        }
    }
}
