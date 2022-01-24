
using EPaczucha.core;

using EPaczuchaWeb.Controllers;

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

            var result = home.Index();

            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<IActionResult>(result);

            mock.Verify(v => v.AddDefaultPackageType(true), Times.Once());
            mock.Verify(v => v.AddDefaultSendMethod(true), Times.Once());
        }
    }
}