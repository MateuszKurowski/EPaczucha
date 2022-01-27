using System.Collections.Generic;

using EPaczucha.core;

using EPaczuchaWeb;
using EPaczuchaWeb.Controllers;
using EPaczuchaWeb.Models;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
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
            var list = new List<CustomerDto>();
            var customerDto = new CustomerDto() { Id = 1, };
            list.Add(customerDto);
            var mock = new Mock<IManagerDto>();
            mock.Setup(m => m.GetCustomers(null)).Returns(list);
            var customer = new CustomerController(new MapperViewModel(), mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            //Art
            var resultController = customer.Index();

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.GetCustomers(null), Times.Once());
        }

        [Fact]
        public void DetailsTest()
        {
            //Arrange
            var list = new List<CustomerDto>();
            var customerDto = new CustomerDto() { Id = 1, };
            list.Add(customerDto);
            var mock = new Mock<IManagerDto>();
            mock.Setup(m => m.GetCustomers(null)).Returns(list);
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
            var list = new List<CustomerDto>();
            var customerDto = new CustomerDto() { Id = 1, };
            list.Add(customerDto);
            var mock = new Mock<IManagerDto>();
            mock.Setup(m => m.GetCustomers(null)).Returns(list);
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
            var resultController = customer.Edit(new CustomerViewModel() {  Id = 1 }, 1);

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
            var customer = new CustomerController(new MapperViewModel(), mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            //Art
            var resultController = customer.Delete(1);

            //Assert
            resultController.Should().NotBeNull();
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
            var customer = new CustomerController(new MapperViewModel(), mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            mock.Setup(m => m.AddNewCustomer(new CustomerDto { Id = 0 })).Returns(1);

            //Art
            var resultController = customer.Add(new CustomerViewModel() { Id = 0 });

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeAssignableTo<IActionResult>();


            mock.Verify(v => v.AddNewCustomer(It.IsAny<CustomerDto>()), Times.Once());
        }
    }
}