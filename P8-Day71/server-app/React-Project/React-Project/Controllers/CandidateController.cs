using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly DonationDbContext _dbContext;
        public CandidateController(DonationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            var candidates = await _dbContext.Candidates.ToListAsync();
            return Ok(candidates);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(int id)
        {
            var candidate = await _dbContext.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, [FromBody] Candidate candidate)
        {
            candidate.Id = id;
            _dbContext.Entry(candidate).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbCandidateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostCandidate([FromBody] Candidate candidate)
        {
            if (candidate == null)
            {
                return NotFound();
            }
            _dbContext.Add(candidate);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("GetCandidate", new { id = candidate.Id }, candidate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _dbContext.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            _dbContext.Remove(candidate);
            await _dbContext.SaveChangesAsync();
            return Ok(candidate);
        }

        private bool DbCandidateExists(int id)
        {
            return _dbContext.Candidates.Any(e => e.Id == id);
        }
    }
}
