using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models;
using WepAppGM.Models;

namespace WebappGM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_barcoMaquinariaController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_barcoMaquinariaController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_barcoMaquinaria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_barco_maquinaria>>> Getgm_barco_maquinarias()
        {
            return await _context.gm_barco_maquinarias.ToListAsync();
        }

        // GET: api/gm_barcoMaquinaria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_barco_maquinaria>> Getgm_barco_maquinaria(int id)
        {
            gm_barco_maquinaria barcoMaquinaria;
            barcoMaquinaria = await _context.gm_barco_maquinarias.Select(x =>
                   new gm_barco_maquinaria
                   {
                       idBarcoMaquinaria = x.idBarcoMaquinaria,
                       barcoId = x.barcoId,
                       maquinariaId = x.maquinariaId,
                       nombre = x.nombre,
                       serie = x.serie,
                       potencia = x.potencia,
                       unidadId = x.unidadId,
                       horasServicio = x.horasServicio,
                       fechaIncorporacionB = x.fechaIncorporacionB,
                       checkMaquinaria = x.checkMaquinaria,
                       estado = x.estado,
                       nombreI = x.nombreI,
                       maquinaria = new gm_maquinaria
                       {
                           idMaquina = x.maquinaria.idMaquina,
                           tipoMaquinaria = x.maquinaria.tipoMaquinaria,
                           estado = x.maquinaria.estado,
                           modelo = x.maquinaria.modelo,
                           marca = x.maquinaria.marca,
                           planMantenimientoId = x.maquinaria.planMantenimientoId,
                           planMantenimiento = new gm_planMantenimiento
                           {
                               nombre = x.maquinaria.planMantenimiento.nombre,
                               descripcion =x.maquinaria.planMantenimiento.descripcion
                           },
                           listdetalleFichaM = x.maquinaria.listdetalleFichaM.Select(y =>
                           new gm_detalleFichaM
                           {
                               idDetalleFichaM = y.idDetalleFichaM,
                               itemId = y.itemId,
                               estado = y.estado,
                               item = new gm_item
                               {
                                   nombre = y.item.nombre,
                                   estado = y.item.estado,
                                   magnitud = new gm_magnitud
                                   {
                                       nombre = y.item.magnitud.nombre,
                                       listUnidad = y.item.magnitud.listUnidad.Select(y1 =>
                                       new gm_unidad
                                       {
                                           idUnidad = y1.idUnidad,
                                           nombre = y1.nombre,
                                           simbolo = y1.simbolo,
                                           estado = y1.estado
                                       }).Where(y1 => y1.estado == 1).ToList()
                                   }
                               },
                               listDetalleCollection = y.listDetalleCollection.Select(y2 =>
                               new gm_detalleCollection
                               {
                                   idDetalleCollection = y2.idDetalleCollection,
                                   itemCategoryId = y2.itemCategoryId,
                                   valor = y2.valor,
                                   unidadId = y2.unidadId,
                                   itemCategory = new gm_itemCategory
                                   {
                                       nombre = y2.itemCategory.nombre
                                   }
                               }
                               ).ToList()
                           }).Where(y => y.estado == 1).ToList(),
                       },
                       barco = new gm_barco
                       {
                           nombre = x.barco.nombre
                       }
                   }).Where(x => x.idBarcoMaquinaria == id && x.maquinaria.tipoMaquinaria == "Motor Marino")
                .FirstOrDefaultAsync();

            if (barcoMaquinaria == null)
            {
                return NotFound();
            }
            return Ok(barcoMaquinaria);
        }

        // GET: api/gm_barcoMaquinaria/getBarcoMaquinarias/5
        [Route("getBarcoMaquinarias/{id:int}")]
        public async Task<ActionResult<IEnumerable<gm_barco_maquinaria>>> Getgm_barcoMaquinaria(int id)
        {
            return await _context.gm_barco_maquinarias.Select(x =>
                   new gm_barco_maquinaria
                   {
                       idBarcoMaquinaria= x.idBarcoMaquinaria,
                       barcoId=x.barcoId,
                       maquinariaId=x.maquinariaId,
                       nombre=x.nombre,
                       serie=x.serie,
                       potencia=x.potencia,
                       unidadId=x.unidadId,
                       horasServicio=x.horasServicio,
                       fechaIncorporacionB=x.fechaIncorporacionB,
                       checkMaquinaria=x.checkMaquinaria,
                       estado=x.estado,
                       nombreI=x.nombreI,
                       maquinaria =new gm_maquinaria
                       {
                           idMaquina =x.maquinaria.idMaquina,
                           tipoMaquinaria = x.maquinaria.tipoMaquinaria,
                           estado=x.maquinaria.estado,
                           modelo=x.maquinaria.modelo,
                           marca=x.maquinaria.marca
                       },
                   }).Where(x => x.barcoId == id && x.maquinaria.estado==1 && x.maquinaria.tipoMaquinaria=="Motor Marino")
                .ToListAsync();
        }

        // PUT: api/gm_barcoMaquinaria/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_barco_maquinaria(int id, gm_barco_maquinaria gm_barco_maquinaria)
        {

            _context.Entry(gm_barco_maquinaria).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_barco_maquinariaExists(id))
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

        [Route("updateBM/{id:int}")]
        public async Task<IActionResult> Putgm_barco_maquinaria2(int id, gm_barco_maquinaria gm_barco_maquinaria)
        {
            var updateDato = _context.gm_barco_maquinarias.Where(x => x.idBarcoMaquinaria == gm_barco_maquinaria.idBarcoMaquinaria).FirstOrDefault();
            if (updateDato != null)
            {
                updateDato.horasServicio = gm_barco_maquinaria.horasServicio;
                _context.Entry(updateDato).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok(new { message = "Ok" });
        }

        // POST: api/gm_barcoMaquinaria
        [HttpPost]
        public async Task<ActionResult<gm_barco_maquinaria>> Postgm_barco_maquinaria(gm_barco_maquinaria[] gm_barco_maquinaria)
        {
            foreach (var datoBM in gm_barco_maquinaria)
            {
                if (datoBM.idBarcoMaquinaria == 0)
                    _context.gm_barco_maquinarias.Add(datoBM);
                else
                {
                    _context.Entry(datoBM).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        // DELETE: api/gm_barcoMaquinaria/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_barco_maquinaria>> Deletegm_barco_maquinaria(int id)
        {
            var gm_barco_maquinaria = await _context.gm_barco_maquinarias.FindAsync(id);
            if (gm_barco_maquinaria == null)
            {
                return NotFound();
            }

            _context.gm_barco_maquinarias.Remove(gm_barco_maquinaria);
            await _context.SaveChangesAsync();

            return gm_barco_maquinaria;
        }

        private bool gm_barco_maquinariaExists(int id)
        {
            return _context.gm_barco_maquinarias.Any(e => e.idBarcoMaquinaria == id);
        }
    }
}
