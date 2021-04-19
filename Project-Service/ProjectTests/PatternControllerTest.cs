using ProjectBL;
using ProjectModels;

using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjectREST.Controllers;

namespace ProjectTests
{
    public class PatternControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public PatternControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetPatternsAsyncShouldReturnPatterns()
        {
            //arrange
            Pattern pattern = new Pattern();
            _projectBLMock.Setup(i => i.GetPatternsAsync());
            PatternController patternController = new PatternController(_projectBLMock.Object);

            //act 
            var result = await patternController.GetPatternsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetPatternByIdShouldGetPattern()
        {
            var patternId = 1;
            var pattern = new Pattern { Id = patternId };
            _projectBLMock.Setup(x => x.GetPatternByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(pattern));
            var patternController = new PatternController(_projectBLMock.Object);
            var result = await patternController.GetPatternByIDAsync(patternId);
            Assert.Equal(patternId, ((Pattern)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetPatternByIDAsync(patternId));
        }

        [Fact]
        public async Task GetPatternByIdAsync_ShouldReturnNotFound_WhenPatternIsNull()
        {
            //arrange
            var patternID = 1;
            Pattern pattern = null;
            _projectBLMock.Setup(i => i.GetPatternByIDAsync(patternID)).ReturnsAsync(pattern);
            PatternController patternController = new PatternController(_projectBLMock.Object);

            //act
            var result = await patternController.GetPatternByIDAsync(patternID);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }
     
        [Fact]
        public async Task AddPatternShouldAddPattern()
        {
            var pattern = new Pattern();
            _projectBLMock.Setup(x => x.AddPatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult<Pattern>(pattern));
            var patternController = new PatternController(_projectBLMock.Object);
            var result = await patternController.AddPatternAsync(new Pattern());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddPatternAsync((It.IsAny<Pattern>())));
        }

        [Fact]
        public async Task AddPatternAsync_ShouldReturnStatusCode400_WhenPatternIsInvalid()
        {
            //arrange
            Pattern pattern = null;
            _projectBLMock.Setup(i => i.AddPatternAsync(pattern)).Throws(new Exception());
            PatternController patternController = new PatternController(_projectBLMock.Object);

            //act
            var result = await patternController.AddPatternAsync(pattern);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }
  
        /**/

        [Fact]
        public async Task DeletePatternShouldDeletePattern()
        {
            var pattern = new Pattern { Id = 1 };
            _projectBLMock.Setup(x => x.DeletePatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult<Pattern>(pattern));
            var patternController = new PatternController(_projectBLMock.Object);
            var result = await patternController.DeletePatternAsync(pattern.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeletePatternAsync((It.IsAny<Pattern>())));
        }

        [Fact]
        public async Task DeletePatternAsync_ShouldReturnStatusCode500_WhenPatternIsInvalid() 
        {
            //arrange
            int id = 1;
            Pattern pattern = null;
            _projectBLMock.Setup(i => i.DeletePatternAsync(pattern)).Throws(new Exception());
            PatternController patternController = new PatternController(_projectBLMock.Object);

            //act
            var result = await patternController.DeletePatternAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task UpdatePatternShouldUpdatePattern()
        {
            var pattern = new Pattern { Id = 1 };
            _projectBLMock.Setup(x => x.UpdatePatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult(pattern));
            var patternController = new PatternController(_projectBLMock.Object);
            var result = await patternController.UpdatePatternAsync(pattern.Id, pattern);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdatePatternAsync(pattern));

        }

        [Fact]
        public async Task UpdatePatternAsync_ShouldReturnStatusCode500_WhenPatternIsInvalid()
        {
            //assert
            int id = 1;
            Pattern pattern = null;
            _projectBLMock.Setup(i => i.UpdatePatternAsync(pattern)).Throws(new Exception());
            PatternController patternController = new PatternController(_projectBLMock.Object);

            //act
            var result = await patternController.UpdatePatternAsync(id, pattern);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);

        }


      
    }
}