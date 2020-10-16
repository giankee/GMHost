using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models.Mantenimiento;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.Mantenimiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_tareaAccionController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_tareaAccionController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_tareaAccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_tareaAccion>>> Getgm_tareaAcciones()
        {
            return await _context.gm_tareaAcciones.ToListAsync();
        }

        // GET: api/gm_tareaAccion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_tareaAccion>> Getgm_tareaAccion(int id)
        {
            var gm_tareaAccion = await _context.gm_tareaAcciones.FindAsync(id);

            if (gm_tareaAccion == null)
            {
                return NotFound();
            }

            return gm_tareaAccion;
        }

        // PUT: api/gm_tareaAccion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_tareaAccion(int id, gm_tareaAccion gm_tareaAccion)
        {
            if (id != gm_tareaAccion.idTareaAccion)
            {
                return BadRequest();
            }

            _context.Entry(gm_tareaAccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_tareaAccionExists(id))
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

        // POST: api/gm_tareaAccion
        [HttpPost]
        public async Task<ActionResult<gm_tareaAccion>> Postgm_tareaAccion(gm_tareaAccion gm_tareaAccion)
        {
            _context.gm_tareaAcciones.Add(gm_tareaAccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgm_tareaAccion", new { id = gm_tareaAccion.idTareaAccion }, gm_tareaAccion);
        }

        // DELETE: api/gm_tareaAccion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_tareaAccion>> Deletegm_tareaAccion(int id)
        {
            var gm_tareaAccion = await _context.gm_tareaAcciones.FindAsync(id);
            if (gm_tareaAccion == null)
            {
                return NotFound();
            }

            _context.gm_tareaAcciones.Remove(gm_tareaAccion);
            await _context.SaveChangesAsync();

            return gm_tareaAccion;
        }

        // DELETE: api/gm_tareaAccion
        [HttpPost]
        [Route("listDelelete")]
        public async Task<ActionResult<gm_tareaAccion>> Deletegm_tareaAcciones(gm_tareaAccion[] gm_tareaAccion)
        {
            foreach (var datoTA in gm_tareaAccion)
            {
                _context.gm_tareaAcciones.Remove(datoTA);
                await _context.SaveChangesAsync();
            }
            return NoContent();

        }


        private bool gm_tareaAccionExists(int id)
        {
            return _context.gm_tareaAcciones.Any(e => e.idTareaAccion == id);
        }
    }
}
