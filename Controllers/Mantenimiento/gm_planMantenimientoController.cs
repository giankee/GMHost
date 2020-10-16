using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models;
using WebappGM_API.Models.Mantenimiento;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.Mantenimiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_planMantenimientoController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_planMantenimientoController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_planMantenimiento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_planMantenimiento>>> Getgm_planMantenimientos()
        {
            return await _context.gm_planMantenimientos.ToListAsync();
        }

        // GET: api/gm_planMantenimiento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_planMantenimiento>> Getgm_planMantenimiento(int id)
        {
            gm_planMantenimiento plan;
                plan = await _context.gm_planMantenimientos
                .Include(b => b.listIntervalo).ThenInclude(b1 => b1.listEventoMediciones).ThenInclude(b2 => b2.evento)
                .Include(c => c.listIntervalo).ThenInclude(c1 => c1.listEventoMediciones).ThenInclude(b1 => b1.medicion)
                .Include(d => d.listIntervalo).ThenInclude(d1 => d1.listTareas).ThenInclude(d2 => d2.listTareaAccion).ThenInclude(d3 => d3.accion)
                .Include(e => e.listIntervalo).ThenInclude(e1 => e1.listTareas).ThenInclude(e2 => e2.tarea)
                .Where(s => s.idPlanMantenimiento == id)
                .FirstOrDefaultAsync();

            if (plan == null)
            {
                return NotFound();
            }

            return Ok(plan);
        }

        // GET: api/gm_planMantenimiento/getPlanOrden/5
        [Route("getPlanOrden/{id:int}")]
        public async Task<ActionResult<gm_planMantenimiento>> Getgm_planOrden(int id)
        {
            gm_planMantenimiento plan;
            plan = await _context.gm_planMantenimientos.Select(x =>
            new gm_planMantenimiento
            {
                idPlanMantenimiento = x.idPlanMantenimiento,
                nombre = x.nombre,
                listIntervalo = x.listIntervalo.Select(y =>
                new gm_intervaloM
                {
                    idIntervaloM = y.idIntervaloM,
                    estadoActivado= y.estadoActivado,
                    listEventoMediciones=y.listEventoMediciones.Select(z =>
                    new gm_eventoMedicion
                    {
                        idEventoMedicion=z.idEventoMedicion,
                        eventoId= z.eventoId,
                        medicionId= z.medicionId,
                        valor= z.valor,
                        evento=z.evento,
                        medicion=z.medicion
                    }).ToList(),
                    listTareas=y.listTareas.Select(z =>
                    new gm_intervaloTarea
                    {
                        idIntervaloTarea=z.idIntervaloTarea,
                        tareaId=z.tareaId,
                        estadoActivado=z.estadoActivado,
                        tarea=z.tarea,
                        listTareaAccion=z.listTareaAccion.Select(a =>
                        new gm_tareaAccion
                        {
                            idTareaAccion=a.idTareaAccion,
                            accionId=a.accionId,
                            estadoActivado=a.estadoActivado,
                            accion=a.accion
                        }).Where(b => b.estadoActivado == true).ToList()
                    }).Where(b => b.estadoActivado == true).ToList()
                }).Where(b => b.estadoActivado == true).ToList()
            }).Where(s => s.idPlanMantenimiento == id).FirstOrDefaultAsync();

            if (plan == null)
            {
                return NotFound();
            }

            return Ok(plan);
        }


        // PUT: api/gm_planMantenimiento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_planMantenimiento(int id, gm_planMantenimiento gm_planMantenimiento)
        {
            if (id != gm_planMantenimiento.idPlanMantenimiento)
            {
                return BadRequest();
            }

            _context.Entry(gm_planMantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_planMantenimientoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (gm_planMantenimiento.listIntervalo != null)
                foreach (var datoPlan in gm_planMantenimiento.listIntervalo)
                {
                    if (datoPlan.idIntervaloM == 0)
                        _context.gm_intervalosM.Add(datoPlan);
                    else
                    {
                        _context.Entry(datoPlan).State = EntityState.Modified;
                    }
                    await _context.SaveChangesAsync();
                }

            return CreatedAtAction("Getgm_planMantenimiento", new { id = gm_planMantenimiento.idPlanMantenimiento }, gm_planMantenimiento);
        }

        // POST: api/gm_planMantenimiento
        [HttpPost]
        public async Task<ActionResult<gm_planMantenimiento>> Postgm_planMantenimiento(gm_planMantenimiento gm_planMantenimiento)
        {
            gm_planMantenimiento nombre = await _context.gm_planMantenimientos.Where(s=>s.nombre == gm_planMantenimiento.nombre).FirstOrDefaultAsync();
            if(nombre ==null)
            {
                _context.gm_planMantenimientos.Add(gm_planMantenimiento);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_planMantenimiento", new { id = gm_planMantenimiento.idPlanMantenimiento }, gm_planMantenimiento);
            }
            else
                return BadRequest(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_planMantenimiento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_planMantenimiento>> Deletegm_planMantenimiento(int id)
        {
            var gm_planMantenimiento = await _context.gm_planMantenimientos.FindAsync(id);
            if (gm_planMantenimiento == null)
            {
                return NotFound();
            }

            _context.gm_planMantenimientos.Remove(gm_planMantenimiento);
            await _context.SaveChangesAsync();

            return gm_planMantenimiento;
        }

        private bool gm_planMantenimientoExists(int id)
        {
            return _context.gm_planMantenimientos.Any(e => e.idPlanMantenimiento == id);
        }
    }
}
