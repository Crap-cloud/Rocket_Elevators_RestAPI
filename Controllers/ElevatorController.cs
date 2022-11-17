using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public ElevatorController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Elevator>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> GetElevator()
        {
            return await _context.elevator.ToListAsync();
        }

        // GET api/Elevator/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> Get(int id)
        {
            var elevator = await _context.elevator.FindAsync(id);
            if (elevator == null) return NotFound();
            return elevator;
        }

        // PUT api/elevator/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Elevator>> Put(int id, string status)
        {
            // grab elevator with id id
            var elevator = await _context.elevator.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }
            // change status of elevator
            elevator.status = status;
            _context.SaveChanges();

            return elevator;
        }

        // DELETE api/<ElevatorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
