using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models.OrdenesTrabajoB;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.OrdenesTrabajo
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_galeriaArchivoOrdenController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_galeriaArchivoOrdenController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_galeriaArchivoOrden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_galeriaArchivoOrden>>> Getgm_galeriaArchivoOrdenes()
        {
            return await _context.gm_galeriaArchivoOrdenes.ToListAsync();
        }

        // GET: api/gm_galeriaArchivoOrden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Getgm_galeriaArchivoOrden(int id)
        {
            var gm_galeriaArchivoOrden = await _context.gm_galeriaArchivoOrdenes.FindAsync(id);

            if (gm_galeriaArchivoOrden == null)
            {
                return NotFound();
            }

            return gm_galeriaArchivoOrden;
        }

        // PUT: api/gm_galeriaArchivoOrden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_galeriaArchivoOrden(int id, gm_galeriaArchivoOrden gm_galeriaArchivoOrden)
        {
            if (id != gm_galeriaArchivoOrden.idArchivo)
            {
                return BadRequest();
            }

            _context.Entry(gm_galeriaArchivoOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_galeriaArchivoOrdenExists(id))
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

        // POST: api/gm_galeriaArchivoOrden
        [HttpPost]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Postgm_galeriaArchivoOrden(gm_galeriaArchivoOrden[] gm_galeriaArchivoOrden)
        {
            foreach (var datoG in gm_galeriaArchivoOrden)
            {
                _context.gm_galeriaArchivoOrdenes.Add(datoG);
                await _context.SaveChangesAsync();
            }
            return Ok(new { message = "Ok" });
        }

        [HttpPost]
        [Route("Delate")]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Postgm_galeriaArchivoOrdenDelate(gm_galeriaArchivoOrden[] gm_galeriaArchivoOrden)
        {
            gm_galeriaArchivoOrden auxGaleria;

            foreach (var datoG in gm_galeriaArchivoOrden)
            {
                auxGaleria = await _context.gm_galeriaArchivoOrdenes
                .Where(s => s.idArchivo == datoG.idArchivo).FirstOrDefaultAsync();
                if (auxGaleria != null)
                {
                    _context.gm_galeriaArchivoOrdenes.Remove(auxGaleria);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { message = "Ok" });
        }

        // DELETE: api/gm_galeriaArchivoOrden/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Deletegm_galeriaArchivoOrden(int id)
        {
            var gm_galeriaArchivoOrden = await _context.gm_galeriaArchivoOrdenes.FindAsync(id);
            if (gm_galeriaArchivoOrden == null)
            {
                return NotFound();
            }

            _context.gm_galeriaArchivoOrdenes.Remove(gm_galeriaArchivoOrden);
            await _context.SaveChangesAsync();

            return gm_galeriaArchivoOrden;
        }

        private bool gm_galeriaArchivoOrdenExists(int id)
        {
            return _context.gm_galeriaArchivoOrdenes.Any(e => e.idArchivo == id);
        }
    }
}
