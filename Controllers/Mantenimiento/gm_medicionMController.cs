using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.Mantenimiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_medicionMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_medicionMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_medicionM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_medicionM>>> Getgm_medicionesM()
        {
            return await _context.gm_medicionesM.ToListAsync();
        }

        // GET: api/gm_medicionM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_medicionM>> Getgm_medicionM(int id)
        {
            var gm_medicionM = await _context.gm_medicionesM.FindAsync(id);

            if (gm_medicionM == null)
            {
                return NotFound();
            }

            return gm_medicionM;
        }

        // PUT: api/gm_medicionM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_medicionM(int id, gm_medicionM gm_medicionM)
        {
            if (id != gm_medicionM.idMedicionM)
            {
                return BadRequest();
            }

            _context.Entry(gm_medicionM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_medicionMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgm_medicionM", new { id = gm_medicionM.idMedicionM }, gm_medicionM);
        }

        // POST: api/gm_medicionM
        [HttpPost]
        public async Task<ActionResult<gm_medicionM>> Postgm_medicionM(gm_medicionM gm_medicionM)
        {
            gm_medicionM nombre = await _context.gm_medicionesM.Where(s => s.nombre == gm_medicionM.nombre).FirstOrDefaultAsync();
            if (nombre == null)
            {
                _context.gm_medicionesM.Add(gm_medicionM);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_medicionM", new { id = gm_medicionM.idMedicionM }, gm_medicionM);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_medicionM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_medicionM>> Deletegm_medicionM(int id)
        {
            var gm_medicionM = await _context.gm_medicionesM.FindAsync(id);
            if (gm_medicionM == null)
            {
                return NotFound();
            }

            _context.gm_medicionesM.Remove(gm_medicionM);
            await _context.SaveChangesAsync();

            return gm_medicionM;
        }

        private bool gm_medicionMExists(int id)
        {
            return _context.gm_medicionesM.Any(e => e.idMedicionM == id);
        }
    }
}
