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
        public async Task AddUserProjectAsync_ShouldReturnNewUserProject_WhenUserProjectIsValid()
        {
            //arrange
            var userProject = new UserProject 
            { 
                Id = 7,
                ProjectId = 1,
                UserId = 1
            };
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.AddUserProjectAsync(userProject);

            //assert
            Assert.Equal(userProject.ProjectId, result.ProjectId);
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
            Track track = new Track 
                {
                    Id = 3,
                    ProjectId = 1,
                    PatternId = 1, 
                    SampleId= 1
                };
      
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddTrackAsync(track);

            //assert
            Assert.Equal(track.ProjectId, result.ProjectId);
        }
   

        [Fact]
        public async Task GetSavedProjectsAsync_ShouldReturnSavedProject()
        {
            //arrange
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSavedProjectsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetTracksAsync_ShouldReturnTrack()
        {
            //arrange
            var projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetTracksAsync();

            //assert
            Assert.Equal(2, result.Count);
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
            //Track track = new Track();
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.GetTrackByIDAsync(id);

            //assert
            Assert.Equal(1, result.ProjectId);
        }


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
            
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);
            var track2BDeleted = projectDBContext.Track.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteTrackAsync(track2BDeleted);

            //assert
            Assert.Equal(1, result.ProjectId);
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
            var track = new Track {
                Id = 1,
                PatternId = 1,
                ProjectId = 2,
                SampleId = 1
            };
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateTrackAsync(track);

            //assert
            Assert.Equal(track.ProjectId, result.ProjectId);
        }

    


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
                context.Track.AddRange(
                    new Track 
                    { 
                        Id = 1,
                        PatternId=1,
                        ProjectId = 1,
                        SampleId = 1
                    
                    }, 
                    new Track
                    { 
                        Id = 2,
                        SampleId = 2,
                        ProjectId = 2,
                        PatternId = 2
                    }
                );
                context.Sample.AddRange(
                    new Sample
                    {
                        Id = 1
                        
                    },
                    
                    new Sample
                    { 
                        Id=2
                    }
               );
                context.Pattern.AddRange(
                    new Pattern
                    {
                        Id = 1
                    },
                    new Pattern 
                    { 
                        Id = 2
                    }
               );

                context.UserProject.AddRange(
                    new UserProject
                    {
                        Id = 1,
                        UserId = 1,
                        ProjectId= 1
                    },
                    new UserProject 
                    {
                        Id =2,
                        ProjectId = 2,
                        UserId = 2
                    }
              );
                context.SaveChanges();
            }
        }
    }

}
