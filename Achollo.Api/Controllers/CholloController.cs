using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Achollo.Api.Data;
using Achollo.Api.Models;

namespace Achollo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CholloController : ControllerBase
    {
        private readonly AcholloContext _context;

        public CholloController(AcholloContext context)
        {
            _context = context;
        }

        // GET: api/chollo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chollo>>> GetChollos()
        {
            return await _context.Chollos.Include(c => c.Categoria).ToListAsync();
        }

        // GET: api/chollo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chollo>> GetChollo(int id)
        {
            var chollo = await _context.Chollos.FindAsync(id);
            //var chollo = await _context.Chollos.Include(c => c.Categoria).FindAsync(id);

            if (chollo == null)
            {
                return NotFound();
            }

            return chollo;
        }

        // POST: api/chollo
        [HttpPost]
        public async Task<ActionResult<Chollo>> PostChollo(Chollo chollo)
        {
            _context.Chollos.Add(chollo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetChollo), new { id = chollo.Id }, chollo);
        }

        // PUT: api/chollo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChollo(int id, Chollo chollo)
        {
            if (id != chollo.Id)
            {
                return BadRequest();
            }

            _context.Entry(chollo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CholloExists(id))
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

        // DELETE: api/chollo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChollo(int id)
        {
            var chollo = await _context.Chollos.FindAsync(id);
            if (chollo == null)
            {
                return NotFound();
            }

            _context.Chollos.Remove(chollo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CholloExists(int id)
        {
            return _context.Chollos.Any(e => e.Id == id);
        }
    }
}
