using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models;
using WepAppGM.Models;

namespace WebappGM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_identidadMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_identidadMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_identidadM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_identidadM>>> Getgm_identidadMs()
        {
            return await _context.gm_identidadMs.ToListAsync();
        }

        // GET: api/gm_identidadM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_identidadM>> Getgm_identidadM(int id)
        {
            var gm_identidadM = await _context.gm_identidadMs.FindAsync(id);

            if (gm_identidadM == null)
            {
                return NotFound();
            }

            return gm_identidadM;
        }

        // PUT: api/gm_identidadM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_identidadM(int id, gm_identidadM gm_identidadM)
        {
            if (id != gm_identidadM.idIdentidadM)
            {
                return BadRequest();
            }

            _context.Entry(gm_identidadM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_identidadMExists(id))
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

        // POST: api/gm_identidadM
        [HttpPost]
        public async Task<ActionResult<gm_identidadM>> Postgm_identidadM(gm_identidadM gm_identidadM)
        {
            _context.gm_identidadMs.Add(gm_identidadM);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgm_identidadM", new { id = gm_identidadM.idIdentidadM }, gm_identidadM);
        }

        // DELETE: api/gm_identidadM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_identidadM>> Deletegm_identidadM(int id)
        {
            var gm_identidadM = await _context.gm_identidadMs.FindAsync(id);
            if (gm_identidadM == null)
            {
                return NotFound();
            }

            _context.gm_identidadMs.Remove(gm_identidadM);
            await _context.SaveChangesAsync();

            return gm_identidadM;
        }

        private bool gm_identidadMExists(int id)
        {
            return _context.gm_identidadMs.Any(e => e.idIdentidadM == id);
        }
    }
}
