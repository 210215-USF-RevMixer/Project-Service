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
    public class SampleControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public SampleControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetSamplesAsyncShouldReturnSamples()
        {
            //arrange
            Sample sample = new Sample();
            _projectBLMock.Setup(i => i.GetSamplesAsync());
            SampleController sampleController = new SampleController(_projectBLMock.Object);

            //act 
            var result = await sampleController.GetSamplesAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetSampleByIdShouldGetSample()
        {
            var sampleId = 1;
            var sample = new Sample { Id = sampleId };
            _projectBLMock.Setup(x => x.GetSampleByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleController(_projectBLMock.Object);
            var result = await sampleController.GetSampleByIDAsync(sampleId);
            Assert.Equal(sampleId, ((Sample)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetSampleByIDAsync(sampleId));
        }
        [Fact]
        public async Task AddSampleShouldAddSample()
        {
            var sample = new Sample();
            _projectBLMock.Setup(x => x.AddSampleAsync(It.IsAny<Sample>(), It.IsAny<int>())).Returns(Task.FromResult<Sample>(sample));
            var sampleController = new SampleController(_projectBLMock.Object);

            var result = await sampleController.AddSampleAsync();

            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddSampleAsync(It.IsAny<Sample>(), It.IsAny<int>()));
        }

        [Fact]
        public async Task DeleteSampleShouldDeleteSample()
        {
            var sample = new Sample { Id = 1 };
            _projectBLMock.Setup(x => x.DeleteSampleAsync(It.IsAny<Sample>())).Returns(Task.FromResult<Sample>(sample));
            var sampleController = new SampleController(_projectBLMock.Object);
            var result = await sampleController.DeleteSampleAsync(sample.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteSampleAsync((It.IsAny<Sample>())));
        }
        [Fact]
        public async Task UpdateSampleShouldUpdateSample()
        {
            var sample = new Sample { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateSampleAsync(It.IsAny<Sample>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleController(_projectBLMock.Object);
            var result = await sampleController.UpdateSampleAsync(sample.Id, sample);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateSampleAsync(sample));

        }

    }
}
