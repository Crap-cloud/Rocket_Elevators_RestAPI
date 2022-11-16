using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteriesController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public BatteriesController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Batteries>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Battery>>> GetBatteries()
        {
            return await _context.batteries.ToListAsync();
        }

        // GET api/Batteries/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Battery>> Get(int id)
        {
            var battery = await _context.batteries.FindAsync(id);
            if(battery == null) return NotFound();
            return battery;
        }

        // PUT api/batteries/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Battery>> Put(int id, string status)
        {
            // grab battery with id id
            var battery = await _context.batteries.FindAsync(id);
            
            if(battery == null) {
                return NotFound();
            }
            // change status of battery
            battery.status = status;
            _context.SaveChanges();

            return battery;
        }

        // DELETE api/<BatteriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
