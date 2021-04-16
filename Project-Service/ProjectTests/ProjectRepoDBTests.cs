using Microsoft.EntityFrameworkCore;
using ProjectDL;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectTests
{
    public class ProjectRepoDBTests
    {
        private readonly DbContextOptions<ProjectDBContext> options;

        public ProjectRepoDBTests()
        {
            options = new DbContextOptionsBuilder<ProjectDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }

        [Fact]
        public async Task AddSavedProjectAsync_ShouldReturnNewSavedProject_WhenSavedProjectIsValid()
        {
            //arrange
            var savedProject = new SavedProject();
            savedProject.ProjectName = "TestProject";
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddSavedProjectAsync(savedProject);

            //assert
            Assert.Equal(savedProject.ProjectName, result.ProjectName);
        }

        [Fact]
        public async Task AddTrackAsync_ShouldReturnTrack_WhenTrackIsValid()
        {
            //arrange
            Track track = new Track();
            track.Id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddTrackAsync(track);

            //assert
            Assert.Equal(track.Id, result.Id);
        }
        /* public async Task<Track> AddTrackAsync(Track newTrack)
    {
        await _context.Track.AddAsync(newTrack);
        await _context.SaveChangesAsync();
        return newTrack;
    }*/

        [Fact]
        public async Task GetSavedProjectsAsync_ShouldReturnSavedProject()
        {
            //arrange
            List<SavedProject> savedProjects = new List<SavedProject>();

            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSavedProjectsAsync();

            //assert
            Assert.Equal(savedProjects, result);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnTrack()
        {
            //arrange
            List<Track> tracks = new List<Track>();
            var projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetTracksAsync();

            //assert
            Assert.Equal(tracks, result);
        }

    

        [Fact]
        public async Task GetSavedProjectByIDAsync_ShouldReturnSavedProject_WhenIDIsValid()
        {
            //arrange 
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.GetSavedProjectByIDAsync(id);

            //assert
            Assert.Equal("test1", result.ProjectName);
        }

        [Fact]
        public async Task GetTrackByIDAsync_ShouldReturnTrack()
        {
            //arrange
            Track track = new Track();
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.GetTrackByIDAsync(id);

            //assert
            Assert.Equal(track, result);
        }

        /* public async Task<Track> GetTrackByIDAsync(int trackID)
        {
            return await _context.Track
                .Include(track => track.Pattern)
                .AsNoTracking()
                .Include(track => track.Sample)
                .AsNoTracking()
                .Include(track => track.SavedProject)
                .AsNoTracking()
                .FirstOrDefaultAsync(track => track.Id == trackID);
        }*/

        [Fact]
        public async Task GetSavedProjectByIDAsync_ShouldReturnNull_WhenIDIsInvalid()
        {
            //arrange 
            int id = 33;
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.GetSavedProjectByIDAsync(id);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnDeletedProject_WhenSavedProjectIsValid()
        {
            //arrange 
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);
            var savedProject2BDeleted = projectDBContext.SavedProject.Where(i => i.Id == id).FirstOrDefault();
            //act
            var result = await projectrepoDB.DeleteSavedProjectAsync(savedProject2BDeleted);

            //assert
            Assert.Equal("test1", result.ProjectName);
        }

        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnNull_WhenSavedProjectIsInvalid()
        {
            try
            {
                //arrange 
                int id = 33;
                var projectDBContext = new ProjectDBContext(options);
                var projectrepoDB = new ProjectRepoDB(projectDBContext);
                var savedProject2BDeleted = projectDBContext.SavedProject.Where(i => i.Id == id).FirstOrDefault();
                //act
                var result = await projectrepoDB.DeleteSavedProjectAsync(savedProject2BDeleted);

            }
            catch (Exception ex)
            {

                //assert
                Assert.IsType<ArgumentNullException>(ex);
            }


        }

        [Fact]
        public async Task DeleteTrackAsync_ShouldReturnDeletedTrack_WhenTrackisValid()
        {
            //arrange
            int id = 1;
            Track track = new Track();
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);
            var track2BDeleted = projectDBContext.Track.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteTrackAsync(track2BDeleted);

            //assert
            //Assert.Equal()
        }
        /*
    public async Task<Track> DeleteTrackAsync(Track track2BDeleted)
    {
        _context.Track.Remove(track2BDeleted);
        await _context.SaveChangesAsync();
        return track2BDeleted;
    }*/

        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnSavedProject_WhenSavedProjectIsValid()
        {
            //arrange
            var savedproject2BUpdated = new SavedProject
            {
                Id = 1,
                BPM = 0,
                ProjectName = "test1Update"
            };
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.UpdateSavedProjectAsync(savedproject2BUpdated);

            //assert
            Assert.Equal(savedproject2BUpdated.ProjectName, result.ProjectName);
        }

        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnArgumentNullException_WhenSavedProjectIsInvalid()
        {
            //arrange
            try
            {
                var savedproject2BUpdated = new SavedProject
                {
                    Id = 33,
                    BPM = 0,
                    ProjectName = "test1Update"
                };
                var projectDBContext = new ProjectDBContext(options);
                var projectrepoDB = new ProjectRepoDB(projectDBContext);

                //act
                var result = await projectrepoDB.UpdateSavedProjectAsync(savedproject2BUpdated);

            }
            catch (Exception ex)
            {

                //assert
                Assert.IsType<ArgumentNullException>(ex);
            }
        }

        [Fact]
        public async Task UpdateTrackAsync_ShouldReturnTrack_WhenTrackIsValid()
        {
            //arrange
            var track = new Track { Id = 1};
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateTrackAsync(track);

            //assert
            Assert.Equal(track.Id, result.Id);
        }

        /*public async Task<Track> UpdateTrackAsync(Track track2BUpdated)
        {
            Track oldTrack = await _context.Track.Where(t => t.Id == track2BUpdated.Id).FirstOrDefaultAsync();

            _context.Entry(oldTrack).CurrentValues.SetValues(track2BUpdated);

            await _context.SaveChangesAsync();

            _context.ChangeTracker.Clear();
            return track2BUpdated;
        }
*/


        private void Seed()
        {
            using (var context = new ProjectDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.SavedProject.AddRange(
                    new SavedProject
                    {
                        Id = 1,
                        BPM = 0,
                        ProjectName = "test1"
                    },
                    new SavedProject
                    {
                        Id = 2,
                        BPM = 0,
                        ProjectName = "test2"
                    }
                  
                    );


                context.SaveChanges();
            }
        }
    }

}
