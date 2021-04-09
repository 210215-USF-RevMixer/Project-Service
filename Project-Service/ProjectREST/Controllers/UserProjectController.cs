using Microsoft.AspNetCore.Mvc;
using ProjectBL;
using ProjectModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProjectController : ControllerBase
    {
        private readonly IProjectBL _projectBL;
        public UserProjectController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<UserProjectController>
        [HttpGet]
        public async Task<IActionResult> GetUserProjectsAsync()
        {
            return Ok(await _projectBL.GetUserProjectsAsync());
        }

        // GET api/<UserProjectController>/5
        [HttpGet("{userProjectID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserProjectByIDAsync(int userProjectID)
        {
            var userProject = await _projectBL.GetUserProjectByIDAsync(userProjectID);
            if (userProject == null) return NotFound();
            return Ok(userProject);
        }

        // POST api/<UserProjectController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserProjectAsync([FromBody] UserProject userProject)
        {
            try
            {
                await _projectBL.AddUserProjectAsync(userProject);
                Log.Logger.Information($"new UserProject with ID {userProject.Id} created");
                return CreatedAtAction("AddUserProject", userProject);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }
        // PUT api/<UserProjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProjectAsync(int id, [FromBody] UserProject userProject)
        {
            try
            {
                await _projectBL.UpdateUserProjectAsync(userProject);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UserProjectController>/5
        [HttpDelete("{userProjectID}")]
        public async Task<IActionResult> DeleteUserProjectAsync(int userProjectID)
        {
            try
            {
                await _projectBL.DeleteUserProjectAsync(await _projectBL.GetUserProjectByIDAsync(userProjectID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
