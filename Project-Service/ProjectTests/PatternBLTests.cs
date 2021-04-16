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
    public class PatternBLTests
    {
        private Mock<IProjectRepoDB> _projectBLMock;

        public PatternBLTests()
        {
            _projectBLMock = new Mock<IProjectRepoDB>();
        }
           [Fact]
        public async Task GetPatternsAsyncShouldGetPatterns()
        {
            //var pattern = new Pattern();
            var patterns = new List<Pattern> {new Pattern(){Id = 1}};
            _projectBLMock.Setup(x => x.GetPatternsAsync());
            var newProjBL = new ProjBL(_projectBLMock.Object);
            //var newPattern = await newProjBL.AddPatternAsync(pattern);
            var result = await newProjBL.GetPatternsAsync();
            Assert.Equal(1, patterns.Count);
            _projectBLMock.Verify(x => x.GetPatternsAsync());

        }
        [Fact]
        public async Task GetPatternByIdAsyncShouldGetPattern()
        {
            var patternId = 1;
            var newPattern = new Pattern();
            _projectBLMock.Setup(x => x.GetPatternByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<Pattern>(newPattern));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.GetPatternByIDAsync(patternId);
            Assert.Equal(result, newPattern);
            _projectBLMock.Verify(x => x.GetPatternByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddPatternAsyncShouldAddPattern()
        {
            var newPattern = new Pattern();
            _projectBLMock.Setup(x => x.AddPatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult<Pattern>(newPattern));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.AddPatternAsync(newPattern);
            Assert.Equal(result, newPattern);
            _projectBLMock.Verify(x => x.AddPatternAsync(It.IsAny<Pattern>()));

        }
        [Fact]
        public async Task DeletePatternAsyncShouldDeletePattern()
        {
            var newPattern = new Pattern();
            _projectBLMock.Setup(x => x.DeletePatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult<Pattern>(newPattern));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.DeletePatternAsync(newPattern);
            Assert.Equal(result, newPattern);
            _projectBLMock.Verify(x => x.DeletePatternAsync(It.IsAny<Pattern>()));

        }
        [Fact]
        public async Task UpdatePatternAsyncShouldUpdatePattern()
        {
            var newPattern = new Pattern();
            _projectBLMock.Setup(x => x.UpdatePatternAsync(It.IsAny<Pattern>())).Returns(Task.FromResult<Pattern>(newPattern));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.UpdatePatternAsync(newPattern);
            Assert.Equal(result, newPattern);
            _projectBLMock.Verify(x => x.UpdatePatternAsync(It.IsAny<Pattern>()));

        }
    }
}