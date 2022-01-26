using EPaczucha.core;

using EPaczuchaWeb.Controllers;

using FluentAssertions;

using Microsoft.AspNetCore.Identity;
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
            var mock2 = new Mock<UserManager<IdentityUser>>();
            var home = new HomeController(mock.Object, mock2.Object);

            var resultController = home.Index();

            resultController.Should().NotBeNull();
            resultController.Should().BeOfType<ViewResult>();
            resultController.Should().BeAssignableTo<IActionResult>();

            mock.Verify(v => v.AddDefaultPackageType(true), Times.Once());
            mock.Verify(v => v.AddDefaultSendMethod(true), Times.Once());
        }
    }
}