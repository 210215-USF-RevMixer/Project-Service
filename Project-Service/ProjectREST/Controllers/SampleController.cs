﻿using Microsoft.AspNetCore.Mvc;
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

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSampleAsync([FromBody] Sample sample)
        {
            try
            {
                await _projectBL.AddSampleAsync(sample);
                Log.Logger.Information($"new Sample with ID {sample.Id} created");
                return CreatedAtAction("AddSample", sample);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSampleAsync(int id, [FromBody] Sample sample)
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