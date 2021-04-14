using Microsoft.EntityFrameworkCore;
using ProjectDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void Seed()
        {
            throw new NotImplementedException();
        }
    }

}
