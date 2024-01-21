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
    public class GeneralDatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GeneralDatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneralDatos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralDatos>>> GetGeneralDatos()
        {
            return await _context.GeneralDatos.ToListAsync();
        }

        // GET: api/GeneralDatos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralDatos>> GetGeneralDatos(int id)
        {
            var generalDatos = await _context.GeneralDatos.FindAsync(id);

            if (generalDatos == null)
            {
                return NotFound();
            }

            return generalDatos;
        }

        // PUT: api/GeneralDatos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralDatos(int id, GeneralDatos generalDatos)
        {
            if (id != generalDatos.Id)
            {
                return BadRequest();
            }

            _context.Entry(generalDatos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneralDatosExists(id))
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

        // POST: api/GeneralDatos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralDatos>> PostGeneralDatos(GeneralDatos generalDatos)
        {
            _context.GeneralDatos.Add(generalDatos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneralDatos", new { id = generalDatos.Id }, generalDatos);
        }

        // DELETE: api/GeneralDatos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralDatos(int id)
        {
            var generalDatos = await _context.GeneralDatos.FindAsync(id);
            if (generalDatos == null)
            {
                return NotFound();
            }

            _context.GeneralDatos.Remove(generalDatos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneralDatosExists(int id)
        {
            return _context.GeneralDatos.Any(e => e.Id == id);
        }
    }
}
