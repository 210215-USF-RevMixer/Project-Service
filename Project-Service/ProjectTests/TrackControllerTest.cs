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
    public class TrackControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public TrackControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
        [Fact]
        public async Task GetTracksAsyncShouldReturnTracks()
        {
            //arrange
            Track track = new Track();
            _projectBLMock.Setup(i => i.GetTracksAsync());
            TrackController trackController = new TrackController(_projectBLMock.Object);

            //act 
            var result = await trackController.GetTracksAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetTrackByIdShouldGetTrack()
        {
            var trackId = 1;
            var track = new Track { Id = trackId };
            _projectBLMock.Setup(x => x.GetTrackByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(track));
            var trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.GetTrackByIDAsync(trackId);
            Assert.Equal(trackId, ((Track)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetTrackByIDAsync(trackId));
        }

        [Fact]
        public async Task GetTrackByIDAsync_ShouldReturnNotFound_WhenTrackIsNull()
        {
            int id = -1;
            Track track = null;
            _projectBLMock.Setup(i => i.GetTrackByIDAsync(id)).ReturnsAsync(track);
            TrackController trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.GetTrackByIDAsync(id);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task AddTrackShouldAddTrack()
        {
            var track = new Track();
            _projectBLMock.Setup(x => x.AddTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult<Track>(track));
            var trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.AddTrackAsync(new Track());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddTrackAsync((It.IsAny<Track>())));
        }
        [Fact]
        public async Task AddTrackAsync_ShouldReturnStatusCode400_WhenTrackIsInvalid()
        {
            Track track = null;
            _projectBLMock.Setup(i => i.AddTrackAsync(track)).Throws(new NullReferenceException());
            TrackController trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.AddTrackAsync(track);
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }

        [Fact]
        public async Task DeleteTrackShouldDeleteTrack()
        {
            var track = new Track { Id = 1 };
            _projectBLMock.Setup(x => x.DeleteTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult<Track>(track));
            var trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.DeleteTrackAsync(track.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteTrackAsync((It.IsAny<Track>())));
        }
        [Fact]
        public async Task UpdateTrackShouldUpdateTrack()
        {
            var track = new Track { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult(track));
            var trackController = new TrackController(_projectBLMock.Object);
            var result = await trackController.UpdateTrackAsync(track.Id, track);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateTrackAsync(track));

        }

    }
}