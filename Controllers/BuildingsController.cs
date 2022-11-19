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
    public class BuildingsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public BuildingsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/Buildings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> Getbuildings()
        {
            return await _context.buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> Get(int id)
        {
            var building = await _context.buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        [HttpGet("intervention")]
        public async Task<ActionResult<IEnumerable<Building>>> GetIntervention()
        {
            List<Battery> bat = await _context.batteries.ToListAsync();
            List<Column> col = await _context.columns.ToListAsync();
            List<Elevator> elev = await _context.elevators.ToListAsync();
            List<Building> build = await _context.buildings.ToListAsync();
            List<Building> buildingIntervention = new List<Building>();

            foreach(Battery battery in bat){
                if(battery.status == "Intervention"){
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    buildingIntervention.Add(building);
                }
            }
            foreach(Column column in col){
                if(column.status == "Intervention"){
                    var battery = await _context.batteries.FindAsync(column.battery_id);
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    buildingIntervention.Add(building);
                }
            }
            foreach(Elevator elevator in elev){
                if(elevator.elevator_status == "Intervention"){
                    var column = await _context.columns.FindAsync(elevator.column_id);
                    var battery = await _context.batteries.FindAsync(column.battery_id);
                    var building = await _context.buildings.FindAsync(battery.building_id);
                    buildingIntervention.Add(building);
                }
            }

            return buildingIntervention;      
        }

        private bool BuilingExists(int id) 
        {
            return _context.buildings.Any(e => e.id == id);
        }

        // DELETE: api/Buildings/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
