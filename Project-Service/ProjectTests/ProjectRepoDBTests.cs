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
        public async Task AddSampleAsync_ShouldReturnNewSample()
        {
            //arrange
            Sample sample = new Sample
            {
                Id = 8,
                SampleLink = "SampleLink",
                SampleName = "SampleName"
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddSampleAsync(sample);

            //assert
            Assert.Equal(sample.SampleName, result.SampleName);
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
                SampleId = 1
            };

            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddTrackAsync(track);

            //assert
            Assert.Equal(track.ProjectId, result.ProjectId);
        }

        [Fact]
        public async Task AddUsersSampleAsync_ShouldReturnNewUsersSample()
        {
            //arrange
            UsersSample usersSample = new UsersSample
            {
                Id = 9,
                SampleId = 1,
                UserId = 1
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddUsersSampleAsync(usersSample);

            //assert
            Assert.Equal(usersSample.Id, result.Id);
        }
            
        [Fact]
        public async Task AddUsersSampleSetsAsync_ShouldReturnNewUsersSampleSets()
        {
            //arrange
            UsersSampleSets usersSampleSets = new UsersSampleSets
            {
                Id = 102,
                SampleSetsId = 1,
                UserId = 1
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddUsersSampleSetsAsync(usersSampleSets);

            //assert
            Assert.Equal(usersSampleSets.Id, result.Id);
        }

        [Fact]
        public async Task AddSamplePlaylistAsync_ShouldReturnNewSamplePlaylist()
        {
            //arrange
            SamplePlaylist samplePlaylist = new SamplePlaylist
            {
                Id = 89,
                SampleId = 1,
                SampleSetId = 1
            };
            ProjectDBContext context = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(context);

            //act
            var result = await projectRepoDB.AddSamplePlaylistAsync(samplePlaylist);

            //assert
            Assert.Equal(samplePlaylist.SampleSetId, result.SampleSetId);
        }

        [Fact]
        public async Task AddSampleSetsAsync_ShouldReturnNewSampleSets()
        {
            //arrange
            SampleSets sampleSets = new SampleSets
            {
                Id = 9,
                Name = "SampleSet"
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddSampleSetsAsync(sampleSets);

            //assert
            Assert.Equal(sampleSets.Name, result.Name);
        }

        [Fact]
        public async Task AddPatternAsync_ShouldReturnNewPattern()
        {
            //arrange
            Pattern pattern = new Pattern
            {
                Id = 99,
                PatternData = "PatternData",
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.AddPatternAsync(pattern);

            //assert
            Assert.Equal(pattern.PatternData, result.PatternData);
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
        public async Task GetUserProjectsAsync_ShouldReturnUserProjects()
        {
            //arrange
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUserProjectsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUserProjectByIDAsync_ShouldReturnUserProject_WhenIdIsValid()
        {
            //arrange
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUserProjectByIDAsync(id);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetUserProjectByIDAsync_ShouldReturnNull_WhenIdIsInvalid()
        {
            //arrange
            int id = 22;
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act 
            var result = await projectRepoDB.GetUserProjectByIDAsync(id);

            //assert
            Assert.Null(result);

        }

        [Fact]
        public async Task GetPatternByIDAsync_ShouldReturnPattern()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetPatternByIDAsync(id);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetPatternsAsync_ShouldReturnPattern()
        {
            //arrange
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetPatternsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSampleByIDAsync_ShouldReturnSample()
        {
            //arrange
            int id = 2;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSampleByIDAsync(id);

            //assert
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task GetSamplesAsync_ShouldReturnSample()
        {
            //arrange
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSamplesAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSamplePlaylistByIDAsync_ShouldReturnSamplePlaylist()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSamplePlaylistByIDAsync(id);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetSamplePlaylistsAsync_ShouldReturnSamplePlaylist()
        {
            //arrange
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSamplePlaylistsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetSampleSetsByIDAsync_ShouldReturnSampleSet()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act 
            var result = await projectRepoDB.GetSampleSetsByIDAsync(id);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetSampleSetsAsync_ShouldReturnSampleSet()
        {
            //arrange
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetSampleSetsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUsersSamplesAsync_ShouldReturnUsersSample()
        {
            //arrange
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUsersSamplesAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUsersSampleByIDAsync_ShouldReturnUsersSample()
        {
            //arrage
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUsersSampleByIDAsync(id);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetUsersSampleByUserIDAsync_ShouldReturnUsersSample()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUsersSampleByUserIDAsync(id);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetUsersSampleSetsAsync_ShouldReturnUsersSampleSets()
        {
            //arrange 
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.GetUsersSampleSetsAsync();

            //assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUsersSampleSetsByIDAsync_ShouldReturnUserSampleSets()
        {
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            var result = await projectRepoDB.GetUsersSampleSetsByIDAsync(id);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetUsersSampleSetsByUserIDAsync_ShouldReturnUserSampleSets()
        {
            int id = 2;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            var result = await projectRepoDB.GetUsersSampleSetsByUserIDAsync(id);

            Assert.Single(result);
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
        public async Task DeleteUsersSampleAsync_ShouldReturnUsersSample2BDeleted()
        {
            //arrange
            int id = 2;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var usersSample2BDeleted = projectDBContext.UsersSample.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteUsersSampleAsync(usersSample2BDeleted);

            //assert
            Assert.Equal(2, result.SampleId);

        }

        [Fact]
        public async Task DeleteUsersSampleSetsAsync_ShouldReturnUsersSampleSets2BDeleted()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var usersSampleSets2BDeleted = projectDBContext.UsersSampleSets.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteUsersSampleSetsAsync(usersSampleSets2BDeleted);

            //assert
            Assert.Equal(1, result.UserId);
        }


        [Fact]
        public async Task DeleteSavedProjectAsync_ShouldReturnArgumentNullException_WhenSavedProjectIsInvalid()
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

        [Fact]
        public async Task DeleteUserProjectAsync_ShouldReturnUserProject2BDeleted_WhenUserProjectIsValid()
        {
            //arrange 
            int id = 1;
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);
            var userProject2BDeleted = projectDBContext.UserProject.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteUserProjectAsync(userProject2BDeleted);

            //assert
            Assert.Equal(1, result.ProjectId);
        }

        [Fact]
        public async Task DeleteUserProjectAsync_ShouldReturnArgumentNullException_WhenUserProjectIsInvalid()
        {
            try
            {
                //arrange 
                int id = 44;
                var projectDBContext = new ProjectDBContext(options);
                var projectRepoDB = new ProjectRepoDB(projectDBContext);
                var userProject2BDeleted = projectDBContext.UserProject.Where(i => i.Id == id).FirstOrDefault();

                //act
                var result = await projectRepoDB.DeleteUserProjectAsync(userProject2BDeleted);
            }
            catch (Exception ex)
            {

                //assert
                Assert.IsType<ArgumentNullException>(ex);

            }
        }

        [Fact]
        public async Task DeletePatternAsync_ShouldReturnPattern2BDeleted()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var pattern2BDeleted = projectDBContext.Pattern.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeletePatternAsync(pattern2BDeleted);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteSampleAsync_ShouldReturnSample2BDeleted()
        {
            //arrange
            int id = 2;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var sample2BDeleted = projectDBContext.Sample.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteSampleAsync(sample2BDeleted);

            //assert
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task DeleteSamplePlaylistAsync_ShouldReturnSamplePlaylist2BDeleted()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var samplePlaylist2BDeleted = projectDBContext.SamplePlaylist.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteSamplePlaylistAsync(samplePlaylist2BDeleted);

            //assert
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task DeleteSampleSetsAsync_ShouldReturnSampleSets2BDeleted()
        {
            //arrange
            int id = 1;
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);
            var sampleSet2BDeleted = projectDBContext.SampleSet.Where(i => i.Id == id).FirstOrDefault();

            //act
            var result = await projectRepoDB.DeleteSampleSetsAsync(sampleSet2BDeleted);

            //assert
            Assert.Equal(1, result.Id);
        }


        [Fact]
        public async Task UpdateSavedProjectAsync_ShouldReturnSavedProject_WhenSavedProjectIsValid()
        {
            //arrange
            var savedproject2BUpdated = new SavedProject
            {
                Id = 1,
                BPM = "0",
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
        public async Task UpdateUsersSampleAsync_ShouldReturn_OldUsersSample()
        {
            //arrange
            UsersSample usersSample = new UsersSample
            {
                Id = 1,
                SampleId = 98
            };
            var projectDBContext = new ProjectDBContext(options);
            var projectrepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectrepoDB.UpdateUsersSampleAsync(usersSample);

            //assert
            Assert.Equal(usersSample.SampleId, result.SampleId);
        }

        [Fact]
        public async Task UpdateUsersSampleSetsAsync_ShouldReturn_OldUsersSampleSets()
        {
            //arrange
            UsersSampleSets usersSampleSets = new UsersSampleSets
            {
                Id = 1,
                UserId = 99
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateUsersSampleSetsAsync(usersSampleSets);

            //assert
            Assert.Equal(usersSampleSets.UserId, result.UserId);
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
                    BPM = "0",
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
            var track = new Track
            {
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

        [Fact]
        public async Task UpdateUserProjectAsync_ShouldReturnUserProject2BUpdated_WhenUserProjectIsValid()
        {
            //arrange
            var userProject2BUpdated = new UserProject
            {
                Id = 1,
                ProjectId = 8,
                UserId = 1
            };
            var projectDBContext = new ProjectDBContext(options);
            var projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateUserProjectAsync(userProject2BUpdated);

            //assert
            Assert.Equal(userProject2BUpdated.ProjectId, result.ProjectId);

        }

        [Fact]
        public async Task UpdatePatternAsync_ShouldReturnOldPattern()
        {
            //arrange
            Pattern pattern = new Pattern
            {
                Id = 1,
                PatternData = "NewPattern"
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdatePatternAsync(pattern);

            //assert
            Assert.Equal(pattern.PatternData, result.PatternData);
        }

        [Fact]
        public async Task UpdateSampleAsync_ShouldReturnOldSample()
        {
            //arrange
            Sample sample = new Sample 
            {
                Id = 1,
                SampleName = "new sample name"
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateSampleAsync(sample);

            //assert
            Assert.Equal(sample.SampleName, result.SampleName);
        }

        [Fact]
        public async Task UpdateSamplePlaylistAsync_ShouldReturnOldSamplePlaylist()
        {//arrange
            SamplePlaylist samplePlaylist = new SamplePlaylist
            {
                Id = 1,
                SampleId = 9
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateSamplePlaylistAsync(samplePlaylist);

            //assert
            Assert.Equal(samplePlaylist.SampleId, result.SampleId);
        }

        [Fact]
        public async Task UpdateSampleSetsAsync_ShouldReturnOldSampleSets()
        {
            //arrange
            SampleSets sampleSets = new SampleSets
            {
                Id = 1,
                Name = "New sample sets name"
            };
            ProjectDBContext projectDBContext = new ProjectDBContext(options);
            ProjectRepoDB projectRepoDB = new ProjectRepoDB(projectDBContext);

            //act
            var result = await projectRepoDB.UpdateSampleSetsAsync(sampleSets);

            //assert
            Assert.Equal(sampleSets.Name, result.Name);
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
                        BPM = "0",
                        ProjectName = "test1"
                    },
                    new SavedProject
                    {
                        Id = 2,
                        BPM = "0",
                        ProjectName = "test2"
                    }

                );
                context.Track.AddRange(
                    new Track
                    {
                        Id = 1,
                        PatternId = 1,
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
                        Id = 1,
                        SampleLink = "SampleLink1",
                        SampleName = "SampleName1"
                    },

                    new Sample
                    {
                        Id = 2,
                        SampleLink = "SampleLink2",
                        SampleName = "SampleName2"
                    }
               );
                context.Pattern.AddRange(
                    new Pattern
                    {
                        Id = 1,
                        PatternData = "PatternData1",
                    },
                    new Pattern
                    {
                        Id = 2,
                        PatternData = "PatternData2"
                    }
               );

                context.UserProject.AddRange(
                    new UserProject
                    {
                        Id = 1,
                        UserId = 1,
                        ProjectId = 1
                    },
                    new UserProject
                    {
                        Id = 2,
                        ProjectId = 2,
                        UserId = 2
                    }

              );
                context.UsersSampleSets.AddRange(
                    new UsersSampleSets
                    {
                        Id = 1,
                        UserId = 1,
                        SampleSetsId = 1
                    },
                    new UsersSampleSets
                    {
                        Id = 2,
                        SampleSetsId = 2,
                        UserId = 2
                    }
              );
                context.SamplePlaylist.AddRange(
                    new SamplePlaylist 
                    {
                        Id = 1,
                        SampleId = 1,
                        SampleSetId = 1
                    },
                    new SamplePlaylist
                    { 
                        Id= 2,
                        SampleSetId = 2,
                        SampleId = 2
                    }
                );
                context.UsersSample.AddRange(
                    new UsersSample
                    { 
                       Id = 1,
                       SampleId = 1,
                       UserId = 1
                    },
                    new UsersSample
                    {
                        Id =2,
                        SampleId = 2,
                        UserId = 2
                    }
                );
                context.SampleSet.AddRange(
                    new SampleSets 
                    {
                        Id = 1,
                        Name = "SampleSet1"
                    },
                    new SampleSets
                    {
                        Id = 2,
                        Name = "SampleSet2"
                    }

                );
                context.SaveChanges();
            }
        }
    }

}
