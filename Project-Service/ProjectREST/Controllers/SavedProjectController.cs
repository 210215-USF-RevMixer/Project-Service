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
    public class SavedProjectController : ControllerBase
    {
        private readonly IProjectBL _projectBL;
        public SavedProjectController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<SavedProjectController>
        [HttpGet]
        public async Task<IActionResult> GetSavedProjectsAsync()
        {
            return Ok(await _projectBL.GetSavedProjectsAsync());
        }

        // GET api/<SavedProjectController>/5
        [HttpGet("{savedProjectID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSavedProjectByIDAsync(int savedProjectID)
        {
            var savedProject = await _projectBL.GetSavedProjectByIDAsync(savedProjectID);
            if (savedProject == null) return NotFound();
            return Ok(savedProject);
        }

        // POST api/<SavedProjectController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSavedProjectAsync([FromBody] SavedProject userProject)
        {
            try
            {
                await _projectBL.AddSavedProjectAsync(userProject);
                Log.Logger.Information($"new SavedProject with ID {userProject.Id} created");
                return CreatedAtAction("AddSavedProject", userProject);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }
        // PUT api/<SavedProjectController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedProjectAsync(int id, [FromBody] SavedProject userProject)
        {
            try
            {
                await _projectBL.UpdateSavedProjectAsync(userProject);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<SavedProjectController>/5
        [HttpDelete("{savedProjectID}")]
        public async Task<IActionResult> DeleteSavedProjectAsync(int savedProjectID)
        {
            try
            {
                await _projectBL.DeleteSavedProjectAsync(await _projectBL.GetSavedProjectByIDAsync(savedProjectID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
