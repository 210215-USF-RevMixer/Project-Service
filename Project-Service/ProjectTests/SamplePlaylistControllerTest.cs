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
    public class SamplePlaylistControllerTest
    {
        private Mock<IProjectBL> _projectBLMock;

        public SamplePlaylistControllerTest()
        {
            _projectBLMock = new Mock<IProjectBL>();
        }
         [Fact]
        public async Task GetSamplesPlaylistAsyncShouldReturnSamplePlaylists()
        {
            //arrange
            SamplePlaylist sample = new SamplePlaylist();
            _projectBLMock.Setup(i => i.GetSamplePlaylistsAsync());
            SamplePlaylistController sampleController = new SamplePlaylistController(_projectBLMock.Object);

            //act 
            var result = await sampleController.GetSamplePlaylistsAsync();

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task GetSampleByIdShouldGetSample()
        {
            var sampleId = 1;
            var sample = new SamplePlaylist { Id = sampleId };
            _projectBLMock.Setup(x => x.GetSamplePlaylistByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(sample));
            var sampleController = new SamplePlaylistController(_projectBLMock.Object);
            var result = await sampleController.GetSamplePlaylistByIDAsync(sampleId);
            Assert.Equal(sampleId, ((SamplePlaylist)((OkObjectResult)result).Value).Id);
            _projectBLMock.Verify(x => x.GetSamplePlaylistByIDAsync(sampleId));
        }
         [Fact]
        public async Task AddSamplePlaylistShouldAddSamplePlaylist()
        {
            var sample = new SamplePlaylist();
            _projectBLMock.Setup(x => x.AddSamplePlaylistAsync(It.IsAny<SamplePlaylist>())).Returns(Task.FromResult<SamplePlaylist>(sample));
            var sampleController = new SamplePlaylistController(_projectBLMock.Object);
            var result = await sampleController.AddSamplePlaylistAsync(new SamplePlaylist());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _projectBLMock.Verify(x => x.AddSamplePlaylistAsync((It.IsAny<SamplePlaylist>())));
        }
          [Fact]
        public async Task DeleteSamplePlaslistShouldDeleteSamplePlaylist()
        {
            var sampleId = 1;
            var sample = new SamplePlaylist{Id = sampleId};
            _projectBLMock.Setup(x => x.DeleteSamplePlaylistAsync(It.IsAny<SamplePlaylist>())).Returns(Task.FromResult<SamplePlaylist>(sample));
            var sampleController = new SamplePlaylistController(_projectBLMock.Object);
            var result = await sampleController.DeleteSamplePlaylistAsync(sample.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.DeleteSamplePlaylistAsync((It.IsAny<SamplePlaylist>())));
        }
        [Fact]
        public async Task UpdateSamplePlaylistShouldUpdateSamplePlaylist()
        {
            var sample = new SamplePlaylist { Id = 1 };
            _projectBLMock.Setup(x => x.UpdateSamplePlaylistAsync(It.IsAny<SamplePlaylist>())).Returns(Task.FromResult(sample));
            var sampleController = new SamplePlaylistController(_projectBLMock.Object);
            var result = await sampleController.UpdateSamplePlaylistAsync(sample.Id, sample);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _projectBLMock.Verify(x => x.UpdateSamplePlaylistAsync(sample));

        }
     
    }
}
