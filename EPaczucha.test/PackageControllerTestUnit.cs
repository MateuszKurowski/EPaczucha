using EPaczucha.core;

using EPaczuchaWeb;
using EPaczuchaWeb.Models;
using EPaczuchaWeb.Controllers;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using FluentAssertions;
using EPaczucha.database;
using System.Collections.Generic;

namespace EPaczucha.test
{
    public class PackageControllerTestUnit
    {
        [Fact]
        public void IndextTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();

            var package = new PackageController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = package.Index(1, null);

            //Assert

            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.GetPackagesByCustomer(It.IsAny<int>(), null), Times.Once());
        }

        [Fact]
        public void AddTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var package = new PackageController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = package.Add(1);

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
            var typeViewModel = new PackageTypeViewModel() { Id = 1, Price = 3 };
            var SendViewModel = new SendMethodViewModel() { Id = 1, Price = 3 };
            var packageViewModel = new PackageViewModel() { Id = 1, PackageType = new PackageTypeViewModel { Id = 1, Price = 3 }, SendMethod = new SendMethodViewModel() { Id = 1, Price = 3 } };
            var list = new List<CustomerDto>();
            list.Add(new CustomerDto { Id = 1 });

            mock.Setup(m => m.GetPriceFromPackageType(1)).Returns(typeViewModel.Price);
            mock.Setup(m => m.GetPriceFromSendMethod(1)).Returns(SendViewModel.Price);

            mock.Setup(m => m.GetCustomers(null)).Returns(list);



            var package = new PackageController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = package.Add(packageViewModel, 1);

            //Assert

            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<RedirectToActionResult>();
            resultController.Should().BeAssignableTo<IActionResult>();
        }

        [Fact]
        public void DetailsTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var mapper = new Mock<MapperViewModel>();
            var packageViewModel = new PackageViewModel() { Id = 1, SendMethod = new SendMethodViewModel() { Id = 1, MethodName = "Test" }, PackagePrice = new PackagePriceViewModel { Id = 1, Gross = 29.0M }, PackageType = new PackageTypeViewModel { Id = 1, TypeName = "Test" } };
            var packageDto = new PackageDto() { Id = 1, SendMethod = new SendMethodDto() { Id = 1, MethodName = "Test" }, PackagePrice = new PackagePriceDto { Id = 1, Gross = 29.0M }, PackageType = new PackageTypeDto { Id = 1, TypeName = "Test" } };
            mock.Setup(m => m.GetPackageById(1)).Returns(packageDto);
            var package = new PackageController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = package.Details(1, 1);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.GetPackageById(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void DeleteTest()
        {
            //Arrange
            var mock = new Mock<IManagerDto>();
            var package = new PackageController(new MapperViewModel(), mock.Object);

            //Art
            var resultController = package.Delete(1, 1);

            //Assert
            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<RedirectToActionResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.DeletePackage(It.IsAny<PackageDto>()), Times.Once());
        }
    }
}