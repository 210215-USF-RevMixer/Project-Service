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
        public async Task GetSamplePlaylistByIdShouldGetSample()
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
        public async Task GetSamplePlaylistByIDAsync_ShouldReturnNotFound_whenIDIsInvalid()
        {
            //arrange
            int id = -1;
            _projectBLMock.Setup(i => i.GetSampleByIDAsync(id)).Throws(new Exception());
            SamplePlaylistController samplePlaylistController = new SamplePlaylistController(_projectBLMock.Object);

            //act
            var result = await samplePlaylistController.GetSamplePlaylistByIDAsync(id);

            //assert
            Assert.IsType<NotFoundResult>(result);
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
        public async Task AddSamplePlaylistAsync_ShouldReturnStatusCode400_WhenSamplePlaylistIsInvalid()
        {
            //arrange
            SamplePlaylist samplePlaylist = null;
            _projectBLMock.Setup(i => i.AddSamplePlaylistAsync(samplePlaylist)).Throws(new Exception());
            SamplePlaylistController samplePlaylistController = new SamplePlaylistController(_projectBLMock.Object);

            //act
            var result = await samplePlaylistController.AddSamplePlaylistAsync(samplePlaylist);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(400, ((StatusCodeResult)result).StatusCode);
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
        public async Task DeleteSamplePlaylistAsync_ShouldReturnStatusCode500_WhenSamplePlaylistIsInvalid()
        {
            //arrange
            int id = -1;
            SamplePlaylist samplePlaylist = null;
            _projectBLMock.Setup(i => i.DeleteSamplePlaylistAsync(samplePlaylist)).Throws(new Exception());
            SamplePlaylistController samplePlaylistController = new SamplePlaylistController(_projectBLMock.Object);

            //act
            var result = await samplePlaylistController.DeleteSamplePlaylistAsync(id);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
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

        [Fact]
        public async Task UpdateSamplePlaylistAsync_ShouldReturnStatusCode500_WhenSamplePlaylistIsInvalid()
        {
            //arrange
            int id = -1;
            SamplePlaylist samplePlaylist = null;
            _projectBLMock.Setup(i => i.UpdateSamplePlaylistAsync(samplePlaylist)).Throws(new Exception());
            SamplePlaylistController samplePlaylistController = new SamplePlaylistController(_projectBLMock.Object);

            //act
            var result = await samplePlaylistController.UpdateSamplePlaylistAsync(id, samplePlaylist);
            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
        }
     
    }
}
