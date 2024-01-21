using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppUserss.Context;
using WebAppUserss.Models;

namespace WebAppUserss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDetails>>> GetProjectDetails()
        {
            return await _context.ProjectDetails.ToListAsync();
        }

        // GET: api/ProjectDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetails>> GetProjectDetails(int id)
        {
            var projectDetails = await _context.ProjectDetails.FindAsync(id);

            if (projectDetails == null)
            {
                return NotFound();
            }

            return projectDetails;
        }

        // PUT: api/ProjectDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectDetails(int id, ProjectDetails projectDetails)
        {
            if (id != projectDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectDetailsExists(id))
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

        // POST: api/ProjectDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectDetails>> PostProjectDetails(ProjectDetails projectDetails)
        {
            _context.ProjectDetails.Add(projectDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectDetails", new { id = projectDetails.Id }, projectDetails);
        }

        // DELETE: api/ProjectDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectDetails(int id)
        {
            var projectDetails = await _context.ProjectDetails.FindAsync(id);
            if (projectDetails == null)
            {
                return NotFound();
            }

            _context.ProjectDetails.Remove(projectDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectDetailsExists(int id)
        {
            return _context.ProjectDetails.Any(e => e.Id == id);
        }
    }
}
