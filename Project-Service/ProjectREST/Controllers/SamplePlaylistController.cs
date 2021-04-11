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
            return Ok(await _projectBL.GetSamplePlaylistsAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSamplePlaylistByIDAsync(int id)
        {
            var user = await _projectBL.GetSamplePlaylistByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSamplePlaylistAsync([FromBody] SamplePlaylist samplePlaylist)
        {
            try
            {
                await _projectBL.AddSamplePlaylistAsync(samplePlaylist);
                Log.Logger.Information($"new SamplePlaylist with ID {samplePlaylist.Id} created");
                return CreatedAtAction("AddSample", samplePlaylist);
            }
            catch(Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSamplePlaylistAsync(int id, [FromBody] SamplePlaylist samplePlaylist)
        {
            try
            {
                await _projectBL.UpdateSamplePlaylistAsync(samplePlaylist);
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
                await _projectBL.DeleteSamplePlaylistAsync(await _projectBL.GetSamplePlaylistByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}