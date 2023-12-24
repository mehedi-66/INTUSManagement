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
    public class OrdersController : ControllerBase
    {
        private readonly INTUSManagementAPIContext _context;

        public OrdersController(INTUSManagementAPIContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrder()
        {
            try
            {
                List<Order> orders = _context.Orders.ToList();

                if (orders == null || !orders.Any())
                {
                    return NotFound();
                }

                foreach (var ord in orders)
                {
                    List<Window> windows = (from win in _context.Windows
                                            where win.OrderId == ord.OrderId
                                            select new Window
                                            {
                                                WindowId = win.WindowId,
                                                Name  = win.Name,
                                                QuantityOfWindows = win.QuantityOfWindows,
                                                TotalSubElements = win.TotalSubElements,

                                                SubElements = _context.SubElements
                                                    .Where(sub => sub.WindowId == win.WindowId)
                                                    .ToList()

                                            }).ToList();

                    ord.Windows = windows;
                }

                return orders;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            try
            {
                if (_context.Orders == null)
                {
                    return BadRequest("Entity set 'INTUSManagementAPIContext.Orders' is null.");
                }

               

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                var windows = order.Windows.ToList();

                foreach (var win in windows)
                {
                    Window obj = new Window
                    {
                        Name = win.Name,
                        QuantityOfWindows = win.QuantityOfWindows,
                        TotalSubElements = win.TotalSubElements,
                        OrderId = order.OrderId
                    };

                    _context.Windows.Add(obj);
                    await _context.SaveChangesAsync();

                    var subElements = win.SubElements.ToList();

                    foreach (var subE in subElements)
                    {
                        SubElement subObj = new SubElement
                        {
                            Type = subE.Type,
                            Width = subE.Width,
                            Height = subE.Height,
                            WindowId = obj.WindowId
                        };

                        _context.SubElements.Add(subObj);
                        await _context.SaveChangesAsync();
                    }
                }

                return Ok(order);
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                return BadRequest($"An error occurred: {e.Message}");
            }
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
