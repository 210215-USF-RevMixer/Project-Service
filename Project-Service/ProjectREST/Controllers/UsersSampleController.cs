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
    public class UsersSampleController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public UsersSampleController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetUsersSamplesAsync()
        {
            return Ok(await _projectBL.GetUsersSamplesAsync());
        }
        //GET api/<UploadMusicController>/uploadedmusic/userid
        [HttpGet]
        [Route("/api/UsersSample/User/{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUsersSampleByUserIDAsync(int userID)
        {
            var usersSample = await _projectBL.GetUsersSampleByUserIDAsync(userID);
            if (usersSample == null) return NotFound();
            return Ok(usersSample);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersSampleByIDAsync(int id)
        {
            var user = await _projectBL.GetUsersSampleByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUsersSampleAsync([FromBody] UsersSample sample)
        {
            try
            {
                await _projectBL.AddUsersSampleAsync(sample);
                Log.Logger.Information($"new UsersSample with ID {sample.Id} created");
                return CreatedAtAction("AddUsersSample", sample);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsersSampleAsync(int id, [FromBody] UsersSample sample)
        {
            try
            {
                await _projectBL.UpdateUsersSampleAsync(sample);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersSampleAsync(int id)
        {
            try
            {
                await _projectBL.DeleteUsersSampleAsync(await _projectBL.GetUsersSampleByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
