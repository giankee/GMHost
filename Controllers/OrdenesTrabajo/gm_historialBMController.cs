using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models.OrdenesTrabajo;
using WebappGM_API.Models.OrdenesTrabajoB;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.OrdenesTrabajo
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_historialBMController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_historialBMController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_historialBM
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_historialBM>>> Getgm_HistorialBMs()
        {
            return await _context.gm_historialBMs.ToListAsync();
        }

        [Route("getMaquinariaHistorial/{id:int}")]//si funciona
        public async Task<ActionResult<IEnumerable<gm_historialBM>>> getMaquinariaHistorial(int id)
        {
            gm_historialBM historial;
            historial = await _context.gm_historialBMs
            .Where(s => s.barcoMaquinariaId == id)
            .FirstOrDefaultAsync();

            if (historial == null)
                return Ok(new { message = "cero" });
         
            return await _context.gm_historialBMs.Where(x => x.barcoMaquinariaId == id).Select( x =>
                    new gm_historialBM
                    {
                        idHistorialBM=x.idHistorialBM,
                        barcoMaquinariaId=x.barcoMaquinariaId,
                        tareaMId = x.tareaMId,
                        intervaloId=x.intervaloId,
                        listHistoTaOrdenes= x.listHistoTaOrdenes.Select(y =>
                          new gm_historialTaOrden
                          {
                              idHistorialTaOrden = y.idHistorialTaOrden,
                              ordenTId = y.ordenTId,
                              listAcciones=y.listAcciones,
                              ordenT = new gm_ordenTrabajoB
                              {
                                  fechaFinalizacion = y.ordenT.fechaFinalizacion,
                                  fechaIngreso = y.ordenT.fechaIngreso,
                                  valorHS = y.ordenT.valorHS
                              }
                          }).OrderByDescending(y1 => y1.ordenT.fechaIngreso).ToList(),
                        /*barcoMaquinaria = new gm_barco_maquinaria
                        {
                            maquinariaId = x.barcoMaquinaria.maquinariaId,
                        }*///parece q no la necesito en new orden pero nc aun en historial
                    })
                .ToListAsync();
                    
        }

        [Route("getBarcoHistorial/{id:int}")]//si funciona
        public async Task<ActionResult<IEnumerable<gm_historialBM>>> getBarcoHistorial(int id)
        {
            gm_historialBM historial;
            historial = await _context.gm_historialBMs
            .Where(s => s.barcoMaquinaria.barcoId == id)
            .FirstOrDefaultAsync();

            if (historial == null)
            {
                return Ok(new { message = "cero" });
            }
            else
            {
                return await _context.gm_historialBMs.OrderBy(x => x.barcoMaquinariaId).Select(x =>
                   new gm_historialBM
                   {
                       idHistorialBM = x.idHistorialBM,
                       barcoMaquinariaId = x.barcoMaquinariaId,
                       tareaMId = x.tareaMId,
                       intervaloId = x.intervaloId,
                       listHistoTaOrdenes = x.listHistoTaOrdenes.Select(y =>
                           new gm_historialTaOrden
                           {
                               idHistorialTaOrden = y.idHistorialTaOrden,
                               ordenTId = y.ordenTId,
                               ordenT = new gm_ordenTrabajoB
                               {
                                   fechaFinalizacion = y.ordenT.fechaFinalizacion,
                                   valorHS = y.ordenT.valorHS
                               }
                           }).ToList(),
                       barcoMaquinaria = new gm_barco_maquinaria
                       {
                           idBarcoMaquinaria = x.barcoMaquinaria.idBarcoMaquinaria,
                           barcoId = x.barcoMaquinaria.barcoId,
                           maquinariaId = x.barcoMaquinaria.maquinariaId,
                           checkMaquinaria = x.barcoMaquinaria.checkMaquinaria,
                           maquinaria = new gm_maquinaria
                           {
                               idMaquina=x.barcoMaquinaria.maquinaria.idMaquina,
                               modelo=x.barcoMaquinaria.maquinaria.modelo
                           }
                       }
                   }).Where(x=>x.barcoMaquinaria.barcoId==id).ToListAsync();
            }
        }

        // PUT: api/gm_historialBM/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_historialBM(int id, gm_historialBM gm_historialBM)
        {
            if (id != gm_historialBM.idHistorialBM)
            {
                return BadRequest();
            }

            _context.Entry(gm_historialBM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_historialBMExists(id))
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

        // POST: api/gm_historialBM
        [HttpPost]
        public async Task<ActionResult<gm_historialBM>> Postgm_historialBM(gm_historialBM[] gm_historialBM)
        {
            gm_historialBM historial;

            foreach (var datoL in gm_historialBM)
            {
                historial = await _context.gm_historialBMs
                .Where(s => s.barcoMaquinariaId == datoL.barcoMaquinariaId && s.tareaMId == datoL.tareaMId && (s.intervaloId == datoL.intervaloId || (s.intervaloId==null && datoL.intervaloId==null))).FirstOrDefaultAsync();
                if (historial != null)
                {
                    foreach (var datoHOrden in datoL.listHistoTaOrdenes)
                    {
                        if (datoHOrden.idHistorialTaOrden == 0)
                        {
                            datoHOrden.historialBMID = historial.idHistorialBM;
                            _context.gm_historialTaOrdenes.Add(datoHOrden);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    _context.gm_historialBMs.Add(datoL);
                    await _context.SaveChangesAsync();
                    if(datoL.listHistoTaOrdenes != null)
                        foreach (var datoHOrden in datoL.listHistoTaOrdenes)
                        {
                            if (datoHOrden.idHistorialTaOrden == 0)
                            {
                                _context.gm_historialTaOrdenes.Add(datoHOrden);
                                await _context.SaveChangesAsync();
                            }
                                
                        }
                }
            }
            return await _context.gm_historialBMs.Select(x =>
                   new gm_historialBM
                   {
                       idHistorialBM = x.idHistorialBM,
                       barcoMaquinariaId = x.barcoMaquinariaId,
                       tareaMId = x.tareaMId,
                       intervaloId = x.intervaloId,
                       listHistoTaOrdenes = x.listHistoTaOrdenes.Select(y =>
                            new gm_historialTaOrden
                            {
                                idHistorialTaOrden = y.idHistorialTaOrden,
                                ordenTId = y.ordenTId,
                                ordenT = new gm_ordenTrabajoB
                                {
                                    fechaFinalizacion = y.ordenT.fechaFinalizacion,
                                    valorHS = y.ordenT.valorHS
                                }
                            }).ToList(),
                   }).LastOrDefaultAsync();
        }

        // DELETE: api/gm_historialBM/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_historialBM>> Deletegm_historialBM(int id)
        {
            var gm_historialBM = await _context.gm_historialBMs.FindAsync(id);
            if (gm_historialBM == null)
            {
                return NotFound();
            }

            _context.gm_historialBMs.Remove(gm_historialBM);
            await _context.SaveChangesAsync();

            return gm_historialBM;
        }

        private bool gm_historialBMExists(int id)
        {
            return _context.gm_historialBMs.Any(e => e.idHistorialBM == id);
        }
    }
}
