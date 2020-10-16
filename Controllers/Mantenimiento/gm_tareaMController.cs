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
    public class gm_tareaMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_tareaMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_tareaM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_tareaM>>> Getgm_TareasM()
        {
            return await _context.gm_tareasM.OrderBy(x => x.nombre).ToListAsync();
        }

        // GET: api/gm_tareaM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_tareaM>> Getgm_tareaM(int id)
        {
            var gm_tareaM = await _context.gm_tareasM.FindAsync(id);

            if (gm_tareaM == null)
            {
                return NotFound();
            }

            return gm_tareaM;
        }

        // PUT: api/gm_tareaM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_tareaM(int id, gm_tareaM gm_tareaM)
        {
            if (id != gm_tareaM.idTareaM)
            {
                return BadRequest();
            }

            _context.Entry(gm_tareaM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_tareaMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgm_tareaM", new { id = gm_tareaM.idTareaM }, gm_tareaM);
        }

        // POST: api/gm_tareaM
        [HttpPost]
        public async Task<ActionResult<gm_tareaM>> Postgm_tareaM(gm_tareaM gm_tareaM)
        {
            gm_tareaM nombre = await _context.gm_tareasM.Where(s => s.nombre == gm_tareaM.nombre).FirstOrDefaultAsync();
            if (nombre == null)
            {
                _context.gm_tareasM.Add(gm_tareaM);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_tareaM", new { id = gm_tareaM.idTareaM }, gm_tareaM);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_tareaM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_tareaM>> Deletegm_tareaM(int id)
        {
            var gm_tareaM = await _context.gm_tareasM.FindAsync(id);
            if (gm_tareaM == null)
            {
                return NotFound();
            }

            _context.gm_tareasM.Remove(gm_tareaM);
            await _context.SaveChangesAsync();

            return gm_tareaM;
        }

        private bool gm_tareaMExists(int id)
        {
            return _context.gm_tareasM.Any(e => e.idTareaM == id);
        }
    }
}
