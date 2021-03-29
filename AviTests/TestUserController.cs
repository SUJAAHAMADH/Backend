using AviBL;
using AviModels;
using AviREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AviTests
{
    public class TestUserController
    {
        private Mock<IAviBL> _aviBLMock;

        public TestUserController()
        {
            _aviBLMock = new Mock<IAviBL>();
        }

        [Fact]
        public async Task GetUserByEmailShouldGetUser()
        {
            var userEmail = "test@example.com";
            var user = new User { Email = userEmail };
            _aviBLMock.Setup(x => x.GetUserByEmail(It.IsAny<string>())).Returns(Task.FromResult(user));
            var userController = new UsersController( _aviBLMock.Object);
            var result = await userController.GetUserByEmail(userEmail);
            Assert.Equal(userEmail, ((User)((OkObjectResult)result).Value).Email);
            _aviBLMock.Verify(x => x.GetUserByEmail(userEmail));
        }
    }
}
