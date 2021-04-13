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
    public class SampleSetsController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public SampleSetsController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetSampleSetsAsync()
        {
            return Ok(await _projectBL.GetSampleSetsAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSampleSetsByIDAsync(int id)
        {
            var user = await _projectBL.GetSampleSetsByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSampleSetsAsync([FromBody] SampleSets sampleSets)
        {
            try
            {
                await _projectBL.AddSampleSetsAsync(sampleSets);
                Log.Logger.Information($"new SampleSets with ID {sampleSets.Id} created");
                return CreatedAtAction("AddSampleSets", sampleSets);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSampleSetsAsync(int id, [FromBody] SampleSets sampleSets)
        {
            try
            {
                await _projectBL.UpdateSampleSetsAsync(sampleSets);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleSetsAsync(int id)
        {
            try
            {
                await _projectBL.DeleteSampleSetsAsync(await _projectBL.GetSampleSetsByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
