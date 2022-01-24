using System;
using System.Collections.Generic;

using EPaczucha.core;
using EPaczucha.database;

using FluentAssertions;

using Moq;

using Xunit;

namespace EPaczucha.test
{
    public class UnitTest1
    {
        private static readonly Mock<ICustomerRepository> _mock = new Mock<ICustomerRepository>();
        private static readonly Mock<IPackageRepository> _mock2 = new Mock<IPackageRepository>();
        private static readonly Mock<IPackageTypeRepository> _mock3 = new Mock<IPackageTypeRepository>();
        private static readonly Mock<IPackagePriceRepository> _mock4 = new Mock<IPackagePriceRepository>();
        private static readonly Mock<ISendMethodRepository> _mock5 = new Mock<ISendMethodRepository>();
        private static readonly Mock<IDestinationRepository> _mock6 = new Mock<IDestinationRepository>();
        private static readonly ManagerDto manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

        [Fact]
        public void GetCustomersTest()
        {
            var newList = new List<Customer>();
            Customer customer = new Customer()
            {
                Id = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                BuildingNumber = "13",
                City = "Kraków",
                Street = "Ulica",
                ZipCode = "30-400",
                PhoneNumber = "123456789"
            };
            newList.Add(customer);
            _mock.Setup(m => m.GetCustomers()).Returns(newList);

            var result = manager.GetCustomers(null);

            result.Should().BeOfType<List<CustomerDto>>();
            //result[0].City.Should().Equal(newList[0].City)
        }

        [Fact]
        public void GetPriceFromPackageTypeTest()
        {
            var type = new PackageType()
            {
                Id = 1,
                Price = 5.9M
            };


        }
    }
}
