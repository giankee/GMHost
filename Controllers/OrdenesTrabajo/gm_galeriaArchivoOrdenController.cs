using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppGM.Models;
using WebappGM_API.Models.OrdenesTrabajoB;
using WepAppGM.Models;

namespace WebappGM_API.Controllers.OrdenesTrabajo
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_galeriaArchivoOrdenController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_galeriaArchivoOrdenController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_galeriaArchivoOrden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_galeriaArchivoOrden>>> Getgm_galeriaArchivoOrdenes()
        {
            return await _context.gm_galeriaArchivoOrdenes.ToListAsync();
        }

        // GET: api/gm_galeriaArchivoOrden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Getgm_galeriaArchivoOrden(int id)
        {
            var gm_galeriaArchivoOrden = await _context.gm_galeriaArchivoOrdenes.FindAsync(id);

            if (gm_galeriaArchivoOrden == null)
            {
                return NotFound();
            }

            return gm_galeriaArchivoOrden;
        }

        // PUT: api/gm_galeriaArchivoOrden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_galeriaArchivoOrden(int id, gm_galeriaArchivoOrden gm_galeriaArchivoOrden)
        {
            if (id != gm_galeriaArchivoOrden.idArchivo)
            {
                return BadRequest();
            }

            _context.Entry(gm_galeriaArchivoOrden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_galeriaArchivoOrdenExists(id))
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

        // POST: api/gm_galeriaArchivoOrden
        [HttpPost]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Postgm_galeriaArchivoOrden(gm_galeriaArchivoOrden[] gm_galeriaArchivoOrden)
        {
            string raiz = "c:/HostServerGM/Ang";
            string filedir;
            
            gm_ordenTrabajoB selectOrden;
            selectOrden = _context.gm_ordenTrabajosB.Select(x =>
                new gm_ordenTrabajoB
                {
                    idOrdenT = x.idOrdenT,
                    barcoMaquinariaId = x.barcoMaquinariaId,
                    barcoMaquinaria = new gm_barco_maquinaria
                    {
                        idBarcoMaquinaria = x.barcoMaquinaria.idBarcoMaquinaria,
                        barcoId = x.barcoMaquinaria.barcoId,
                        nombre = x.barcoMaquinaria.nombre,
                        barco = new gm_barco
                        {
                            nombre = x.barcoMaquinaria.barco.nombre,
                        }
                    }
                }).Where(x => x.idOrdenT == gm_galeriaArchivoOrden[0].ordenTrabajoId).FirstOrDefault();

            if (selectOrden.barcoMaquinaria.barco.nombre.Contains("/"))
            {
                filedir = "/assets/img/" + selectOrden.barcoMaquinaria.barco.nombre.Replace("/", "") + "/";
            }
            else filedir = "/assets/img/" + selectOrden.barcoMaquinaria.barco.nombre + "/";

            if (selectOrden.barcoMaquinaria.nombre.Contains("/"))
            {
                filedir = filedir + selectOrden.barcoMaquinaria.nombre.Replace("/", "") + "/";
            }else
            filedir = filedir+ selectOrden.barcoMaquinaria.nombre + "/";

            string rutaCompleta = raiz + filedir;
            if (!Directory.Exists(rutaCompleta))
            { //check if the folder exists;
                Directory.CreateDirectory(rutaCompleta);
            }
            var fileName = "";
            foreach (var datoG in gm_galeriaArchivoOrden)
            {
                var bytes = Convert.FromBase64String(datoG.rutaArchivo);
                var extencion = datoG.tipoArchivo.Split("/");

                if (datoG.nombreArchivo.Contains("/"))
                {
                    fileName = "GO" + selectOrden.idOrdenT + "_" + datoG.nombreArchivo.Replace("/", "") + "." + extencion[1];
                }
                else fileName = "GO" + selectOrden.idOrdenT+"_" + datoG.nombreArchivo + "." + extencion[1];

                string file = Path.Combine(rutaCompleta, fileName);
                datoG.rutaArchivo = filedir + fileName;
                if (bytes.Length > 0)
                {
                    using (var stream = new FileStream(file, FileMode.Create))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Flush();
                    }
                }
                _context.gm_galeriaArchivoOrdenes.Add(datoG);
                await _context.SaveChangesAsync();
            }
            return Ok(new { message = "Ok" });
        }

        [HttpPost]
        [Route("Delate")]//tengo q hacer la copia de galeria que hice en barcos pilas mañana crack
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Postgm_galeriaArchivoOrdenDelate(gm_galeriaArchivoOrden[] gm_galeriaArchivoOrden)
        {
            string raiz = "c:/HostServerGM/Ang";
            string filedir;

            gm_ordenTrabajoB selectOrden;
            selectOrden = _context.gm_ordenTrabajosB.Select(x =>
                new gm_ordenTrabajoB
                {
                    idOrdenT = x.idOrdenT,
                    barcoMaquinariaId = x.barcoMaquinariaId,
                    barcoMaquinaria = new gm_barco_maquinaria
                    {
                        idBarcoMaquinaria = x.barcoMaquinaria.idBarcoMaquinaria,
                        barcoId = x.barcoMaquinaria.barcoId,
                        nombre = x.barcoMaquinaria.nombre,
                        barco = new gm_barco
                        {
                            nombre = x.barcoMaquinaria.barco.nombre,
                        }
                    }
                }).Where(x => x.idOrdenT == gm_galeriaArchivoOrden[0].ordenTrabajoId).FirstOrDefault();

            if (selectOrden.barcoMaquinaria.barco.nombre.Contains("/"))
            {
                filedir = "/assets/img/" + selectOrden.barcoMaquinaria.barco.nombre.Replace("/", "") + "/";
            }
            else filedir = "/assets/img/" + selectOrden.barcoMaquinaria.barco.nombre + "/";

            if (selectOrden.barcoMaquinaria.nombre.Contains("/"))
            {
                filedir = filedir + selectOrden.barcoMaquinaria.nombre.Replace("/", "") + "/";
            }
            else
                filedir = filedir + selectOrden.barcoMaquinaria.nombre + "/";

            string rutaCompleta = raiz + filedir;
            String[] archivos = null;
            if (Directory.Exists(rutaCompleta))
            { //check if the folder exists;
                archivos = Directory.GetFiles(rutaCompleta);
            }

            gm_galeriaArchivoOrden auxGaleria;

            foreach (var datoG in gm_galeriaArchivoOrden)
            {
                auxGaleria = await _context.gm_galeriaArchivoOrdenes
                .Where(s => s.idArchivo == datoG.idArchivo).FirstOrDefaultAsync();
                if (auxGaleria != null)
                {
                    if (archivos != null)
                    {
                        foreach (string datoA in archivos)
                        {
                            if (datoA.Contains(auxGaleria.rutaArchivo))
                            {
                                System.IO.File.Delete(datoA);
                            }
                        }
                    }
                    _context.gm_galeriaArchivoOrdenes.Remove(auxGaleria);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { message = "Ok" });
        }

        // DELETE: api/gm_galeriaArchivoOrden/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<gm_galeriaArchivoOrden>> Deletegm_galeriaArchivoOrden(int id)
        {
            var gm_galeriaArchivoOrden = await _context.gm_galeriaArchivoOrdenes.FindAsync(id);
            if (gm_galeriaArchivoOrden == null)
            {
                return NotFound();
            }

            _context.gm_galeriaArchivoOrdenes.Remove(gm_galeriaArchivoOrden);
            await _context.SaveChangesAsync();

            return gm_galeriaArchivoOrden;
        }

        private bool gm_galeriaArchivoOrdenExists(int id)
        {
            return _context.gm_galeriaArchivoOrdenes.Any(e => e.idArchivo == id);
        }
    }
}
