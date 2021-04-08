using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectModels;
using ProjectBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IProjectBL _projectBL;

        public SampleController(IProjectBL projectBL)
        {
            _projectBL = projectBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetSamplesAsync()
        {
            return Ok(await _projectBL.GetSamplesAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSampleByIDAsync(int id)
        {
            var user = await _projectBL.GetSampleByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // GET api/<ValuesController>/{userId}
        public async Task<IActionResult> GetSampleByUserIDAsync(int userId)
        {
            var user = await _projectBL.GetSampleByUserIDAsync(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> AddSampleAsync([FromBody] Sample sample)
        {
            try
            {
                await _projectBL.AddSampleAsync(sample);
                return CreatedAtAction("AddSample", sample);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSampleAsynchAsync(int id, [FromBody] Sample sample)
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
        public async Task<IActionResult> DeleteSampleAsync(int id)
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
