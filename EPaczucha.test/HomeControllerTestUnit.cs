using EPaczucha.core;

using EPaczuchaWeb.Controllers;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;

namespace EPaczucha.test
{
    public class HomeControllerTestUnit
    {
        [Fact]
        public void IndextTest()
        {
            var mock = new Mock<IManagerDto>();

            var home = new HomeController(mock.Object);

            var resultController = home.Index();

            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.AddDefaultPackageType(true), Times.Once());
            mock.Verify(v => v.AddDefaultSendMethod(true), Times.Once());
        }
    }
}