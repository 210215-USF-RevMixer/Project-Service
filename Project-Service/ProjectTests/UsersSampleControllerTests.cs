using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectBL;
using ProjectModels;
using ProjectREST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class UsersSampleControllerTests
    {
        private Mock<IProjectBL> _projectBLMock;

        public UsersSampleControllerTests()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetUsersSampleAsync_ShouldReturnOKObjectResult()
        {
            //arrange
            UsersSample usersSample = new UsersSample();
            _projectBLMock.Setup(i => i.GetUsersSamplesAsync());
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.GetUsersSamplesAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleByUserIDAsync_ShouldReturnOkResult_WhenIDIsValid()
        {
            //arrange
            List<UsersSample> usersSamples = new List<UsersSample>();
            int userID = 1;
            _projectBLMock.Setup(i => i.GetUsersSampleByUserIDAsync(userID)).ReturnsAsync(usersSamples);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.GetUsersSampleByUserIDAsync(userID);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetUsersSampleByUserIDAsync_ShouldReturnNotFound_WhenUsersSampleIsNull()
        {
            //arrange
            int id = -1;
            UsersSample usersSample = null;
            _projectBLMock.Setup(i => i.GetUsersSampleByIDAsync(id)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.GetUsersSampleByUserIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetUsersSampleByIDAsync_ShouldReturnOKObject_WhenIDIsValid()
        {
            //arrange
            int id = 1;
            UsersSample usersSample = new UsersSample();
            _projectBLMock.Setup(i => i.GetUsersSampleByIDAsync(id)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.GetUsersSampleByIDAsync(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleByIDAsync_ShouldReturnNotFound_WhenUserSampleIsNull()
        {
            //arrange
            int id = -2;
            UsersSample usersSample = null;
            _projectBLMock.Setup(i => i.GetUsersSampleByIDAsync(id)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.GetUsersSampleByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
        
        [Fact]
        public async Task AddUsersSampleAsync_ShouldReturnCreatedAtAction_WhenUsersSampleIsValid()
        {
            //arrange
            UsersSample usersSample = new UsersSample();
            _projectBLMock.Setup(i => i.AddUsersSampleAsync(usersSample)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.AddUsersSampleAsync(usersSample);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task AddUsersSampleAsync_ShouldReturnStatusCode400_WhenUsersSampleIsInvalid()
        {
            //arrange
            UsersSample usersSample = null;
            _projectBLMock.Setup(i => i.AddUsersSampleAsync(usersSample)).Throws(new Exception());
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.AddUsersSampleAsync(usersSample);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task UpdateUsersSampleAsync_ShouldReturnNoContent_WhenUsersSampleIsValid()
        {
            //arrange
            int id = 1;
            UsersSample usersSample = new UsersSample();
            _projectBLMock.Setup(i => i.UpdateUsersSampleAsync(usersSample)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.UpdateUsersSampleAsync(id, usersSample);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateUsersSampleAsync_ShouldReturnStatusCode500_WhenUsersSampleIsInvalid()
        {
            //arrange
            int id = -2;
            UsersSample usersSample = null;
            _projectBLMock.Setup(i => i.UpdateUsersSampleAsync(usersSample)).Throws(new Exception());
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            //act
            var result = await usersSampleController.UpdateUsersSampleAsync(id, usersSample);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
        [Fact]
        public async Task DeleteUsersSampleAsync_ShouldReturnNoContent_WhenIDIsValid()
        {
            int id = 1;
            UsersSample usersSample = new UsersSample();
            _projectBLMock.Setup(i => i.DeleteUsersSampleAsync(usersSample)).ReturnsAsync(usersSample);
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            var result = await usersSampleController.DeleteUsersSampleAsync(id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUsersSampleAsync_ShouldReturnStatusCode500_WhenUserSampleIsInvalid()
        {
            int id = -1;
            UsersSample usersSample = null;
            _projectBLMock.Setup(i => i.DeleteUsersSampleAsync(usersSample)).Throws(new Exception());
            UsersSampleController usersSampleController = new UsersSampleController(_projectBLMock.Object);

            var result = await usersSampleController.DeleteUsersSampleAsync(id);

            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
    }
}
