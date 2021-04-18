using ProjectBL;
using ProjectModels;
using ProjectREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Http;

namespace ProjectTests
{
    public class SampleSetsControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public SampleSetsControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetSampleSetsAsyncShouldReturnSampleSets()
        {
            //arrange
            SampleSets sample = new SampleSets();
            _projectBLMock.Setup(i => i.GetSampleSetsAsync());
            SampleSetsController sampleController = new SampleSetsController(_projectBLMock.Object);

            //act 
            var result = await sampleController.GetSampleSetsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetSampleSetsByIdShouldGetSampleSet()
        {
            var sampleId = 1;
            var sample = new SampleSets { Id = sampleId };
            _projectBLMock.Setup(x => x.GetSampleSetsByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleSetsController(_projectBLMock.Object);
            var result = await sampleController.GetSampleSetsByIDAsync(sampleId);
            Assert.Equal(sampleId, ((SampleSets)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetSampleSetsByIDAsync(sampleId));
        }

        [Fact]
        public async Task GetSampleSetsByID_ShouldReturnNotFound_WhenIDIsInvalid()
        {
            //arrange
            int id = 1;
            SampleSets sampleSets = null;
            _projectBLMock.Setup(i => i.GetSampleSetsByIDAsync(id)).ReturnsAsync(sampleSets);
            SampleSetsController sampleSetsController = new SampleSetsController(_projectBLMock.Object);

            //act
            var result = await sampleSetsController.GetSampleSetsByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
            
        }

        //[Fact]
        //public async Task AddSampleSetsShouldAddSampleSets()
        //{
        //    var sample = new SampleSets();
        //    _projectBLMock.Setup(x => x.AddSampleSetsAsync(It.IsAny<SampleSets>(), It.IsAny<int>())).Returns(Task.FromResult<SampleSets>(sample));
        //    var sampleController = new SampleSetsController(_projectBLMock.Object);

        //    var result = await sampleController.AddSampleSetsAsync();

        //    Assert.IsAssignableFrom<StatusCodeResult>(result);
        //    _projectBLMock.Verify(x => x.AddSampleSetsAsync((It.IsAny<SampleSets>()), It.IsAny<int>()));
        //}
        [Fact]
        public async Task DeleteSampleSetsShouldDeleteSampleSets()
        {
            var sample = new SampleSets { Id = 1 };
            _projectBLMock.Setup(x => x.DeleteSampleSetsAsync(It.IsAny<SampleSets>())).Returns(Task.FromResult<SampleSets>(sample));
            var sampleController = new SampleSetsController(_projectBLMock.Object);
            var result = await sampleController.DeleteSampleSetsAsync(sample.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteSampleSetsAsync((It.IsAny<SampleSets>())));
        }

        [Fact]
        public async Task DeleteSampleSets_ShouldReturnStatusCode500_WhenSampleSetsIsInvalid()
        {
            //arrange
            int id = 1;
            SampleSets sampleSets = null;
            _projectBLMock.Setup(i => i.DeleteSampleSetsAsync(sampleSets)).Throws(new Exception());
            SampleSetsController sampleSetsController = new SampleSetsController(_projectBLMock.Object);

            //act
            var result = await sampleSetsController.DeleteSampleSetsAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
        [Fact]
        public async Task UpdateSampleSetsShouldUpdateSampleSets()
        {
            var sample = new SampleSets { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateSampleSetsAsync(It.IsAny<SampleSets>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleSetsController(_projectBLMock.Object);
            var result = await sampleController.UpdateSampleSetsAsync(sample.Id, sample);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateSampleSetsAsync(sample));

        }

        [Fact]
        public async Task UpdateSampleSetsAsync_ShouldReturnStatusCode500_WhenIDIsInvalid()
        {
            //arrange
            SampleSets sampleSets = null;
            int id = 1;
            _projectBLMock.Setup(i => i.UpdateSampleSetsAsync(sampleSets)).Throws(new Exception());
            SampleSetsController sampleSetsController = new SampleSetsController(_projectBLMock.Object);

            //act
            var result = await sampleSetsController.UpdateSampleSetsAsync(id, sampleSets);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

    }
}
