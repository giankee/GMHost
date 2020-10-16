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
    public class gm_alertaController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_alertaController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_alerta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_alerta>>> Getgm_alertas()
        {
            return await _context.gm_alertas.ToListAsync();
        }

        [Route("getAlertas/{tipo}")]
        public async Task<ActionResult<IEnumerable<gm_alerta>>> getAlertas(string tipo)
        {
            return await _context.gm_alertas.Where(x => x.tipoMaquinaria == tipo).ToListAsync();
        }


        // GET: api/gm_alerta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_alerta>> Getgm_alerta(int id)
        {
            var gm_alerta = await _context.gm_alertas.FindAsync(id);

            if (gm_alerta == null)
            {
                return NotFound();
            }

            return gm_alerta;
        }

        // PUT: api/gm_alerta/5
        /*[HttpPut("{id}")]//no lo uso
        public async Task<IActionResult> Putgm_alerta(int id, gm_alerta gm_alerta)
        {
            if (id != gm_alerta.idAlerta)
            {
                return BadRequest();
            }

            _context.Entry(gm_alerta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_alertaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        [HttpPut]
        [Route("Actualiza")]
        public async Task<ActionResult<gm_alerta>> Putgm_alertaAll(gm_alerta[] gm_Alertas)
        {
            foreach (var datoA in gm_Alertas)
            {
                _context.Entry(datoA).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        // POST: api/gm_alerta
        [HttpPost]
        public async Task<ActionResult<gm_alerta>> Postgm_alerta(gm_alerta gm_alerta)
        {
            _context.gm_alertas.Add(gm_alerta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgm_alerta", new { id = gm_alerta.idAlerta }, gm_alerta);
        }

        // DELETE: api/gm_alerta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_alerta>> Deletegm_alerta(int id)
        {
            var gm_alerta = await _context.gm_alertas.FindAsync(id);
            if (gm_alerta == null)
            {
                return NotFound();
            }

            _context.gm_alertas.Remove(gm_alerta);
            await _context.SaveChangesAsync();

            return gm_alerta;
        }

        private bool gm_alertaExists(int id)
        {
            return _context.gm_alertas.Any(e => e.idAlerta == id);
        }
    }
}
