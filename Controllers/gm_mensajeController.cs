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
    public class gm_mensajeController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_mensajeController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_mensaje
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_mensaje>>> Getgm_mensajes()
        {
            return await _context.gm_mensajes.ToListAsync();
        }

        // GET: api/gm_mensaje/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_mensaje>> Getgm_mensaje(int id)
        {
            var gm_mensaje = await _context.gm_mensajes.FindAsync(id);

            if (gm_mensaje == null)
            {
                return NotFound();
            }

            return gm_mensaje;
        }

        // PUT: api/gm_mensaje/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_mensaje(int id, gm_mensaje gm_mensaje)
        {
            if (id != gm_mensaje.idMensaje)
            {
                return BadRequest();
            }

            _context.Entry(gm_mensaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_mensajeExists(id))
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

        // POST: api/gm_mensaje
        [HttpPost]
        public async Task<ActionResult<gm_mensaje>> Postgm_mensaje(gm_mensaje gm_mensaje)
        {
            _context.gm_mensajes.Add(gm_mensaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgm_mensaje", new { id = gm_mensaje.idMensaje }, gm_mensaje);
        }

        // DELETE: api/gm_mensaje/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_mensaje>> Deletegm_mensaje(int id)
        {
            var gm_mensaje = await _context.gm_mensajes.FindAsync(id);
            if (gm_mensaje == null)
            {
                return NotFound();
            }

            _context.gm_mensajes.Remove(gm_mensaje);
            await _context.SaveChangesAsync();

            return gm_mensaje;
        }

        private bool gm_mensajeExists(int id)
        {
            return _context.gm_mensajes.Any(e => e.idMensaje == id);
        }
    }
}
