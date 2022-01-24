
using EPaczucha.core;
using EPaczucha.database;

using EPaczuchaWeb;
using EPaczuchaWeb.Controllers;
using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace EPaczucha.test
{
    public class CustomerControllerTestUnit
    {
        private static readonly Mock<ICustomerRepository> _mock = new Mock<ICustomerRepository>();
        private static readonly Mock<IPackageRepository> _mock2 = new Mock<IPackageRepository>();
        private static readonly Mock<IPackageTypeRepository> _mock3 = new Mock<IPackageTypeRepository>();
        private static readonly Mock<IPackagePriceRepository> _mock4 = new Mock<IPackagePriceRepository>();
        private static readonly Mock<ISendMethodRepository> _mock5 = new Mock<ISendMethodRepository>();
        private static readonly Mock<IDestinationRepository> _mock6 = new Mock<IDestinationRepository>();
        private static readonly Mock<IManagerDto> _Imanager = new Mock<IManagerDto>();
        private static readonly ManagerDto _manager = new ManagerDto(_mock.Object,
                          _mock2.Object,
                          _mock3.Object,
                          _mock4.Object,
                          _mock5.Object,
                          _mock6.Object,
                          new MapperDto());

        [Fact]
        public void IndextTest()
        {
            // Arange
            var mock = new Mock<IManagerDto>();

            var home = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var result = home.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DetailsTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Details(1);

            //Assert
            Assert.IsType<ViewResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);

            _Imanager.Verify(v => v.GetCustomers(null), Times.Once());
        }

        [Fact]
        public void EditTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Edit(1);

            //Assert
            Assert.IsType<ViewResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);

            _Imanager.Verify(v => v.GetCustomers(null), Times.Once());
        }

        [Fact]
        public void EditPostTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Edit(new CustomerViewModel() {  Id = 1 });

            //Assert
            Assert.IsType<RedirectToActionResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);

            _Imanager.Verify(v => v.EditCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }

        [Fact]
        public void DeleteTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Delete(1);

            //Assert
            Assert.IsType<RedirectToActionResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);

            _Imanager.Verify(v => v.DeleteCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }

        [Fact]
        public void AddTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Add();

            //Assert
            Assert.IsType<ViewResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);
        }

        [Fact]
        public void AddPostTest()
        {
            // Arange
            var home = new CustomerController(new MapperViewModel(), _Imanager.Object);

            //Art
            var resultController = home.Add(new CustomerViewModel() { Id = 1 });

            //Assert
            Assert.IsType<RedirectToActionResult>(resultController);
            Assert.IsAssignableFrom<IActionResult>(resultController);

            _Imanager.Verify(v => v.AddNewCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }
    }
}