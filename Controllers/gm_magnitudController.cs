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
    public class gm_magnitudController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_magnitudController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_magnitud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_magnitud>>> Getgm_magnitudes()
        {
            return await _context.gm_magnitudes.Include(s => s.listUnidad).ToListAsync();
        }

        // GET: api/gm_magnitud/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_magnitud>> Getgm_magnitud(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gm_magnitud magnitud;


            magnitud = await _context.gm_magnitudes
                        .Include(s => s.listUnidad)
                        .Where(s => s.idMagnitud == id)
                        .FirstOrDefaultAsync();

            if (magnitud == null)
            {
                return NotFound();
            }

            return Ok(magnitud);
        }

        // PUT: api/gm_magnitud/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_magnitud(int id, gm_magnitud gm_magnitud)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_magnitud.idMagnitud)
            {
                return BadRequest();
            }

            _context.Entry(gm_magnitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_magnitudExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            if (gm_magnitud.listUnidad != null)
                foreach (var datoF in gm_magnitud.listUnidad)
                {
                    if (datoF.idUnidad == 0)
                        _context.gm_unidades.Add(datoF);
                    else
                    {
                        _context.Entry(datoF).State = EntityState.Modified;
                    }
                    await _context.SaveChangesAsync();
                }

            return CreatedAtAction("Getgm_magnitud", new { id = gm_magnitud.idMagnitud }, gm_magnitud);
        }

        // POST: api/gm_magnitud
        [HttpPost]
        public async Task<ActionResult<gm_magnitud>> Postgm_magnitud(gm_magnitud gm_magnitud)
        {
            gm_magnitud nombre = await _context.gm_magnitudes.Where(s => s.nombre == gm_magnitud.nombre).FirstOrDefaultAsync();

            if (nombre == null)
            {
                _context.gm_magnitudes.Add(gm_magnitud);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_magnitud", new { id = gm_magnitud.idMagnitud }, gm_magnitud);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_magnitud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_magnitud>> Deletegm_magnitud(int id)
        {
            var gm_magnitud = await _context.gm_magnitudes.FindAsync(id);
            if (gm_magnitud == null)
            {
                return NotFound();
            }

            _context.gm_magnitudes.Remove(gm_magnitud);
            await _context.SaveChangesAsync();

            return gm_magnitud;
        }

        private bool gm_magnitudExists(int id)
        {
            return _context.gm_magnitudes.Any(e => e.idMagnitud == id);
        }
    }
}
