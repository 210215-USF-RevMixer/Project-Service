using Microsoft.AspNetCore.Mvc;
using ProjectBL;
using ProjectModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersSampleSetsController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public UsersSampleSetsController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetUsersSampleSetsAsync()
        {
            return Ok(await _projectBL.GetUsersSampleSetsAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersSampleSetsByIDAsync(int id)
        {
            var user = await _projectBL.GetUsersSampleSetsByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        //GET api/<UploadMusicController>/uploadedmusic/userid
        [HttpGet]
        [Route("/api/UsersSampleSets/User/{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUsersSampleSetsByUserIDAsync(int userID)
        {
            var usersSampleSets = await _projectBL.GetUsersSampleSetsByUserIDAsync(userID);
            if (usersSampleSets == null) return NotFound();
            return Ok(usersSampleSets);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUsersSampleSetsAsync([FromBody] UsersSampleSets sampleSets)
        {
            try
            {
                await _projectBL.AddUsersSampleSetsAsync(sampleSets);
                Log.Logger.Information($"new UsersSampleSets with ID {sampleSets.Id} created");
                return CreatedAtAction("AddUsersSampleSets", sampleSets);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsersSampleSetsAsync(int id, [FromBody] UsersSampleSets sampleSets)
        {
            try
            {
                await _projectBL.UpdateUsersSampleSetsAsync(sampleSets);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersSampleSetsAsync(int id)
        {
            try
            {
                await _projectBL.DeleteUsersSampleSetsAsync(await _projectBL.GetUsersSampleSetsByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
