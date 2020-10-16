using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
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
            if(tipo=="Motor")
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
                return await _context.gm_maquinarias.Where(x => x.tipoMaquinaria != "Motor")
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
        public async Task<IActionResult> Getgm_maquinaria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gm_maquinaria maquinaria;

            
            maquinaria = await _context.gm_maquinarias
                        .Include(s => s.planMantenimiento)
                        .Include(s => s.listdetalleFichaM).ThenInclude(a => a.item).ThenInclude(a => a.magnitud).ThenInclude(a => a.listUnidad)
                        .Include(s => s.listdetalleFichaM).ThenInclude(b => b.item).ThenInclude(b => b.listItem_identidad).ThenInclude(b => b.identidadM)
                        .Include(s => s.listdetalleFichaM).ThenInclude(y => y.listDetalleCollection).ThenInclude(y => y.itemCategory)
                        .Include(s => s.listBarcoMaquinaria)
                        .Where(s => s.idMaquina == id)
                        .FirstOrDefaultAsync();

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
            gm_maquinaria nombre = await _context.gm_maquinarias.Where(s => s.modelo == gm_maquinaria.modelo).FirstOrDefaultAsync();

            if (nombre == null)
            {
                if (gm_maquinaria.idMaquina == 0)
                {
                    _context.gm_maquinarias.Add(gm_maquinaria);
                    await _context.SaveChangesAsync();
                }
                //detalle tabla
                if (gm_maquinaria.listdetalleFichaM != null)
                    foreach (var datoF in gm_maquinaria.listdetalleFichaM)
                    {
                        if (datoF.idDetalleFichaM == 0)
                        {
                            _context.gm_detalleFichasM.Add(datoF);
                            await _context.SaveChangesAsync();
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