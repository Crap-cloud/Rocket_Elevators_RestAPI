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
    public class InterventionsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public InterventionsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET api/Interventions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> Get(int id)
        {
            var intervention = await _context.interventions.FindAsync(id);
            if (intervention == null) return NotFound();
            return intervention;
        }

        // PUT api/intervention/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Intervention>> Put(int id, string Status)
        {
            // grab intervention with id id
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }
            // change status of intervention
            intervention.Status = Status;
            _context.SaveChanges();

            return intervention;
        }

        // DELETE api/<InterventionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
