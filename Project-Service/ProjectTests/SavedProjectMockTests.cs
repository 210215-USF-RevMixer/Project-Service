using Moq;
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

namespace ProjectTests
{
    public class SavedProjectMockTests
    {
        [Fact]
        public async Task GetSavedProjectsAsync_ShouldReturnOkObjectResult()
        {
            //arrange
            var savedprojectBLMock = new Mock<IProjectBL>();
            List<SavedProject> savedProjects = new List<SavedProject>();
            savedprojectBLMock.Setup(i => i.GetSavedProjectsAsync()).ReturnsAsync(savedProjects);
            SavedProjectController savedProjectController = new SavedProjectController(savedprojectBLMock.Object);
        

            //act
            var result = await savedProjectController.GetSavedProjectsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetSavedProjectByIDAsync_ShouldReturnOkObjectResult_WhenIDisValid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            int id = 1;
            SavedProject savedProject = new SavedProject();
            savedProjectBLMock.Setup(i => i.GetSavedProjectByIDAsync(id)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.GetSavedProjectByIDAsync(id);

            //assert
            Assert.IsType<OkObjectResult>(result);

        }

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

        [Fact]
        public async Task AddSavedProjectAsync_ShouldReturnCreatedAtActionResult_WhenSavedProjectIsValid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            SavedProject savedProject = new SavedProject();
            savedProjectBLMock.Setup(i => i.AddSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.AddSavedProjectAsync(savedProject);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

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
        //public async Task AddSavedProjectAsync_ShouldReturnNullReferenceException_WhenNull()
        //{
        //    //arrange
        //    var savedProjectBLMock = new Mock<IProjectBL>();
        //    SavedProject savedProject = null;
        //    savedProjectBLMock.Setup(i => i.AddSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
        //    SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

        //    //act
        //    var result = await savedProjectController.AddSavedProjectAsync(savedProject);
        //    NullReferenceException nullReference = Assert.
        //}
        /*public async Task<IActionResult> AddSavedProjectAsync([FromBody] SavedProject userProject)
        {
            try
            {
                await _projectBL.AddSavedProjectAsync(userProject);
                Log.Logger.Information($"new SavedProject with ID {userProject.Id} created");
                return CreatedAtAction("AddSavedProject", userProject);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }*/

        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnNoContent_WhenSavedProjectAndIdAreValid()
        {
            //arrange
            var savedProjectBLMock = new Mock<IProjectBL>();
            int id = 1;
            SavedProject savedProject = new SavedProject();
            savedProjectBLMock.Setup(i => i.UpdateSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedProjectBLMock.Object);

            //act
            var result = await savedProjectController.UpdateSavedProjectAsync(id, savedProject);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

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
   
        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnNoContent_WhenIDIsValid()
        {
            //arrange
            var savedprojectBLMock = new Mock<IProjectBL>();
            int id = 1;
            SavedProject savedProject = new SavedProject();
            savedprojectBLMock.Setup(i => i.DeleteSavedProjectAsync(savedProject)).ReturnsAsync(savedProject);
            SavedProjectController savedProjectController = new SavedProjectController(savedprojectBLMock.Object);

            //act
            var result = await savedProjectController.DeleteSavedProjectAsync(id);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

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
