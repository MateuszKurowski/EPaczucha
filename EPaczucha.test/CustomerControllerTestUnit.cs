using EPaczucha.core;

using EPaczuchaWeb;
using EPaczuchaWeb.Controllers;
using EPaczuchaWeb.Models;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace EPaczucha.test
{
    public class CustomerControllerTestUnit
    {
        [Fact]
        public void IndextTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();

            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Index();

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();
        }

        [Fact]
        public void DetailsTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Details(1);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.GetCustomers(null), Times.Once());
        }

        [Fact]
        public void EditTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Edit(1);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.GetCustomers(null), Times.Once());
        }

        [Fact]
        public void EditPostTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Edit(new CustomerViewModel() {  Id = 1 });

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<RedirectToActionResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.EditCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Delete(1);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<RedirectToActionResult>();
            resultController.Should().BeAssignableTo<IActionResult>();


            mock.Verify(v => v.DeleteCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }

        [Fact]
        public void AddTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Add();

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();
        }

        [Fact]
        public void AddPostTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var customer = new CustomerController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = customer.Add(new CustomerViewModel() { Id = 1 });

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<RedirectToActionResult>();
            resultController.Should().BeAssignableTo<IActionResult>();


            mock.Verify(v => v.AddNewCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }
    }
}