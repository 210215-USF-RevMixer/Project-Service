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
    public class SamplePlaylistController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public SamplePlaylistController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetSamplePlaylistsAsync()
        {
            return Ok(await _projectBL.GetSamplesAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSamplePlaylistByIDAsync(int id)
        {
            var user = await _projectBL.GetSampleByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // GET api/<ValuesController>/{userId}
        [HttpGet("{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSamplePlaylistByUserIDAsync(int userId)
        {
            var user = await _projectBL.GetSampleByUserIDAsync(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSamplePlaylistAsync([FromBody] Sample sample)
        {
            try
            {
                await _projectBL.AddSampleAsync(sample);
                Log.Logger.Information($"new Sample with ID {sample.Id} created");
                return CreatedAtAction("AddSample", sample);
            }
            catch(Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSamplePlaylistAsync(int id, [FromBody] Sample sample)
        {
            try
            {
                await _projectBL.UpdateSampleAsync(sample);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSamplePlaylistAsync(int id)
        {
            try
            {
                await _projectBL.DeleteSampleAsync(await _projectBL.GetSampleByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}