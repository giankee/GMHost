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
    public class gm_eventoMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_eventoMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_eventoM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_eventoM>>> Getgm_eventosM()
        {
            return await _context.gm_eventosM.Where(x=>x.estado==1). ToListAsync();
        }

        // GET: api/gm_eventoM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_eventoM>> Getgm_eventoM(int id)
        {
            var gm_eventoM = await _context.gm_eventosM.FindAsync(id);

            if (gm_eventoM == null)
            {
                return NotFound();
            }

            return gm_eventoM;
        }

        // PUT: api/gm_eventoM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_eventoM(int id, gm_eventoM gm_eventoM)
        {
            if (id != gm_eventoM.idEventoM)
            {
                return BadRequest();
            }

            _context.Entry(gm_eventoM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_eventoMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Getgm_eventoM", new { id = gm_eventoM.idEventoM }, gm_eventoM);
        }

        // POST: api/gm_eventoM
        [HttpPost]
        public async Task<ActionResult<gm_eventoM>> Postgm_eventoM(gm_eventoM gm_eventoM)
        {
            gm_eventoM nombre = await _context.gm_eventosM.Where(s => s.nombre == gm_eventoM.nombre).FirstOrDefaultAsync();
            if (nombre == null)
            {
                _context.gm_eventosM.Add(gm_eventoM);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_eventoM", new { id = gm_eventoM.idEventoM }, gm_eventoM);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_eventoM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_eventoM>> Deletegm_eventoM(int id)
        {
            var gm_eventoM = await _context.gm_eventosM.FindAsync(id);
            if (gm_eventoM == null)
            {
                return NotFound();
            }

            _context.gm_eventosM.Remove(gm_eventoM);
            await _context.SaveChangesAsync();

            return gm_eventoM;
        }

        private bool gm_eventoMExists(int id)
        {
            return _context.gm_eventosM.Any(e => e.idEventoM == id);
        }
    }
}
