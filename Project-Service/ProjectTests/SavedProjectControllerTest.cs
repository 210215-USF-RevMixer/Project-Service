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
    public class SavedProjectControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public SavedProjectControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetSavedProjectsAsyncShouldReturnSavedProjects()
        {
            //arrange
            SavedProject savedProject = new SavedProject();
            _projectBLMock.Setup(i => i.GetSavedProjectsAsync());
            SavedProjectController savedProjectController = new SavedProjectController(_projectBLMock.Object);

            //act 
            var result = await savedProjectController.GetSavedProjectsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetSavedProjectByIdShouldGetSavedProject()
        {
            var savedProjectId = 1;
            var savedProject = new SavedProject { Id = savedProjectId };
            _projectBLMock.Setup(x => x.GetSavedProjectByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(savedProject));
            var savedProjectController = new SavedProjectController(_projectBLMock.Object);
            var result = await savedProjectController.GetSavedProjectByIDAsync(savedProjectId);
            Assert.Equal(savedProjectId, ((SavedProject)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetSavedProjectByIDAsync(savedProjectId));
        }
        [Fact]
        public async Task AddSavedProjectShouldAddSavedProject()
        {
            var savedProject = new SavedProject();
            _projectBLMock.Setup(x => x.AddSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult<SavedProject>(savedProject));
            var savedProjectController = new SavedProjectController(_projectBLMock.Object);
            var result = await savedProjectController.AddSavedProjectAsync(new SavedProject());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddSavedProjectAsync((It.IsAny<SavedProject>())));
        }
        [Fact]
        public async Task DeleteUserShouldDeleteUser()
        {
            var savedProject = new SavedProject { Id = 1 };
            _projectBLMock.Setup(x => x.DeleteSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult<SavedProject>(savedProject));
            var savedProjectController = new SavedProjectController(_projectBLMock.Object);
            var result = await savedProjectController.DeleteSavedProjectAsync(savedProject.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteSavedProjectAsync((It.IsAny<SavedProject>())));
        }
        [Fact]
        public async Task UpdateSavedProjectShouldUpdateSavedProject()
        {
            var savedProject = new SavedProject { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult(savedProject));
            var savedProjectController = new SavedProjectController(_projectBLMock.Object);
            var result = await savedProjectController.UpdateSavedProjectAsync(savedProject.Id, savedProject);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateSavedProjectAsync(savedProject));

        }

    }
}
