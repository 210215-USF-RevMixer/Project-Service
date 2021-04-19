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
    public class UsersSampleSetsControllerTests
    {
        private Mock<IProjectBL> _projectBLMock;

        public UsersSampleSetsControllerTests()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }

        [Fact]
        public async Task GetUsersSampleSetsAsync_ShouldReturnOKObject()
        {
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            _projectBLMock.Setup(i => i.GetUsersSampleSetsAsync());
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.GetUsersSampleSetsAsync();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleSetsByIDAsync_ShouldReturnOkObjectResult_WhenIDIsValid()
        {
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            int id = 1;
            _projectBLMock.Setup(i => i.GetUsersSampleSetsByIDAsync(id)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.GetUsersSampleSetsByIDAsync(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleSetsByIDAsync_ShouldReturnNotFound_WhenUserSampleSetsIsInvalid()
        {
            UsersSampleSets usersSampleSets = null;
            int id = -2;
            _projectBLMock.Setup(i => i.GetUsersSampleSetsByIDAsync(id)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.GetUsersSampleSetsByIDAsync(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleSetsByUserIDAsync_ShouldReturnOkObject_WhenIDIsValid()
        {
            List<UsersSampleSets> usersSampleSets = new List<UsersSampleSets>();
            int id = 1;
            _projectBLMock.Setup(i => i.GetUsersSampleSetsByUserIDAsync(id)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.GetUsersSampleSetsByUserIDAsync(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetUsersSampleSetsByUserIDAsync_ShouldReturnNotFound_WhenUserSampleSetsIsInvalid()
        {
            List<UsersSampleSets> usersSampleSets = null;
            int id = -21;
            _projectBLMock.Setup(i => i.GetUsersSampleSetsByUserIDAsync(id)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.GetUsersSampleSetsByUserIDAsync(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AddUsersSampleSetsAsync_ShouldReturnCreatedAtAction_WhenUsersSampleSetsIsValid()
        {
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            _projectBLMock.Setup(i => i.AddUsersSampleSetsAsync(usersSampleSets)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.AddUsersSampleSetsAsync(usersSampleSets);

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task AddUsersSampleSetsAsync_ShouldReturnStatusCode400_WhenUsersSampleSetsIsInvalid()
        {
            UsersSampleSets usersSampleSets = null;
            _projectBLMock.Setup(i => i.AddUsersSampleSetsAsync(usersSampleSets)).Throws(new Exception());
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.AddUsersSampleSetsAsync(usersSampleSets);

            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task UpdateUsersSampleSetsAsync_ShouldReturnNoContent_WhenIDAndUserSampleSetsAreValid()
        {
            int id = 1;
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            _projectBLMock.Setup(i => i.UpdateUsersSampleSetsAsync(usersSampleSets)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.UpdateUsersSampleSetsAsync(id, usersSampleSets);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateUsersSampleSetsAsync_ShouldReturnStatusCode500_WhenInvalid()
        {
            int id = -1;
            UsersSampleSets usersSampleSets = null;
            _projectBLMock.Setup(i => i.UpdateUsersSampleSetsAsync(usersSampleSets)).Throws(new Exception());
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.UpdateUsersSampleSetsAsync(id, usersSampleSets);

            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task DeleteUsersSampleSetsAsync_ShouldReturnNoContent_WhenIDIsValid()
        {
            int id = 1;
            UsersSampleSets usersSampleSets = new UsersSampleSets();
            _projectBLMock.Setup(i => i.DeleteUsersSampleSetsAsync(usersSampleSets)).ReturnsAsync(usersSampleSets);
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.DeleteUsersSampleSetsAsync(id);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteUsersSampleSetsAsync_ShouldReturnStatusCode500_WhenIDIsInvalid()
        {
            int id = -1;
            UsersSampleSets usersSampleSets = null;
            _projectBLMock.Setup(i => i.DeleteUsersSampleSetsAsync(usersSampleSets)).Throws(new Exception());
            UsersSampleSetsController usersSampleSetsController = new UsersSampleSetsController(_projectBLMock.Object);

            var result = await usersSampleSetsController.DeleteUsersSampleSetsAsync(id);

            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
    }
}
