#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public ColumnsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/Columns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumns()
        {
            return await _context.columns.ToListAsync();
        }

        // GET: api/Columns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> Get(int id)
        {
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }

            return column;
        }

        // PUT: api/Columns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Column>> Put(int id, string status)
        {
            // if (id != column.id)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(column).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!ColumnExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();

            // grab column with id id
            var column = await _context.columns.FindAsync(id);
            
            if(column == null) {
                return NotFound();
            }
            // change status of battery
            column.status = status;
            _context.SaveChanges();

            return column;

        }

        // POST: api/Columns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Column>> PostColumn(Column column)
        // {
        //     _context.columns.Add(column);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetColumn", new { id = column.id }, column);
        // }

        // DELETE: api/Columns/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // public async Task<IActionResult> DeleteColumn(int id)
        // {
        //     var column = await _context.columns.FindAsync(id);
        //     if (column == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.columns.Remove(column);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ColumnExists(int id)
        // {
        //     return _context.columns.Any(e => e.id == id);
        // }
    }
}
