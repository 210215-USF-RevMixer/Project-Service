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
    public class PatternController : ControllerBase
    {
        private readonly IProjectBL _projectBL;
        public PatternController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<PatternController>
        [HttpGet]
        public async Task<IActionResult> GetPatternsAsync()
        {
            return Ok(await _projectBL.GetPatternsAsync());
        }

        // GET api/<PatternController>/5
        [HttpGet("{patternID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPatternByIDAsync(int patternID)
        {
            var pattern = await _projectBL.GetPatternByIDAsync(patternID);
            if (pattern == null) return NotFound();
            return Ok(pattern);
        }

        // POST api/<PatternController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPatternAsync([FromBody] Pattern pattern)
        {
            try
            {
                await _projectBL.AddPatternAsync(pattern);
                Log.Logger.Information($"new Pattern with ID {pattern.Id} created");
                return CreatedAtAction("AddPattern", pattern);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }
        // PUT api/<PatternController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatternAsync(int id, [FromBody] Pattern pattern)
        {
            try
            {
                await _projectBL.UpdatePatternAsync(pattern);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<PatternController>/5
        [HttpDelete("{patternID}")]
        public async Task<IActionResult> DeletePatternAsync(int patternID)
        {
            try
            {
                await _projectBL.DeletePatternAsync(await _projectBL.GetPatternByIDAsync(patternID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
