using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WepAppGM.Models;

namespace WebAppGM.Controllers
{
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class gm_barcoController : ControllerBase
    {
        private readonly DbGmContext _context;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };

        public gm_barcoController(DbGmContext context, IHostingEnvironment host)
        {
            _context = context;
        }

        // GET: api/gm_barco
        [HttpGet]
        public IEnumerable<gm_barco> Getgm_barcos()
        {
            var barcos = _context.gm_barcos.Where(x => x.estado==1)
                .Select(x =>
                    new gm_barco
                    {
                        idBarco = x.idBarco,
                        nombre= x.nombre,
                        numMatricula=x.numMatricula,
                        anioConstruccion=x.anioConstruccion,
                    }).ToList();

            return barcos;
        }

        // GET: api/gm_barco/getBarcoSelect2
        [HttpGet]
        [Route("getBarcoSelect2")]
        public IEnumerable<gm_barco> getBarcoSelect2()
        {
            var barcos = _context.gm_barcos
                .Select(x =>
                    new gm_barco
                    {
                        idBarco = x.idBarco,
                        nombre = x.nombre,
                        nombreI=x.nombreI,
                        listBarcoMaquinarias = x.listBarcoMaquinarias.Select(y =>
                        new gm_barco_maquinaria
                        {
                            
                            idBarcoMaquinaria = y.idBarcoMaquinaria,
                            nombre=y.nombre,
                            barcoId=y.barcoId,
                            maquinariaId = y.maquinariaId,
                            serie=y.serie,
                            fechaIncorporacionB =y.fechaIncorporacionB,
                            horasServicio = y.horasServicio,
                            checkMaquinaria = y.checkMaquinaria,
                            maquinaria = new gm_maquinaria
                            {
                                idMaquina = y.maquinaria.idMaquina,
                                planMantenimientoId=y.maquinaria.planMantenimientoId
                            }
                        }).Where(b=>b.checkMaquinaria==true && b.maquinaria.planMantenimientoId!=null).ToList()
                    }).ToList();

            return barcos;
        }

        // GET: api/gm_barco/getBarcoSelect3
        [HttpGet]
        [Route("getBarcoSelect3")]
        public IEnumerable<gm_barco> getBarcoSelect3()
        {
            var barcos = _context.gm_barcos
                .Select(x =>
                    new gm_barco
                    {
                        idBarco = x.idBarco,
                        nombre = x.nombre,
                        listBarcoMaquinarias = x.listBarcoMaquinarias.Select(y =>
                        new gm_barco_maquinaria
                        {
                            idBarcoMaquinaria = y.idBarcoMaquinaria,
                            nombre = y.nombre,
                            barcoId = y.barcoId,
                            maquinariaId = y.maquinariaId,
                            serie = y.serie,
                            horasServicio = y.horasServicio,
                            checkMaquinaria = y.checkMaquinaria,
                            fechaIncorporacionB = y.fechaIncorporacionB,
                            maquinaria = new gm_maquinaria
                            {
                                planMantenimientoId = y.maquinaria.planMantenimientoId
                            }
                        }).Where(b => b.checkMaquinaria == true && b.maquinaria.planMantenimientoId != null).ToList()
                    }).Where(a=> a.listBarcoMaquinarias.Count!=0).ToList();

            return barcos;
        }

        // GET: api/gm_barco/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getgm_barco([FromRoute] int id)
        {
           if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gm_barco = await _context.gm_barcos
                .Include(b => b.listBarcoMaquinarias).ThenInclude(b1 => b1.maquinaria)
                .Include(c => c.listGaleriaArchivoBarcos)
                .Where(s => s.idBarco == id).FirstOrDefaultAsync();

            if (gm_barco == null)
            {
                return NotFound();
            }

            return Ok(gm_barco);
        }

        // PUT: api/gm_barco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_barco([FromRoute] int id, [FromBody] gm_barco gm_barco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_barco.idBarco)
            {
                return BadRequest();
            }

            _context.Entry(gm_barco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_barcoExists(id))
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

        // POST: api/gm_barco
        [HttpPost]
        public async Task<IActionResult> Postgm_barco([FromBody] gm_barco gm_barco)
        {
            gm_barco nombre =await _context.gm_barcos.Where(s => s.nombre == gm_barco.nombre).FirstOrDefaultAsync();

            if (nombre == null)
            {
                _context.gm_barcos.Add(gm_barco);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_barco", new { id = gm_barco.idBarco }, gm_barco);
            }
            else
                return Ok(new { message = "Nombre repetido" });
        }

        // DELETE: api/gm_barco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegm_barco([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gm_barco = await _context.gm_barcos.FindAsync(id);
            if (gm_barco == null)
            {
                return NotFound();
            }

            _context.gm_barcos.Remove(gm_barco);
            await _context.SaveChangesAsync();

            return Ok(gm_barco);
        }

        private bool gm_barcoExists(int id)
        {
            return _context.gm_barcos.Any(e => e.idBarco == id);
        }
    }
}