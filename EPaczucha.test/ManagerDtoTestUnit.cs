using System;
using System.Collections.Generic;

using EPaczucha.core;
using EPaczucha.database;

using FluentAssertions;

using Moq;

using Xunit;

namespace EPaczucha.test
{
    public class ManagerDtoTestUnit
    {
        private static readonly Mock<ICustomerRepository> _mock = new();
        private static readonly Mock<IPackageRepository> _mock2 = new();
        private static readonly Mock<IPackageTypeRepository> _mock3 = new();
        private static readonly Mock<IPackagePriceRepository> _mock4 = new();
        private static readonly Mock<ISendMethodRepository> _mock5 = new();
        private static readonly Mock<IDestinationRepository> _mock6 = new();
        private static readonly ManagerDto _manager = new(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

        [Fact]
        public void GetCustomersTest()
        {
            //Arrange
            var newList = new List<Customer>();
            var customer = new Customer()
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

            //Art
            var resultController = _manager.GetCustomers(null);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<List<CustomerDto>>();
        }

        [Fact]
        public void GetPriceFromPackageTypeTest()
        {
            //Arrange
            var type = new PackageType()
            {
                Id = 1,
                Price = 5.9M,
                Height = "5",
                Width= "1",
                TypeName = "test"
            };
            _mock3.Setup(m => m.GetById(1)).Returns(type);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetPriceFromPackageType(type.Id);

            //Assert
            result.Should().Be(type.Price);
        }

        [Fact]
        public void GetPriceFromSendMethodTest()
        {
            //Arrange
            var send = new SendMethod()
            {
                Id = 1,
                Price = 5.9M,
                MethodName = "Test"
            };
            _mock5.Setup(m => m.GetById(1)).Returns(send);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetPriceFromSendMethod(send.Id);

            //Assert
            result.Should().Be(send.Price);
        }

        [Fact]
        public void GetPackagesByCustomerTest()
        {
            //Arrange
            var newList = new List<Package>();
            var package = new Package()
            {
                Id = 1,
                CustomerId = 1
            };
            newList.Add(package);
            _mock2.Setup(m => m.GetPackage()).Returns(newList);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetPackagesByCustomer(1, null);

            //Assert
            result.Should().BeOfType<List<PackageDto>>();
        }

        [Fact]
        public void AddNewPackagesTest()
        {
            //Arrange
            var package = new Package()
            {
                Id = 1,
                CustomerId = 1,
                PackagePriceID = 1,
                DestinationId = 1,
                PackageTypeID = 1,
                SendMethodID = 1
            };
            var packageDto = new PackageDto()
            {
                Id = 1,
                CustomerId = 1,
            };
            _mock2.Setup(m => m.Create(package)).Returns(1);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.AddNewPackages(packageDto,1,1,1,1,1);

            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void AddNewCustomerTest()
        {
            //Arrange
            var customer = new CustomerDto()
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
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.AddNewCustomer(customer);

            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void DeteteCustomerTest()
        {
            //Arrange
            var customerDto = new CustomerDto()
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
            _mock.Setup(m => m.Delete(It.IsAny<Customer>()));
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.DeleteCustomer(customerDto);

            //Assert
            _mock.Verify(v => v.Delete(It.IsAny<Customer>()));
        }

        [Fact]
        public void DeletePackagesTest()
        {
            //Arrange
            var packageDto = new PackageDto()
            {
                Id = 1,
            };
            _mock2.Setup(m => m.Delete(It.IsAny<Package>()));
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.DeletePackage(packageDto);

            //Assert
            _mock2.Verify(v => v.Delete(It.IsAny<Package>()));
        }

        [Fact]
        public void GetPackageByIdTest()
        {
            //Arrange
            var package = new Package()
            {
                Id = 1,
                CustomerId = 1,
                Destination = new Destination { Id = 1},
                SendMethod = new SendMethod { Id = 1},
            };
            _mock2.Setup(m => m.GetById(1)).Returns(package);
            _mock3.Setup(m => m.GetById(1)).Returns(It.IsAny<PackageType>());
            _mock4.Setup(m => m.GetById(1)).Returns(It.IsAny<PackagePrice>());
            _mock5.Setup(m => m.GetById(1)).Returns(It.IsAny<SendMethod>());
            _mock6.Setup(m => m.GetById(1)).Returns(It.IsAny<Destination>());

            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetPackageById(1);

            //Assert
            result.Should().BeOfType<PackageDto>();
        }

        [Fact]
        public void AddNewPackagePriceTest()
        {
            //Arrange
            var packagePriceDto = new PackagePriceDto()
            {
                Id = 1,
            };
            var packagePrice = new PackagePrice()
            {
                Id = 1,
            };
            _mock4.Setup(m => m.Create(packagePrice)).Returns(1);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.AddNewPackagePrice(packagePriceDto);

            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void EditCustomerTest()
        {
            //Arrange
            var customer = new Customer()
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
            var customerDto = new CustomerDto()
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
            _mock.Setup(m => m.Update(It.IsAny<Customer>()));
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.EditCustomer(customerDto);

            //Assert
            _mock.Verify(v => v.Update(It.IsAny<Customer>()));
        }

        [Fact]
        public void AddNewDestinationTest()
        {
            //Arrange
            var destinationDto = new DestinationDto()
            {
                Id = 1,
            };
            var destination = new Destination()
            {
                Id = 1,
            };
            _mock6.Setup(m => m.Create(destination)).Returns(1);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.AddNewDestination(destinationDto);

            //Assert
            result.Should().Be(0);
        }

        [Fact]
        public void DeleteDestinationTest()
        {
            //Arrange
            var destinationDto = new DestinationDto()
            {
                Id = 1,
            };
            var destination = new Destination()
            {
                Id = 1,
            };
            _mock6.Setup(m => m.Delete(It.IsAny<Destination>()));
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.DeleteDestination(destinationDto);

            //Assert
            _mock6.Verify(v => v.Delete(It.IsAny<Destination>()));
        }

        [Fact]
        public void GetPackageTypeByIdTest()
        {
            //Arrange
            var packageTypeDto = new PackageTypeDto()
            {
                Id = 1,
            };
            var packageType = new PackageType()
            {
                Id = 1,
            };
            _mock3.Setup(m => m.GetById(1)).Returns(packageType);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetPackageTypeById(1);

            //Assert
            result.Should().BeOfType<PackageTypeDto>();
        }

        [Fact]
        public void GetSendMethodByIdTest()
        {
            //Arrange
            var sendMethodDto = new SendMethodDto()
            {
                Id = 1,
            };
            var sendMethod = new SendMethod()
            {
                Id = 1,
            };
            _mock5.Setup(m => m.GetById(1)).Returns(sendMethod);
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            var result = manager.GetSendMethodById(1);

            //Assert
            result.Should().BeOfType<SendMethodDto>();
        }

        [Fact]
        public void AddDefaultSendMethod()
        {
            //Arrange
            _mock5.Setup(m => m.GetAll()).Returns(new List<SendMethod>());
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.AddDefaultSendMethod(true);

            //Assert
            _mock5.Verify(v => v.Create(It.IsAny<SendMethod>()), Times.Exactly(3));
        }

        [Fact]
        public void AddDefaultPackageTypeTest()
        {
            //Arrange
            _mock3.Setup(m => m.GetAll()).Returns(new List<PackageType>());
            var manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

            //Act
            manager.AddDefaultPackageType(true);

            //Assert
            _mock3.Verify(v => v.Create(It.IsAny<PackageType>()), Times.Exactly(3));
        }
    }
}