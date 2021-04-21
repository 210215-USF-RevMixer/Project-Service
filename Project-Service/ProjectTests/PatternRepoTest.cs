using Xunit;
using Microsoft.EntityFrameworkCore;
using ProjectDL;
using Model = ProjectModels;
using System.Linq;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ProjectTests
{
    public class PatternRepoTest
    {
        private readonly DbContextOptions<ProjectDBContext> options;
        public PatternRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<ProjectDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }
        [Fact]
        public async Task GetPatternsAsyncShouldReturnAllPatterns()
        {
            using (var context = new ProjectDBContext(options))
            {
                IProjectRepoDB _repo = new ProjectRepoDB(context);

                var patterns = await _repo.GetPatternsAsync();
                Assert.Equal(2, patterns.Count);
            }
        }
        [Fact]
        public async Task GetPatternByIDAsyncShouldReturnPattern()
        {
            using (var context = new ProjectDBContext(options))
            {
                IProjectRepoDB _repo = new ProjectRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 1;
                testPattern.PatternData = "123";
                var foundPattern = await _repo.GetPatternByIDAsync(1);
                Assert.Equal(1, testPattern.Id);
            }
        }
        [Fact]
        public async Task AddPatternAsyncShouldAddPattern()
        {
            using (var context = new ProjectDBContext(options))
            {
                IProjectRepoDB _repo = new ProjectRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.PatternData = "123";
                var newPattern = await _repo.AddPatternAsync(testPattern);
                Assert.Equal("123", newPattern.PatternData);
            }
        }
        [Fact]
        public async Task DeletePatternAsyncShouldDeletePattern()
        {
            using (var context = new ProjectDBContext(options))
            {
                IProjectRepoDB _repo = new ProjectRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 4;
                testPattern.PatternData = "123";
                var newPattern = await _repo.AddPatternAsync(testPattern);
                var deletedPattern = await _repo.DeletePatternAsync(testPattern);
                using (var assertContext = new ProjectDBContext(options))
                {
                    var result = await _repo.GetPatternByIDAsync(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async Task UpdatePatternAsyncShouldUpdatePattern()
        {
            using (var context = new ProjectDBContext(options))
            {
                IProjectRepoDB _repo = new ProjectRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 4;
                testPattern.PatternData = "123";
                ICollection<Track> patternTrack = new List<Track>();
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                patternTrack.Add(testTrack);
                var newPattern = await _repo.AddPatternAsync(testPattern);
                Assert.Equal("123", newPattern.PatternData);
                testPattern.PatternData = "456";
                var updatedPattern = await _repo.UpdatePatternAsync(testPattern);
                Assert.Equal("456", updatedPattern.PatternData);
            }
        }
        private void Seed()
        {
            using (var context = new ProjectDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Pattern.AddRange(
                    new Pattern
                    {
                        Id = 2,
                        PatternData = "10110111"
                    },
                    new Pattern
                    {
                        Id = 3,
                        PatternData = "00010001"
                    }


                    );
                
                context.SaveChanges();
            }
        }
    }
}