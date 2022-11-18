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
    public class ElevatorsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public ElevatorsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/Elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }

        // GET: api/Elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> Get(int id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }

        // PUT: api/Elevators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Elevator>> Put(int id, string elevator_status)
        {
            // if (id != elevator.id)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(elevator).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!ElevatorExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();

            // grab elevator with id id
            var elevator = await _context.elevators.FindAsync(id);
            
            if(elevator == null) {
                return NotFound();
            }
            // change status of battery
            elevator.elevator_status = elevator_status;
            _context.SaveChanges();

            return elevator;
        }

        // POST: api/Elevators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        // {
        //     _context.elevators.Add(elevator);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetElevator", new { id = elevator.id }, elevator);
        // }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
         public void Delete(int id)
        {
        }
        // public async Task<IActionResult> DeleteElevator(int id)
        // {
        //     var elevator = await _context.elevators.FindAsync(id);
        //     if (elevator == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.elevators.Remove(elevator);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // private bool ElevatorExists(int id)
        // {
        //     return _context.elevators.Any(e => e.id == id);
        // }
    }
}
