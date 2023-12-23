using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INTUSManagement.API.Data;
using INTUSManagement.Model;

namespace INTUSManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly INTUSManagementAPIContext _context;

        public ElementsController(INTUSManagementAPIContext context)
        {
            _context = context;
        }

        // GET: api/Elements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Element>>> GetElement()
        {
            if (_context.Element == null)
            {
                return NotFound();
            }
            return await _context.Element.ToListAsync();
        }

        // GET: api/Elements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            if (_context.Element == null)
            {
                return NotFound();
            }
            var element = await _context.Element.FindAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }

        // PUT: api/Elements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElement(int id, Element element)
        {
            if (id != element.ElementId)
            {
                return BadRequest();
            }

            _context.Entry(element).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExists(id))
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

        // POST: api/Elements
        [HttpPost]
        public async Task<ActionResult<Element>> PostElement(Element element)
        {
            if (_context.Element == null)
            {
                return Problem("Entity set 'INTUSManagementAPIContext.Element'  is null.");
            }
            _context.Element.Add(element);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElement", new { id = element.ElementId }, element);
        }

        // DELETE: api/Elements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement(int id)
        {
            if (_context.Element == null)
            {
                return NotFound();
            }
            var element = await _context.Element.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            _context.Element.Remove(element);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementExists(int id)
        {
            return (_context.Element?.Any(e => e.ElementId == id)).GetValueOrDefault();
        }
    }
}
