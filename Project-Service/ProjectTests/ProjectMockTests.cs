using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectREST.Controllers;
using ProjectBL;
using ProjectModels;
using ProjectREST.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class ProjectMockTests
    {
        
        //[Fact]
        //public async Task AddUserProjectAsync_ShouldReturnCreatedAtActionResult_WhenUserProjectIsValid()
        //{
        //    //arrange
        //    var projectBLMock = new Mock<IProjectBL>();
        //    UserProject userProject = new UserProject();
        //    projectBLMock.Setup(i => i.AddUserProjectAsync(userProject)).ReturnsAsync(userProject);
        //    UserProjectController userProjectController = new UserProjectController(projectBLMock.Object);

        //    //act
        //    var result = await userProjectController.AddUserProjectAsync(userProject);

        //    //assert
        //    Assert.IsType<CreatedAtActionResult>(result);

        //}

        [Fact]
        public async Task AddUserProjectAsync_ShouldReturnStatusCode400_WhenUserProjectIsInvalid()
        {
            //arrange
            var projectBLMock = new Mock<IProjectBL>();
            UserProject userProject = null;
            projectBLMock.Setup(i => i.AddUserProjectAsync(userProject)).Throws(new Exception());
            UserProjectController userProjectController = new UserProjectController(projectBLMock.Object);

            //act
            var result = await userProjectController.AddUserProjectAsync(userProject);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);

        }
    }
  /**/
}
