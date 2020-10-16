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
    public class gm_accionMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_accionMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_accionM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_accionM>>> Getgm_AccionesM()
        {
            return await _context.gm_accionesM.OrderBy(x => x.nombre).ToListAsync();
        }

        // GET: api/gm_accionM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_accionM>> Getgm_accionM(int id)
        {
            var gm_accionM = await _context.gm_accionesM.FindAsync(id);

            if (gm_accionM == null)
            {
                return NotFound();
            }

            return gm_accionM;
        }

        // PUT: api/gm_accionM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_accionM(int id, gm_accionM gm_accionM)
        {
            if (id != gm_accionM.idAccionM)
            {
                return BadRequest();
            }

            _context.Entry(gm_accionM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_accionMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("Getgm_accionM", new { id = gm_accionM.idAccionM }, gm_accionM);
        }

        // POST: api/gm_accionM
        [HttpPost]
        public async Task<ActionResult<gm_accionM>> Postgm_accionM(gm_accionM gm_accionM)
        {
            gm_accionM nombre = await _context.gm_accionesM.Where(s => s.nombre == gm_accionM.nombre).FirstOrDefaultAsync();
            if (nombre == null)
            {
                _context.gm_accionesM.Add(gm_accionM);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_accionM", new { id = gm_accionM.idAccionM }, gm_accionM);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_accionM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_accionM>> Deletegm_accionM(int id)
        {
            var gm_accionM = await _context.gm_accionesM.FindAsync(id);
            if (gm_accionM == null)
            {
                return NotFound();
            }

            _context.gm_accionesM.Remove(gm_accionM);
            await _context.SaveChangesAsync();

            return gm_accionM;
        }

        private bool gm_accionMExists(int id)
        {
            return _context.gm_accionesM.Any(e => e.idAccionM == id);
        }
    }
}
