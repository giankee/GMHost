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
    public class gm_galeriaArchivoBarcoController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_galeriaArchivoBarcoController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_galeriaArchivoBarco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_galeriaArchivoBarco>>> Getgm_galeriaArchivoBarcos()
        {
            return await _context.gm_galeriaArchivoBarcos.ToListAsync();
        }

        // GET: api/gm_galeriaArchivoBarco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoBarco>> Getgm_galeriaArchivoBarco(int id)
        {
            var gm_galeriaArchivoBarco = await _context.gm_galeriaArchivoBarcos.FindAsync(id);

            if (gm_galeriaArchivoBarco == null)
            {
                return NotFound();
            }

            return gm_galeriaArchivoBarco;
        }

        // PUT: api/gm_galeriaArchivoBarco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_galeriaArchivoBarco(int id, gm_galeriaArchivoBarco gm_galeriaArchivoBarco)
        {
            if (id != gm_galeriaArchivoBarco.idGaleriaGeneral)
            {
                return BadRequest();
            }

            _context.Entry(gm_galeriaArchivoBarco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_galeriaArchivoBarcoExists(id))
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

        // POST: api/gm_galeriaArchivoBarco
        [HttpPost]
        public async Task<ActionResult<gm_galeriaArchivoBarco>> Postgm_galeriaArchivoOrden(gm_galeriaArchivoBarco[] gm_galeriaArchivoBarco)
        {
            foreach (var datoG in gm_galeriaArchivoBarco)
            {
                _context.gm_galeriaArchivoBarcos.Add(datoG);
                await _context.SaveChangesAsync();
            }
            return Ok(new { message = "Ok" });
        }

        [HttpPost]
        [Route("Delate")]
        public async Task<ActionResult<gm_galeriaArchivoBarco>> Postgm_galeriaArchivoBarcoDelate(gm_galeriaArchivoBarco[] gm_galeriaArchivoOrden)
        {
            gm_galeriaArchivoBarco auxGaleria;

            foreach (var datoG in gm_galeriaArchivoOrden)
            {
                auxGaleria = await _context.gm_galeriaArchivoBarcos
                .Where(s => s.idGaleriaGeneral == datoG.idGaleriaGeneral).FirstOrDefaultAsync();
                if (auxGaleria != null)
                {
                    _context.gm_galeriaArchivoBarcos.Remove(auxGaleria);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { message = "Ok" });
        }


        // DELETE: api/gm_galeriaArchivoBarco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoBarco>> Deletegm_galeriaArchivoBarco(int id)
        {
            var gm_galeriaArchivoBarco = await _context.gm_galeriaArchivoBarcos.FindAsync(id);
            if (gm_galeriaArchivoBarco == null)
            {
                return NotFound();
            }

            _context.gm_galeriaArchivoBarcos.Remove(gm_galeriaArchivoBarco);
            await _context.SaveChangesAsync();

            return gm_galeriaArchivoBarco;
        }

        private bool gm_galeriaArchivoBarcoExists(int id)
        {
            return _context.gm_galeriaArchivoBarcos.Any(e => e.idGaleriaGeneral == id);
        }
    }
}
