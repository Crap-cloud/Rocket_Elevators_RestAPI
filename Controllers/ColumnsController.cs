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

        // GET: api/<Columns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Columns>>> GetColumns()
        {
            return await _context.columns.ToListAsync();
        }

        // GET api/Columns/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Columns>> Get(int id)
        {
            var column = await _context.columns.FindAsync(id);
            if (column == null) return NotFound();
            return column;
        }

        // PUT api/columns/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Columns>> Put(int id, string status)
        {
            // grab columns with id id
            var column = await _context.columns.FindAsync(id);

            if (column == null)
            {
                return NotFound();
            }
            // change status of columns
            column.status = status;
            _context.SaveChanges();

            return column;
        }

        // DELETE api/<ColumnsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
