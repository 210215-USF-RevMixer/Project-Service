using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectBL;
using ProjectModels;
using ProjectREST.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class TrackMockTests
    {
        [Fact]
        public async Task AddTrackAsync_ShouldReturnCreatedAtAction_WhenTrackIsValid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = new Track();
            trackBLMock.Setup(i => i.AddTrackAsync(track)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.AddTrackAsync(track);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);

        }

        [Fact]
        public async Task AddTrackAsync_ShouldReturnStatusCode400_WhenTrackIsInvalid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = null;
            trackBLMock.Setup(i => i.AddTrackAsync(track)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.AddTrackAsync(track);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnOKObjectResult()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            List<Track> tracks = new List<Track>();
            trackBLMock.Setup(i => i.GetTracksAsync());
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.GetTracksAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTrackByIDAsync_ShouldReturnOKObjectResult_WhenIDisValid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            int id = 1;
            Track track = new Track();
            trackBLMock.Setup(i => i.GetTrackByIDAsync(id)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.GetTrackByIDAsync(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTrackByIDAsync_ShouldReturnNotFound_WhenTrackIDIsInvalid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            int id = -1;
            Track track = null;
            trackBLMock.Setup(i => i.GetTrackByIDAsync(id)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.GetTrackByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateTrackAsync_ShouldReturnNoContent_WhenTrackIsValid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = new Track();
            int id = 1;
            trackBLMock.Setup(i => i.UpdateTrackAsync(track)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.UpdateTrackAsync(id, track);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateTrackAsync_ShouldReturnStatusCode500_WhenTrackIsInvalid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = null;
            int id = -1;
            trackBLMock.Setup(i => i.UpdateTrackAsync(track)).Throws(new Exception());
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.UpdateTrackAsync(id, track);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }


        [Fact]
        public async Task DeleteTrackAsync_ShouldReturnNoContent_WhenIDIsValid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = new Track();
            int id = 1;
            trackBLMock.Setup(i => i.DeleteTrackAsync(track)).ReturnsAsync(track);
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.DeleteTrackAsync(id);

            //assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteTrackAsync_ShouldReturnStatusCode500_WhenIDisInvalid()
        {
            //arrange
            var trackBLMock = new Mock<IProjectBL>();
            Track track = null;
            int id = -551;
            trackBLMock.Setup(i => i.DeleteTrackAsync(track)).Throws(new Exception());
            TrackController trackController = new TrackController(trackBLMock.Object);

            //act
            var result = await trackController.DeleteTrackAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }


        /*
         [HttpDelete("{trackID}")]
               public async Task<IActionResult> DeleteTrackAsync(int trackID)
               {
                   try
                   {
                       await _projectBL.DeleteTrackAsync(await _projectBL.GetTrackByIDAsync(trackID));
                       return NoContent();
                   }
                   catch
                   {
                       return StatusCode(500);
                   } */




        /*
         * NULLREFERENCEEXCEPTION *
    public async Task<IActionResult> AddTrackAsync([FromBody] Track track)
    {
       
        catch (Exception e)
        {
            Log.Logger.Error($"Error thrown: {e.Message}");
            return StatusCode(400);
        }
    }*/
    }
}
