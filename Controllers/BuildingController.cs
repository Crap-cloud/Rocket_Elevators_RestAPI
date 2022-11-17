using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public BuildingController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Building>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuilding()
        {
            return await _context.building.ToListAsync();
        }

        // GET api/Building/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> Get(int id)
        {
            var building = await _context.building.FindAsync(id);
            if (building == null) return NotFound();
            return building;
        }

        // PUT api/building/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Building>> Put(int id, string status)
        {
            // grab buildings with id id
            var building = await _context.building.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }
            // change status of building
            building.status = status;
            _context.SaveChanges();

            return building;
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
