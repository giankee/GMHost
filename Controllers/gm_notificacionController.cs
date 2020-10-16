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
    public class gm_notificacionController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_notificacionController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_notificacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_notificacion>>> Getgm_notificaciones()
        {
            return await _context.gm_notificaciones.Where(x => x.estadoProceso == "Espera" || x.estadoProceso == "Pendiente").ToListAsync();

        }

        // GET: api/gm_notificacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_notificacion>> Getgm_notificacion(int id)
        {
            var gm_notificacion = await _context.gm_notificaciones.FindAsync(id);

            if (gm_notificacion == null)
            {
                return NotFound();
            }

            return gm_notificacion;
        }

        // PUT: api/gm_notificacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_notificacion(int id, gm_notificacion gm_notificacion)
        {
            if (id != gm_notificacion.idNotificacion)
            {
                return BadRequest();
            }

            _context.Entry(gm_notificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_notificacionExists(id))
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

        // POST: api/gm_notificacion
        [HttpPost]
        public async Task<ActionResult<gm_notificacion>> Postgm_notificacion(gm_notificacion gm_notificacion)
        {
            _context.gm_notificaciones.Add(gm_notificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgm_notificacion", new { id = gm_notificacion.idNotificacion }, gm_notificacion);
        }

        // DELETE: api/gm_notificacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_notificacion>> Deletegm_notificacion(int id)
        {
            var gm_notificacion = await _context.gm_notificaciones.FindAsync(id);
            if (gm_notificacion == null)
            {
                return NotFound();
            }

            _context.gm_notificaciones.Remove(gm_notificacion);
            await _context.SaveChangesAsync();

            return gm_notificacion;
        }

        private bool gm_notificacionExists(int id)
        {
            return _context.gm_notificaciones.Any(e => e.idNotificacion == id);
        }
    }
}
