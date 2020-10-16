using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models;
using WebappGM_API.Models.OrdenesTrabajoB;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.OrdenesTrabajo
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_ordenTrabajoController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_ordenTrabajoController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_ordenTrabajo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_ordenTrabajoB>>> Getgm_OrdenTrabajos()
        {
            var ordenT = await _context.gm_ordenTrabajosB
                .Select(x =>
                    new gm_ordenTrabajoB
                    {
                        idOrdenT=x.idOrdenT,
                        titulo=x.titulo,
                        tipoMantenimiento=x.tipoMantenimiento,
                        barcoMaquinariaId=x.barcoMaquinariaId,
                        fechaIngreso=x.fechaIngreso,
                        fechaFinalizacion=x.fechaFinalizacion,
                        estadoProceso=x.estadoProceso,
                        barcoMaquinaria= new gm_barco_maquinaria
                        {
                            idBarcoMaquinaria=x.barcoMaquinaria.idBarcoMaquinaria,
                            barcoId=x.barcoMaquinaria.barcoId,
                            nombre=x.barcoMaquinaria.nombre,
                            barco= new gm_barco
                            {
                                nombre=x.barcoMaquinaria.barco.nombre
                            },
                        }
                    }).OrderByDescending(x => x.idOrdenT).ToListAsync();

            return ordenT;
        }

        // GET: api/gm_ordenTrabajo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_ordenTrabajoB>> Getgm_ordenTrabajo(int id)
        {
            gm_ordenTrabajoB orden;
            orden = await _context.gm_ordenTrabajosB.Select(x =>
                new gm_ordenTrabajoB
                {
                    idOrdenT = x.idOrdenT,
                    titulo = x.titulo,
                    barcoMaquinariaId = x.barcoMaquinariaId,
                    tipoMantenimiento = x.tipoMantenimiento,
                    fechaIngreso = x.fechaIngreso,
                    fechaFinalizacion = x.fechaFinalizacion,
                    estadoProceso = x.estadoProceso,
                    responsable = x.responsable,
                    supervisor = x.supervisor,
                    descripcionSolicitud = x.descripcionSolicitud,
                    valorHS = x.valorHS,
                    barcoMaquinaria= new gm_barco_maquinaria
                    {
                        idBarcoMaquinaria= x.barcoMaquinaria.idBarcoMaquinaria,
                        barcoId=x.barcoMaquinaria.barcoId,
                        maquinariaId=x.barcoMaquinaria.maquinariaId,
                        nombre= x.barcoMaquinaria.nombre,
                        serie=x.barcoMaquinaria.serie,
                        fechaIncorporacionB=x.barcoMaquinaria.fechaIncorporacionB,
                        checkMaquinaria=x.barcoMaquinaria.checkMaquinaria,
                        barco= new gm_barco
                        {
                            nombre= x.barcoMaquinaria.barco.nombre,
                            numMatricula = x.barcoMaquinaria.barco.numMatricula
                        },
                        maquinaria = new gm_maquinaria
                        {
                            modelo= x.barcoMaquinaria.maquinaria.modelo,
                            marca= x.barcoMaquinaria.maquinaria.marca,
                            tipoMaquinaria=x.barcoMaquinaria.maquinaria.tipoMaquinaria,
                        }
                    },
                    listTareaO = x.listTareaO.Select(y =>
                      new gm_tareaO
                      {
                          idTareaO = y.idTareaO,
                          ordenTrabajoId = y.ordenTrabajoId,
                          tareaMId = y.tareaMId,
                          observacion = y.observacion,
                          isNormal=y.isNormal,
                          reponsableTarea = y.reponsableTarea,
                          estadoRealizado = y.estadoRealizado,
                          notificacionId = y.notificacionId,
                          tareaM = new gm_tareaM
                          {
                              nombre = y.tareaM.nombre,
                          },
                          notificacion = y.notificacion,
                          
                          listAccionesRealizadaO = y.listAccionesRealizadaO.Select(z =>
                            new gm_accionO
                              {
                                idAccionO = z.idAccionO,
                                tareaOId = z.tareaOId,
                                accionId = z.accionId,
                                nombreAccionM = z.nombreAccionM,
                                estadoRealizado = z.estadoRealizado,
                                strIntervalos=z.strIntervalos,
                              }).ToList(),
                      }).ToList(),
                    listGaleriaArchivoOrdenes = x.listGaleriaArchivoOrdenes.Select(z =>
                    new gm_galeriaArchivoOrden
                    {
                        idArchivo = z.idArchivo,
                        ordenTrabajoId = z.ordenTrabajoId,
                        tareaOId = z.tareaOId,
                        nombreArchivo = z.nombreArchivo,
                        tipoArchivo = z.tipoArchivo,
                        rutaArchivo = z.rutaArchivo
                    }).Where(z => z.ordenTrabajoId == id).ToList()
                }).Where(x => x.idOrdenT == id)
            .FirstOrDefaultAsync();

            if (orden == null)
            {
                return NotFound();
            }

            return Ok(orden);
        }

        // GET: api/gm_ordenTrabajo/getOrdenTrabajoAnteriores/1
        [Route("getOrdenTrabajoAnteriores/{id:int}")]//si funciona
        public async Task<ActionResult<IEnumerable<gm_ordenTrabajoB>>> getOrdenTrabajoMaquinariaAnteriores(int id)
        {
            gm_ordenTrabajoB ordenes;
            ordenes = await _context.gm_ordenTrabajosB
            .Where(s => s.barcoMaquinariaId == id)
            .FirstOrDefaultAsync();

            if (ordenes == null)
            {
                return Ok(new { message = "cero" });
            }
            else
            {
                return await _context.gm_ordenTrabajosB.Where(x => x.barcoMaquinariaId == id).Select(x =>
                   new gm_ordenTrabajoB
                   {
                       idOrdenT=x.idOrdenT,
                       titulo=x.titulo,
                       tipoMantenimiento=x.tipoMantenimiento,
                       barcoMaquinariaId=x.barcoMaquinariaId,
                       valorHS=x.valorHS,
                       estadoProceso=x.estadoProceso,
                       fechaFinalizacion=x.fechaFinalizacion,
                       fechaIngreso=x.fechaIngreso,
                       listTareaO = x.listTareaO.Select(y =>
                      new gm_tareaO
                      {
                          idTareaO = y.idTareaO,
                          ordenTrabajoId = y.ordenTrabajoId,
                          tareaMId = y.tareaMId,
                          reponsableTarea = y.reponsableTarea,
                          estadoRealizado = y.estadoRealizado,
                          tareaM = new gm_tareaM
                          {
                              idTareaM = y.tareaM.idTareaM,
                              nombre = y.tareaM.nombre,
                              estado = y.tareaM.estado
                          }
                      }).Where(y => y.ordenTrabajoId == x.idOrdenT).ToList(),
                   }).ToListAsync();
            }
        }

        // GET: api/gm_ordenTrabajo/getBuscarOrdenPendiente/5
        [Route("getBuscarOrdenPendiente/{id:int}")]//si funciona
        public async Task<ActionResult<gm_ordenTrabajoB>> GetBuscarOrdenPendiente(int id)
        {
            gm_ordenTrabajoB orden;
            orden = await _context.gm_ordenTrabajosB
            .Where(s => s.barcoMaquinariaId == id && (s.estadoProceso=="Preliminar" ||s.estadoProceso=="En Proceso"))
            .FirstOrDefaultAsync();

            if (orden == null)
            {
                return Ok(new { message = "no pendientes" });
            }
            return Ok(orden);
        }


        // PUT: api/gm_ordenTrabajo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_ordenTrabajo(int id, gm_ordenTrabajoB gm_ordenTrabajo)
        {
            _context.Entry(gm_ordenTrabajo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_ordenTrabajoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (gm_ordenTrabajo.listTareaO != null)
                foreach (var datoT in gm_ordenTrabajo.listTareaO)
                {
                    if (datoT.idTareaO == 0) { 
                        _context.gm_tareasO.Add(datoT);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        if (datoT.notificacion!=null)
                        {
                            if (datoT.notificacion.idNotificacion == 0) { 
                                _context.gm_notificaciones.Add(datoT.notificacion);
                                await _context.SaveChangesAsync();
                            }
                            else
                               _context.Entry(datoT.notificacion).State = EntityState.Modified;
                        }
                        _context.Entry(datoT).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                        foreach (var datoA in datoT.listAccionesRealizadaO)
                        {
                            if (datoA.idAccionO == 0)
                                _context.gm_accionesO.Add(datoA);
                            else
                                _context.Entry(datoA).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
            return Ok(new { message = "Ok" });
        }

        // POST: api/gm_ordenTrabajo
        [HttpPost]
        public async Task<ActionResult<gm_ordenTrabajoB>> Postgm_ordenTrabajo(gm_ordenTrabajoB gm_ordenTrabajo)
        {
            if (gm_ordenTrabajo.idOrdenT == 0)
            {
                _context.gm_ordenTrabajosB.Add(gm_ordenTrabajo);
                await _context.SaveChangesAsync();
            }

            if (gm_ordenTrabajo.listTareaO != null) { 
                foreach (var datoTareaO in gm_ordenTrabajo.listTareaO)
                {
                    if (datoTareaO.idTareaO == 0)
                    {
                        _context.gm_tareasO.Add(datoTareaO);
                        await _context.SaveChangesAsync();

                        if (datoTareaO.listAccionesRealizadaO != null)
                        {
                            foreach (var datoAccionO in datoTareaO.listAccionesRealizadaO)
                            {
                                if (datoAccionO.idAccionO == 0)
                                {
                                    _context.gm_accionesO.Add(datoAccionO);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
                    }
                }
            }
            return CreatedAtAction("Getgm_ordenTrabajo", new { id = gm_ordenTrabajo.idOrdenT }, gm_ordenTrabajo);
        }

        // DELETE: api/gm_ordenTrabajo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_ordenTrabajoB>> Deletegm_ordenTrabajo(int id)
        {
            var gm_ordenTrabajo = await _context.gm_ordenTrabajosB.FindAsync(id);
            if (gm_ordenTrabajo == null)
            {
                return NotFound();
            }

            _context.gm_ordenTrabajosB.Remove(gm_ordenTrabajo);
            await _context.SaveChangesAsync();

            return gm_ordenTrabajo;
        }

        private bool gm_ordenTrabajoExists(int id)
        {
            return _context.gm_ordenTrabajosB.Any(e => e.idOrdenT == id);
        }
    }
}
