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
    public class SampleSetsControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public SampleSetsControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
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
        public async Task AddSampleSetsShouldAddSampleSets()
        {
            var sample = new SampleSets();
            _projectBLMock.Setup(x => x.AddSampleSetsAsync(It.IsAny<SampleSets>())).Returns(Task.FromResult<SampleSets>(sample));
            var sampleController = new SampleSetsController(_projectBLMock.Object);
            var result = await sampleController.AddSampleSetsAsync(new SampleSets());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddSampleSetsAsync((It.IsAny<SampleSets>())));
        }
          [Fact]
        public async Task DeleteSampleSetsShouldDeleteSampleSets()
        {
            var sample = new SampleSets{Id = 1};
            _projectBLMock.Setup(x => x.DeleteSampleSetsAsync(It.IsAny<SampleSets>())).Returns(Task.FromResult<SampleSets>(sample));
            var sampleController = new SampleSetsController(_projectBLMock.Object);
            var result = await sampleController.DeleteSampleSetsAsync(sample.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteSampleSetsAsync((It.IsAny<SampleSets>())));
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
     
    }
}
