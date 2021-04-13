using ProjectBL;
using ProjectModels;
using ProjectREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class UserProjectControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public UserProjectControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetUserProjectsAsyncShouldReturnUserProjects()
        {
            //arrange
            UserProject userProject = new UserProject();
            _projectBLMock.Setup(i => i.GetUserProjectsAsync());
            UserProjectController userProjectController = new UserProjectController(_projectBLMock.Object);

            //act 
            var result = await userProjectController.GetUserProjectsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetUserProjectByIdShouldGetUserProject()
        {
            var userProjectId = 1;
            var userProject = new UserProject { Id = userProjectId };
            _projectBLMock.Setup(x => x.GetUserProjectByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(userProject));
            var userProjectController = new UserProjectController(_projectBLMock.Object);
            var result = await userProjectController.GetUserProjectByIDAsync(userProjectId);
            Assert.Equal(userProjectId, ((UserProject)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetUserProjectByIDAsync(userProjectId));
        }
        [Fact]
        public async Task AddUserProjectShouldAddUserProject()
        {
            var userProject = new UserProject();
            _projectBLMock.Setup(x => x.AddUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult<UserProject>(userProject));
            var userProjectController = new UserProjectController(_projectBLMock.Object);
            var result = await userProjectController.AddUserProjectAsync(new UserProject());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddUserProjectAsync((It.IsAny<UserProject>())));
        }
        [Fact]
        public async Task DeleteUserShouldDeleteUser()
        {
            var userProject = new UserProject { Id = 1 };
            _projectBLMock.Setup(x => x.DeleteUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult<UserProject>(userProject));
            var userProjectController = new UserProjectController(_projectBLMock.Object);
            var result = await userProjectController.DeleteUserProjectAsync(userProject.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteUserProjectAsync((It.IsAny<UserProject>())));
        }
        [Fact]
        public async Task UpdateUserProjectShouldUpdateUserProject()
        {
            var userProject = new UserProject { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult(userProject));
            var userProjectController = new UserProjectController(_projectBLMock.Object);
            var result = await userProjectController.UpdateUserProjectAsync(userProject.Id, userProject);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateUserProjectAsync(userProject));

        }

    }
}
