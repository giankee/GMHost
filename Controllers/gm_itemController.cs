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
    public class gm_itemController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_itemController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_item>>> Getgm_items()
        {
            return await _context.gm_items.OrderBy(x=> x.nombre)
                .Include(a => a.magnitud)
                .Include(d => d.listItem_identidad).ThenInclude(d1 => d1.identidadM)
                .Include(c => c.listItem_itemCategory).ThenInclude(c1 => c1.itemCategory)
                .ToListAsync();
        }

        [Route("getItemTipo/{strParametros}")]
        public async Task<ActionResult<IEnumerable<gm_item>>> getItemTipo(string strParametros)
        {
            string[] parametros = strParametros.Split('@');
            //0.tipo    1.op(obligatorio o opcional)
            var items= await _context.gm_items.Select(x =>
                   new gm_item
                   {
                       idItem = x.idItem,
                       nombre = x.nombre,
                       estado = x.estado,
                       magnitudId=x.magnitudId,
                       magnitud= new gm_magnitud
                       {
                           idMagnitud= x.magnitud.idMagnitud,
                           nombre= x.magnitud.nombre,
                           estado= x.estado,
                           listUnidad = x.magnitud.listUnidad.Select(y =>
                           new gm_unidad
                           {
                               idUnidad= y.idUnidad,
                               nombre = y.nombre,
                               simbolo = y.simbolo,
                               estado = y.estado
                           }).ToList()
                       },
                       listItem_identidad = x.listItem_identidad.Select(y1 =>
                       new gm_item_identidad
                       {
                           idItem_identidad= y1.idItem_identidad,
                           itemId=y1.itemId,
                           identidadMId=y1.identidadMId,
                           opcional=y1.opcional,
                           identidadM = new gm_identidadM
                           {
                               idIdentidadM= y1.identidadM.idIdentidadM,
                               nombre=y1.identidadM.nombre,
                               estado= y1.identidadM.estado
                           },
                       }).Where(y1 => y1.identidadM.nombre == parametros[0] && y1.identidadM.estado == 1 && y1.opcional== bool.Parse(parametros[1])).ToList(),
                       listItem_itemCategory= x.listItem_itemCategory.Select(z =>
                       new gm_item_itemCategory
                       {
                           idItem_itemCategory = z.idItem_itemCategory,
                           itemId = z.itemId,
                           estado = z.estado,
                           itemCategoryId = z.itemCategoryId,
                           itemCategory = new gm_itemCategory
                           {
                               idItemCategory = z.itemCategory.idItemCategory,
                               nombre= z.itemCategory.nombre,
                               estado=z.itemCategory.estado
                           }
                       }).Where(z => z.estado == 1 && z.itemCategory.estado==1).ToList()
                   }).ToListAsync();
            items = items.Where(x => x.listItem_identidad.Count > 0).ToList();
            return items;
        }

        // GET: api/gm_item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_item>> Getgm_item(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gm_item item;
            item = await _context.gm_items
                .Include(a => a.magnitud)
                .Include(d => d.listItem_identidad).ThenInclude(d1 => d1.identidadM)
                .Include(c => c.listItem_itemCategory).ThenInclude(c1 => c1.itemCategory)
                .Where(s => s.idItem == id)
                .FirstOrDefaultAsync();

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/gm_item/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_item(int id, gm_item gm_item)
        {
            _context.Entry(gm_item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_itemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if (gm_item.listItem_itemCategory != null)
                foreach (var datoF in gm_item.listItem_itemCategory)
                {
                    if (datoF.idItem_itemCategory == 0)
                        _context.gm_item_itemCategories.Add(datoF);
                    else
                    {
                        _context.Entry(datoF).State = EntityState.Modified;
                    }
                    await _context.SaveChangesAsync();
                }

            if (gm_item.listItem_identidad != null)
                foreach (var datoI in gm_item.listItem_identidad)
                {
                    if (datoI.idItem_identidad == 0)
                    {
                        _context.gm_item_identidades.Add(datoI);
                    }
                    else
                    {
                        _context.Entry(datoI).State = EntityState.Modified;
                    }
                    _context.SaveChanges();
                }
            return Ok();
        }

        // POST: api/gm_item
        [HttpPost]
        public async Task<ActionResult<gm_item>> Postgm_item(gm_item gm_item)
        {
            gm_item nombre = await _context.gm_items.Where(s => s.nombre == gm_item.nombre).FirstOrDefaultAsync();

            if (nombre == null)
            {
                if (gm_item.idItem == 0)
                {
                    _context.gm_items.Add(gm_item);
                    await _context.SaveChangesAsync();
                }
                /*Tabla de identidad*/
                if (gm_item.listItem_identidad != null) { 
                    foreach (var datoI in gm_item.listItem_identidad)
                    {
                        if (datoI.idItem_identidad == 0)
                        {
                            _context.gm_item_identidades.Add(datoI);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                return CreatedAtAction("Getgm_item", new { id = gm_item.idItem }, gm_item);
            }
            else
                return Ok(new { message = "Nombre repetido" });

        }

        private bool gm_itemExists(int id)
        {
            return _context.gm_items.Any(e => e.idItem == id);
        }
    }
}
