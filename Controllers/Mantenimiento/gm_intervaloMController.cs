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
    public class gm_intervaloMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_intervaloMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_intervaloM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_intervaloM>>> Getgm_intervalosM()
        {
            return await _context.gm_intervalosM.ToListAsync();
        }

        // GET: api/gm_intervaloM/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_intervaloM>> Getgm_intervaloM(int id)
        {
            gm_intervaloM intervalo;
            intervalo = await _context.gm_intervalosM
                .Include(b => b.listEventoMediciones).ThenInclude(b1 => b1.evento)
                .Include(b => b.listEventoMediciones).ThenInclude(b1 => b1.medicion)
                .Include(c => c.listTareas).ThenInclude(c1 => c1.listTareaAccion).ThenInclude(c2=>c2.accion)
                .Include(c => c.listTareas).ThenInclude(c1 => c1.tarea)
                .Where(s => s.idIntervaloM == id)
                .FirstOrDefaultAsync();

            if (intervalo == null)
            {
                return NotFound();
            }

            return Ok(intervalo);
        }

        // PUT: api/gm_intervaloM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_intervaloM(int id, gm_intervaloM gm_intervaloM)
        {
            if (id != gm_intervaloM.idIntervaloM)
            {
                return BadRequest();
            }

            _context.Entry(gm_intervaloM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_intervaloMExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (gm_intervaloM.listTareas != null)
                foreach (var datoIT in gm_intervaloM.listTareas)
                {
                    if (datoIT.idIntervaloTarea == 0) { 
                        _context.gm_intervaloTareas.Add(datoIT);

                        foreach (var datoTA in datoIT.listTareaAccion)
                        {
                            if (datoTA.idTareaAccion == 0)
                            {
                                _context.gm_tareaAcciones.Add(datoTA);
                                await _context.SaveChangesAsync();
                            }
                        }
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(datoIT).State = EntityState.Modified;

                        foreach (var datoTA in datoIT.listTareaAccion)
                        {
                            if (datoTA.idTareaAccion == 0)
                                _context.gm_tareaAcciones.Add(datoTA);
                            else
                                _context.Entry(datoTA).State = EntityState.Modified;
                        }
                        await _context.SaveChangesAsync();
                    }
                    
                }
            return CreatedAtAction("Getgm_intervaloM", new { id = gm_intervaloM.idIntervaloM }, gm_intervaloM);
        }

        // POST: api/gm_intervaloM
        [HttpPost]
        public async Task<ActionResult<gm_intervaloM>> Postgm_intervaloM(gm_intervaloM gm_intervaloM)
        {
            if (gm_intervaloM.idIntervaloM == 0)
            {
                _context.gm_intervalosM.Add(gm_intervaloM);
                await _context.SaveChangesAsync();
            }
            //lista EM
            if (gm_intervaloM.listEventoMediciones != null)
                foreach (var datoEM in gm_intervaloM.listEventoMediciones)
                {
                    if (datoEM.idEventoMedicion == 0)
                    {
                        _context.gm_eventoMediciones.Add(datoEM);
                        await _context.SaveChangesAsync();
                    }
                }

            //lista IT
            if (gm_intervaloM.listTareas != null)
                foreach (var datoIT in gm_intervaloM.listTareas)
                {
                    if (datoIT.idIntervaloTarea == 0)
                    {
                        _context.gm_intervaloTareas.Add(datoIT);
                        await _context.SaveChangesAsync();
                    }
                    //lista TA
                    if (datoIT.listTareaAccion != null)
                        foreach (var datoTA in datoIT.listTareaAccion)
                        {
                            if (datoTA.idTareaAccion == 0)
                            {
                                _context.gm_tareaAcciones.Add(datoTA);
                                await _context.SaveChangesAsync();
                            }
                        }
                }

            return CreatedAtAction("Getgm_intervaloM", new { id = gm_intervaloM.idIntervaloM }, gm_intervaloM);
        }

        // DELETE: api/gm_intervaloM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_intervaloM>> Deletegm_intervaloM(int id)
        {
            var gm_intervaloM = await _context.gm_intervalosM.FindAsync(id);
            if (gm_intervaloM == null)
            {
                return NotFound();
            }

            _context.gm_intervalosM.Remove(gm_intervaloM);
            await _context.SaveChangesAsync();

            return gm_intervaloM;
        }

        private bool gm_intervaloMExists(int id)
        {
            return _context.gm_intervalosM.Any(e => e.idIntervaloM == id);
        }
    }
}
