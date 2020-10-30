using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models;
using WepAppGM.Models;

namespace WebAppGM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_maquinariaController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_maquinariaController(DbGmContext context, IHostingEnvironment host)
        {
            _context = context;
        }

        // GET: api/gm_maquinaria
        [HttpGet]
        public IEnumerable<gm_maquinaria> Getgm_maquinarias()
        {
            var maquinarias = _context.gm_maquinarias
                .Select(x =>
                    new gm_maquinaria
                    {
                        idMaquina = x.idMaquina,
                        modelo = x.modelo,
                        marca =x.marca,
                        tipoMaquinaria = x.tipoMaquinaria,
                        estado = x.estado
                    }).Where(x => x.estado == 1).ToList();

            return maquinarias;
        }

        [Route("getMaquinariasEspecifico/{tipo}")]
        public async Task<ActionResult<IEnumerable<gm_maquinaria>>> getMaquinariasEspecifico(string tipo)
        {
            if(tipo=="Motor Marino")
                return await _context.gm_maquinarias.Where(x => x.tipoMaquinaria == tipo)
                .Select(x =>
                    new gm_maquinaria
                    {
                        idMaquina = x.idMaquina,
                        modelo = x.modelo,
                        marca = x.marca,
                        tipoMaquinaria = x.tipoMaquinaria,
                        estado = x.estado
                    }).ToListAsync();
            else
                return await _context.gm_maquinarias.Where(x => x.tipoMaquinaria != "Motor Marino")
                .Select(x =>
                    new gm_maquinaria
                    {
                        idMaquina = x.idMaquina,
                        modelo = x.modelo,
                        tipoMaquinaria = x.tipoMaquinaria,
                        estado = x.estado
                    }).ToListAsync();
        }

        // GET: api/gm_maquinaria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgm_maquinaria([FromRoute] int id)//refactorar muchos datos inservibles primero  lo uso en maquinaria update 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gm_maquinaria maquinaria;

            maquinaria = await _context.gm_maquinarias.Select(x =>
                   new gm_maquinaria
                   {
                       idMaquina = x.idMaquina,
                       tipoMaquinaria = x.tipoMaquinaria,
                       marca = x.marca,
                       modelo = x.modelo,
                       planMantenimientoId = x.planMantenimientoId,
                       estado = x.estado,
                       listBarcoMaquinaria = x.listBarcoMaquinaria.Select(y =>
                          new gm_barco_maquinaria
                          {
                              idBarcoMaquinaria = y.idBarcoMaquinaria,
                              barcoId = y.barcoId,
                              nombre = y.nombre,
                              serie=y.serie,
                              checkMaquinaria = y.checkMaquinaria,
                              estado=y.estado
                          }).ToList(),
                       listdetalleFichaM = x.listdetalleFichaM.Select(z =>
                        new gm_detalleFichaM
                        {
                            idDetalleFichaM = z.idDetalleFichaM,
                            maquinariaId = z.maquinariaId,
                            estado = z.estado,
                            itemId = z.itemId,
                            item = new gm_item
                            {
                                idItem = z.item.idItem,
                                nombre = z.item.nombre,
                                magnitudId = z.item.magnitudId,
                                magnitud = new gm_magnitud
                                {
                                    idMagnitud = z.item.magnitud.idMagnitud,
                                    nombre = z.item.magnitud.nombre,
                                    estado = z.item.magnitud.estado,
                                    listUnidad = z.item.magnitud.listUnidad.Select(z1 =>
                                    new gm_unidad
                                    {
                                        idUnidad = z1.idUnidad,
                                        nombre = z1.nombre,
                                        simbolo = z1.simbolo,
                                        estado = z1.estado
                                    }).ToList()
                                }
                            },
                            listDetalleCollection = z.listDetalleCollection.Select(z2 =>
                             new gm_detalleCollection
                            {
                                idDetalleCollection = z2.idDetalleCollection,
                                detalleFichaMId = z2.detalleFichaMId,
                                itemCategoryId = z2.itemCategoryId,
                                unidadId = z2.unidadId,
                                valor = z2.valor,
                                itemCategory = new gm_itemCategory
                                {
                                    idItemCategory = z2.itemCategory.idItemCategory,
                                    nombre = z2.itemCategory.nombre,
                                    estado = z2.itemCategory.estado
                                }
                            }).ToList()
                        }).ToList()
                   }).Where(s => s.idMaquina == id).FirstOrDefaultAsync();

            if (maquinaria == null)
            {
                return NotFound();
            }

            return Ok(maquinaria);
        }

        // PUT: api/gm_maquinaria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_maquinaria([FromRoute] int id, [FromBody] gm_maquinaria gm_maquinaria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_maquinaria.idMaquina)
            {
                return BadRequest();
            }

            _context.Entry(gm_maquinaria).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_maquinariaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (gm_maquinaria.listdetalleFichaM != null)
                foreach (var datoF in gm_maquinaria.listdetalleFichaM)
                {
                    if (datoF.idDetalleFichaM != 0)
                    {
                        if (datoF.estado == 0)//elimina
                        {
                            var gmDelateFicha =  _context.gm_detalleFichasM.Where(x => x.idDetalleFichaM == datoF.idDetalleFichaM).FirstOrDefault();
                            if (gmDelateFicha != null) { 
                                _context.gm_detalleFichasM.Remove(gmDelateFicha);
                                _context.SaveChanges();
                            }
                        }
                        else//actualiza
                        {
                            _context.Entry(datoF).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                            foreach (var datoC in datoF.listDetalleCollection)
                            {
                                if (datoC.idDetalleCollection == 0)
                                    _context.gm_detalleCollection.Add(datoC);
                                else
                                    _context.Entry(datoC).State = EntityState.Modified;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }else
                        if (datoF.idDetalleFichaM == 0 && datoF.estado == 1)
                        {
                            _context.gm_detalleFichasM.Add(datoF);
                            await _context.SaveChangesAsync();
                        }
                }

            if (gm_maquinaria.listBarcoMaquinaria != null)
            {
                foreach (var datoBM in gm_maquinaria.listBarcoMaquinaria)
                {
                    if (datoBM.idBarcoMaquinaria != 0)
                    {
                        _context.Entry(datoBM).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.gm_barco_maquinarias.Add(datoBM);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            return Ok(new { message = "Ok" });
        }

        // POST: api/gm_maquinaria
        [HttpPost]
         public async Task<IActionResult> Postgm_maquinaria([FromBody] gm_maquinaria gm_maquinaria)
         {
            gm_maquinaria nombre = await _context.gm_maquinarias.Where(s => s.modelo == gm_maquinaria.modelo && s.tipoMaquinaria==gm_maquinaria.tipoMaquinaria).FirstOrDefaultAsync();

            if (nombre == null)
            {
                if (gm_maquinaria.idMaquina == 0)
                {
                    _context.gm_maquinarias.Add(gm_maquinaria);
                    await _context.SaveChangesAsync();
                }
                //detalle tabla
                if (gm_maquinaria.listdetalleFichaM != null) {
                    foreach (var datoF in gm_maquinaria.listdetalleFichaM)
                    {
                        if (datoF.idDetalleFichaM == 0)
                        {
                            _context.gm_detalleFichasM.Add(datoF);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                if (gm_maquinaria.listBarcoMaquinaria != null)
                {
                    foreach (var datoBM in gm_maquinaria.listBarcoMaquinaria)
                    {
                        if (datoBM.idBarcoMaquinaria == 0)
                        {
                            _context.gm_barco_maquinarias.Add(datoBM);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                return Ok(new { message = "Ok" });
            }
            else
                return Ok(new { message = "Nombre repetido" });

        }

        // DELETE: api/gm_maquinaria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegm_maquinaria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gm_maquinaria = await _context.gm_maquinarias.FindAsync(id);
            if (gm_maquinaria == null)
            {
                return NotFound();
            }

            _context.gm_maquinarias.Remove(gm_maquinaria);
            await _context.SaveChangesAsync();

            return Ok(gm_maquinaria);
        }

        private bool gm_maquinariaExists(int id)
        {
            return _context.gm_maquinarias.Any(e => e.idMaquina == id);
        }
    }
}