using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public ColumnController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Column>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Column>>> GetColumn()
        {
            return await _context.column.ToListAsync();
        }

        // GET api/Column/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Column>> Get(int id)
        {
            var column = await _context.column.FindAsync(id);
            if (column == null) return NotFound();
            return column;
        }

        // PUT api/column/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Column>> Put(int id, string status)
        {
            // grab column with id id
            var column = await _context.column.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }
            // change status of column
            column.status = status;
            _context.SaveChanges();

            return column;
        }

        // DELETE api/<ColumnController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
