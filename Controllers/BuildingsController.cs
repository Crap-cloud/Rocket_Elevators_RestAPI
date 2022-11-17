using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public BuildingsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Buildings>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Buildings>>> GetBuildings()
        {
            return await _context.buildings.ToListAsync();
        }

        // GET api/Buildings/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Buildings>> Get(int id)
        {
            var building = await _context.buildings.FindAsync(id);
            if (building == null) return NotFound();
            return building;
        }

        // PUT api/buildings/id/status/status
        //[HttpPut("{id}/status/{status}")]
       // public async Task<ActionResult<Buildings>> Put(int id, string status)
        //{
            // grab buildings with id id
           // var building = await _context.buildings.FindAsync(id);

            //if (building == null)
            //{
            //    return NotFound();
            //}
            // change status of buildings
           // building.status = status;
           // _context.SaveChanges();

           // return building;
       // }

        // DELETE api/<BuildingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
