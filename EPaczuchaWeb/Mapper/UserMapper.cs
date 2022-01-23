using AutoMapper;

using EPaczucha.database;

using EPaczuchaWeb.Models;

namespace EPaczuchaWeb
{
    public class UserMapper
    {
        IMapper _mapper;

        public UserMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Customer, CustomerViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        public CustomerViewModel Map(Customer user)
        {
            return _mapper.Map<CustomerViewModel>(user);
        }

        public Customer Map(CustomerViewModel user)
        {
            return _mapper.Map<Customer>(user);
        }
    }
}
