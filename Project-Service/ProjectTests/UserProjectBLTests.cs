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
    public class UserProjectBLTests
    {
        private Mock<IProjectRepoDB> _projectBLMock;

        public UserProjectBLTests()
        {
            _projectBLMock = new Mock<IProjectRepoDB>();
        }
           [Fact]
        public async Task GetUserProjectsAsyncShouldGetUserProjects()
        {
            //var userProject = new UserProject();
            var userProjects = new List<UserProject> {new UserProject(){Id = 1}};
            _projectBLMock.Setup(x => x.GetUserProjectsAsync());
            var newProjBL = new ProjBL(_projectBLMock.Object);
            //var newUserProject = await newProjBL.AddUserProjectAsync(userProject);
            var result = await newProjBL.GetUserProjectsAsync();
            Assert.Equal(1, userProjects.Count);
            _projectBLMock.Verify(x => x.GetUserProjectsAsync());

        }
        [Fact]
        public async Task GetUserProjectByIdAsyncShouldGetUserProject()
        {
            var userProjectId = 1;
            var newUserProject = new UserProject();
            _projectBLMock.Setup(x => x.GetUserProjectByIDAsync(It.IsAny<int>())).Returns(Task.FromResult<UserProject>(newUserProject));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.GetUserProjectByIDAsync(userProjectId);
            Assert.Equal(result, newUserProject);
            _projectBLMock.Verify(x => x.GetUserProjectByIDAsync(It.IsAny<int>()));

        }
        [Fact]
        public async Task AddUserProjectAsyncShouldAddUserProject()
        {
            var newUserProject = new UserProject();
            _projectBLMock.Setup(x => x.AddUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult<UserProject>(newUserProject));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.AddUserProjectAsync(newUserProject);
            Assert.Equal(result, newUserProject);
            _projectBLMock.Verify(x => x.AddUserProjectAsync(It.IsAny<UserProject>()));

        }
        [Fact]
        public async Task DeleteUserProjectAsyncShouldDeleteUserProject()
        {
            var newUserProject = new UserProject();
            _projectBLMock.Setup(x => x.DeleteUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult<UserProject>(newUserProject));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.DeleteUserProjectAsync(newUserProject);
            Assert.Equal(result, newUserProject);
            _projectBLMock.Verify(x => x.DeleteUserProjectAsync(It.IsAny<UserProject>()));

        }
        [Fact]
        public async Task UpdateUserProjectAsyncShouldUpdateUserProject()
        {
            var newUserProject = new UserProject();
            _projectBLMock.Setup(x => x.UpdateUserProjectAsync(It.IsAny<UserProject>())).Returns(Task.FromResult<UserProject>(newUserProject));
            var newProjBL = new ProjBL(_projectBLMock.Object);
            var result = await newProjBL.UpdateUserProjectAsync(newUserProject);
            Assert.Equal(result, newUserProject);
            _projectBLMock.Verify(x => x.UpdateUserProjectAsync(It.IsAny<UserProject>()));

        }
    }
}