using Microsoft.AspNetCore.Mvc;
using ProjectBL;
using ProjectModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectREST.Controllers
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
        public async Task<IActionResult> AddSavedProjectAsync()
        {
            try
            {
                SavedProject project2Send = new SavedProject();
                project2Send.ProjectName = Request.Form["name"];
                project2Send.SampleIds = Request.Form["sampleIds"];
                project2Send.Id = 0;
                project2Send.BPM = Request.Form["bPM"];
                project2Send.Pattern = Request.Form["pattern"];
                string userId = Request.Form["userId"];
                await _projectBL.AddSavedProjectAsync(project2Send, int.Parse(userId));
                Log.Logger.Information($"new SavedProject with ID {project2Send.Id} created");
                return CreatedAtAction("AddSavedProject", project2Send);
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
