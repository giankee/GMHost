using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebappGM_API.Models;
using WepAppGM.Models;

namespace WebappGM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gm_itemCategoryController : ControllerBase
    {
        private readonly DbGmContext _context;

        public gm_itemCategoryController(DbGmContext context)
        {
            _context = context;
        }

        // GET: api/gm_itemCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<gm_itemCategory>>> Getgm_ItemCategories()
        {
            return await _context.gm_itemCategories.ToListAsync();
        }

        // GET: api/gm_itemCategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<gm_itemCategory>> Getgm_itemCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            gm_itemCategory itemCategory;
            itemCategory = await _context.gm_itemCategories.FindAsync(id);

            if (itemCategory == null)
            {
                return NotFound();
            }

            return Ok(itemCategory);
        }

        // PUT: api/gm_itemCategory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgm_itemCategory(int id, gm_itemCategory gm_itemCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gm_itemCategory.idItemCategory)
            {
                return BadRequest();
            }

            _context.Entry(gm_itemCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gm_itemCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("Getgm_itemCategory", new { id = gm_itemCategory.idItemCategory }, gm_itemCategory);
        }

        // POST: api/gm_itemCategory
        [HttpPost]
        public async Task<ActionResult<gm_itemCategory>> Postgm_itemCategory(gm_itemCategory gm_itemCategory)
        {
            gm_itemCategory nombre = await _context.gm_itemCategories.Where(s => s.nombre == gm_itemCategory.nombre).FirstOrDefaultAsync();
            if (nombre == null)
            {
                _context.gm_itemCategories.Add(gm_itemCategory);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Getgm_itemCategory", new { id = gm_itemCategory.idItemCategory }, gm_itemCategory);
            }
            else
                return Ok(new { message = "Nombre repetido" });
        }

        private bool gm_itemCategoryExists(int id)
        {
            return _context.gm_itemCategories.Any(e => e.idItemCategory == id);
        }
    }
}
