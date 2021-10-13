using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Play.Data;
using Play.Models;

namespace Play.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nintendos : ControllerBase
    {
        private readonly AppDbContext _context;

        public Nintendos(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Nintendos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nintendo>>> GetNintendo()
        {
            return await _context.Nintendo.ToListAsync();
        }

        // GET: api/Nintendos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nintendo>> GetNintendo(string id)
        {
            var nintendo = await _context.Nintendo.FindAsync(id);

            if (nintendo == null)
            {
                return NotFound();
            }

            return nintendo;
        }

        // PUT: api/Nintendos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNintendo(string id, Nintendo nintendo)
        {
            if (id != nintendo.nombre)
            {
                return BadRequest();
            }

            _context.Entry(nintendo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NintendoExists(id))
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

        // POST: api/Nintendos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nintendo>> PostNintendo(Nintendo nintendo)
        {
            _context.Nintendo.Add(nintendo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NintendoExists(nintendo.nombre))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNintendo", new { id = nintendo.nombre }, nintendo);
        }

        // DELETE: api/Nintendos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNintendo(string id)
        {
            var nintendo = await _context.Nintendo.FindAsync(id);
            if (nintendo == null)
            {
                return NotFound();
            }

            _context.Nintendo.Remove(nintendo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NintendoExists(string id)
        {
            return _context.Nintendo.Any(e => e.nombre == id);
        }
    }
}
