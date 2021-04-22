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
        public async Task GetSampleByIDAsync_ShouldReturnNotFound_WhenSampleIsInvalid()
        {
            //arrange
            int id = -2;
            Sample sample = null;
            _projectBLMock.Setup(i => i.GetSampleByIDAsync(id)).ReturnsAsync(sample);
            SampleController sampleController = new SampleController(_projectBLMock.Object);

            //act
            var result = await sampleController.GetSampleByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);

        }
        //[Fact]
        //public async Task AddSampleAsync_ShouldReturnCreatedAtAction()
        //{
        //    //arrange
        //    int id = 1;
        //    Sample sample = new Sample();
        //    _projectBLMock.Setup(i => i.AddSampleAsync(sample, id)).ReturnsAsync(sample);
        //    SampleController sampleController = new SampleController(_projectBLMock.Object);

        //    //act
        //    var result = await sampleController.AddSampleAsync();

        //    //assert
        //    Assert.IsType<CreatedAtActionResult>(result);
        //}


        [Fact]
        public async Task AddSampleAsync_ShouldReturnStatusCode400_WhenInvalid()
        {
            //arrange
            int id = -1;
            Sample sample = null;
            _projectBLMock.Setup(i => i.AddSampleAsync(sample, id)).Throws(new Exception());
            SampleController sampleController = new SampleController(_projectBLMock.Object);

            //act
            var result = await sampleController.AddSampleAsync();

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }
        /*public async Task<IActionResult> AddSampleAsync()
                {
                    try
                    {
                        Sample sample2Send = new Sample();
                        sample2Send.SampleName = Request.Form["sampleName"];
                        sample2Send.SampleLink = Request.Form["sampleLink"];
                        sample2Send.Id = 0;
                        sample2Send.IsApproved = true;
                        sample2Send.IsLocked = false;
                        sample2Send.IsPrivate = false;
                        string userId = Request.Form["userId"];
                        await _projectBL.AddSampleAsync(sample2Send, int.Parse(userId));
                        //Log.Logger.Information($"new Sample with ID {sample.Id} created");
                        return CreatedAtAction("AddSample", sample2Send);
                    }
                    catch (Exception e)
                    {
                        Log.Logger.Error($"Error thrown: {e.Message}");
                        return StatusCode(400);
                    }
                }*/

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
        public async Task DeleteSampleAsync_ShouldReturnStatusCode500_WhenSampleIsInvalid()
        {
            //arrange
            int id = -2;
            Sample sample = null;
            _projectBLMock.Setup(i => i.DeleteSampleAsync(sample)).Throws(new Exception());
            SampleController sampleController = new SampleController(_projectBLMock.Object);

            //act
            var result = await sampleController.DeleteSampleAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
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

        [Fact]
        public async Task UpdateSampleAsync_ShouldReturnStatusCode500_WhenSampleIsInvalid()
        {
            //arrange
            int id = -1;
            Sample sample = null;
            _projectBLMock.Setup(i => i.UpdateSampleAsync(sample)).Throws(new Exception());
            SampleController sampleController = new SampleController(_projectBLMock.Object);

            //act
            var result = await sampleController.UpdateSampleAsync(id, sample);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);

        }
    }
}
