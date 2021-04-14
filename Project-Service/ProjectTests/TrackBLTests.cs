using ProjectBL;
using ProjectDL;
using ProjectModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class TrackBLTests
    {
        private Mock<IProjectRepoDB> _projectBLMock;

        public TrackBLTests()
        {
            _projectBLMock = new Mock<IProjectRepoDB>();
        }
           [Fact]
        public async Task GetTracksAsyncShouldGetTracks()
        {
            //var track = new Track();
            var tracks = new List<Track> {new Track(){Id = 1}};
            _projectBLMock.Setup(x => x.GetTracksAsync());
            var newProjBL = new ProjBL(_projectBLMock.Object);
            //var newTrack = await newProjBL.AddTrackAsync(track);
            var result = await newProjBL.GetTracksAsync();
            Assert.Equal(1, tracks.Count);
            _projectBLMock.Verify(x => x.GetTracksAsync());

        }
        [Fact]
        public async Task GetTrackByIdAsyncShouldGetTrack()
        {
            var trackId = 1;
            var newTrack = new Track();
            _projectBLMock.Setup(x => x.GetTrackByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<Track>(newTrack));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.GetTrackByIDAsync(trackId);
            Assert.Equal(result, newTrack);
            _projectBLMock.Verify(x => x.GetTrackByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddTrackAsyncShouldAddTrack()
        {
            var newTrack = new Track();
            _projectBLMock.Setup(x => x.AddTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult<Track>(newTrack));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.AddTrackAsync(newTrack);
            Assert.Equal(result, newTrack);
            _projectBLMock.Verify(x => x.AddTrackAsync(It.IsAny<Track>()));

        }
        [Fact]
        public async Task DeleteTrackAsyncShouldDeleteTrack()
        {
            var newTrack = new Track();
            _projectBLMock.Setup(x => x.DeleteTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult<Track>(newTrack));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.DeleteTrackAsync(newTrack);
            Assert.Equal(result, newTrack);
            _projectBLMock.Verify(x => x.DeleteTrackAsync(It.IsAny<Track>()));

        }
        [Fact]
        public async Task UpdateTrackAsyncShouldUpdateTrack()
        {
            var newTrack = new Track();
            _projectBLMock.Setup(x => x.UpdateTrackAsync(It.IsAny<Track>())).Returns(Task.FromResult<Track>(newTrack));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.UpdateTrackAsync(newTrack);
            Assert.Equal(result, newTrack);
            _projectBLMock.Verify(x => x.UpdateTrackAsync(It.IsAny<Track>()));

        }
    }
}