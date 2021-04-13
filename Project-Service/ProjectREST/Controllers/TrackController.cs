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
    public class TrackController : ControllerBase
    {
        private readonly IProjectBL _projectBL;
        public TrackController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<TrackController>
        [HttpGet]
        public async Task<IActionResult> GetTracksAsync()
        {
            return Ok(await _projectBL.GetTracksAsync());
        }

        // GET api/<TrackController>/5
        [HttpGet("{trackID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTrackByIDAsync(int trackID)
        {
            var track = await _projectBL.GetTrackByIDAsync(trackID);
            if (track == null) return NotFound();
            return Ok(track);
        }

        // POST api/<TrackController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddTrackAsync([FromBody] Track track)
        {
            try
            {
                await _projectBL.AddTrackAsync(track);
                Log.Logger.Information($"new Track with ID {track.Id} created");
                return CreatedAtAction("AddTrack", track);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }
        // PUT api/<TrackController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrackAsync(int id, [FromBody] Track track)
        {
            try
            {
                await _projectBL.UpdateTrackAsync(track);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<TrackController>/5
        [HttpDelete("{trackID}")]
        public async Task<IActionResult> DeleteTrackAsync(int trackID)
        {
            try
            {
                await _projectBL.DeleteTrackAsync(await _projectBL.GetTrackByIDAsync(trackID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
