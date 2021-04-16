using Moq;
using ProjectREST.Controllers;
using ProjectBL;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProjectREST.Controllers;
using ProjectDL;

namespace ProjectTests
{
    public class SavedProjectMockTests
    {
        private Mock<IProjectRepoDB> _projectBLMock;
        public SavedProjectMockTests()
        {
            _projectBLMock = new Mock<IProjectRepoDB>();
        }

        [Fact]
        public async Task GetSavedProjectsAsync_ShouldReturnSavedProjects()
        {
            //arrange
            var savedProjects = new List<SavedProject> { new SavedProject() { Id = 1 } };
            _projectBLMock.Setup(i => i.GetSavedProjectsAsync());
            var newProjBL = new ProjBL(_projectBLMock.Object);

            //act
            var result = await newProjBL.GetSavedProjectsAsync();

            //assert
            Assert.Single(savedProjects);
            _projectBLMock.Verify(i => i.GetSavedProjectsAsync());
        }

        [Fact]
        public async Task GetSavedProjectsByIDAsync_ShouldReturnSavedProject_WhenIdIsValid()
        {
            //arrange
            var savedProjID = 1;
            var newSavedProj = new SavedProject();
            _projectBLMock.Setup(i => i.GetSavedProjectByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<SavedProject>(newSavedProj));
            var newProjBL = new ProjBL(_projectBLMock.Object);

            //act
            var result = await newProjBL.GetSavedProjectByIDAsync(savedProjID);

            //assert
            Assert.Equal(newSavedProj, result);
            _projectBLMock.Verify(i => i.GetSavedProjectByIDAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task AddSavedProjectAsync_ShouldReturnNewSavedProject_WhenSavedProjectIsValid()
        {
            //arrange
            var newSavedProj = new SavedProject();
            _projectBLMock.Setup(i => i.AddSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult<SavedProject>(newSavedProj));
            var newProjBL = new ProjBL(_projectBLMock.Object);

            //act
            var result = await newProjBL.AddSavedProjectAsync(newSavedProj);

            //assert
            Assert.Equal(newSavedProj, result);
            _projectBLMock.Verify(i => i.AddSavedProjectAsync(It.IsAny<SavedProject>()));
        }

        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnProject2BDeleted_WhenSavedProjectIsValid()
        {
            //arrange
            var newSavedProject = new SavedProject();
            _projectBLMock.Setup(i => i.DeleteSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult<SavedProject>(newSavedProject));
            var newProjBL = new ProjBL(_projectBLMock.Object);

            //act
            var result = await newProjBL.DeleteSavedProjectAsync(newSavedProject);

            //assert
            Assert.Equal(newSavedProject, result);
            _projectBLMock.Verify(i => i.DeleteSavedProjectAsync(It.IsAny<SavedProject>()));
        }

        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnOldSavedProject_WhenSavedProjectIsValid()
        {
            //arrange
            var newSavedProj = new SavedProject();
            _projectBLMock.Setup(i => i.UpdateSavedProjectAsync(It.IsAny<SavedProject>())).Returns(Task.FromResult<SavedProject>(newSavedProj));
            var newProjBL = new ProjBL(_projectBLMock.Object);

            //act
            var result = await newProjBL.UpdateSavedProjectAsync(newSavedProj);

            //assert
            Assert.Equal(newSavedProj, result);
            _projectBLMock.Verify(i => i.UpdateSavedProjectAsync(It.IsAny<SavedProject>()));
        }
        //[Fact]
        //public async Task GetSavedProjectsAsync_ShouldReturnOkObjectResult()
        //{
        //    //arrange
        //    var savedprojectBLMock = new Mock<IProjectBL>();
        //    List<SavedProject> savedProjects = new List<SavedProject>();
        //    savedprojectBLMock.Setup(i => i.GetSavedProjectsAsync()).ReturnsAsync(savedProjects);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedprojectBLMock.Object);
        

        //    //act
        //    var result = await savedProjectController.GetSavedProjectsAsync();

        //    //assert
        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public async Task GetSavedProjectByIDAsync_ShouldReturnOkObjectResult_WhenIDisValid()
        //{
        //    //arrange
        //    var savedProjectBLMock = new Mock<IProjectBL>();
        //    int id = 1;
        //    SavedProject savedProject = new SavedProject();
        //    savedProjectBLMock.Setup(i => i.GetSavedProjectByIDAsync(id)).ReturnsAsync(savedProject);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

        //    //act
        //    var result = await savedProjectController.GetSavedProjectByIDAsync(id);

        //    //assert
        //    Assert.IsType<OkObjectResult>(result);

        //}

        [Fact]
        public async Task GetSavedProjectByIDAsync_ShouldReturnNotFound_WhenIDIsInvalid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            int id = -41;
            SavedProject savedProject = null;
            savedProjectBLMock.Setup(i => i.GetSavedProjectByIDAsync(id)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.GetSavedProjectByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);

        }

        //[Fact]
        //public async Task AddSavedProjectAsync_ShouldReturnCreatedAtActionResult_WhenSavedProjectIsValid()
        //{
        //    //arrange
        //    var savedProjectBLMock = new Mock<IProjectBL>();
        //    SavedProject savedProject = new SavedProject();
        //    savedProjectBLMock.Setup(i => i.AddSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

        //    //act
        //    var result = await savedProjectController.AddSavedProjectAsync(savedProject);

        //    //assert
        //    Assert.IsType<CreatedAtActionResult>(result);
        //}

        [Fact]
        public async Task AddSavedProjectAsync_ShouldReturnStatusCode400_WhenSavedProjectIsInvalid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            SavedProject savedProject = null;
            savedProjectBLMock.Setup(i => i.AddSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.AddSavedProjectAsync(savedProject);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }

        

        //[Fact]
        //public async Task UpdateSavedProjectAsync_ShouldReturnNoContent_WhenSavedProjectAndIdAreValid()
        //{
        //    //arrange
        //    var savedProjectBLMock = new Mock<IProjectBL>();
        //    int id = 1;
        //    SavedProject savedProject = new SavedProject();
        //    savedProjectBLMock.Setup(i => i.UpdateSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

        //    //act
        //    var result = await savedProjectController.UpdateSavedProjectAsync(id, savedProject);

        //    //assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnStatusCode500_WhenSavedProjectIsInvalid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            int id = -1;
            SavedProject savedProject = null;
            savedProjectBLMock.Setup(i => i.UpdateSavedProjectAsync(savedProject)).Throws(new Exception());
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.UpdateSavedProjectAsync(id, savedProject);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
   
        //[Fact]
        //public async Task DeleteSavedProjectAsync_ShouldReturnNoContent_WhenIDIsValid()
        //{
        //    //arrange
        //    var savedprojectBLMock = new Mock<IProjectBL>();
        //    int id = 1;
        //    SavedProject savedProject = new SavedProject();
        //    savedprojectBLMock.Setup(i => i.DeleteSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedprojectBLMock.Object);

        //    //act
        //    var result = await savedProjectController.DeleteSavedProjectAsync(id);

        //    //assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnStatusCode500_WhenIdIsInvalid()
        {
            //arrange
            var savedprojectBLMock = new Mock<IProjectBL>();
            int id = -4;
            SavedProject savedProject = null;
            savedprojectBLMock.Setup(i => i.DeleteSavedProjectAsync(savedProject)).Throws(new Exception());
            SavedProjectController savedProjectController = new SavedProjectController(savedprojectBLMock.Object);

            //act
            var result = await savedProjectController.DeleteSavedProjectAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
    }




}
