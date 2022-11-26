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
    public class InterventionsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public InterventionsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/Interventions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Intervention>>> Getinterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        // GET: api/Interventions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Intervention>> Get(int id)
        {
            var intervention = await _context.interventions.FindAsync(id);

            if (intervention == null)
            {
                return NotFound();
            }

            return intervention;
        }

        // PUT: api/Interventions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("pending")]
        public async Task<ActionResult<IEnumerable<Intervention>>> GetIntervention()
        {
            return await _context.interventions.Where(e=>(e.intervention_begin == null) && (e.status == "Pending")).ToListAsync();
        }

        [HttpPut("{id}/status/inProgress")]
        public async Task<ActionResult<Intervention>> PutInProgress(int id, string status, DateTime intervention_begin)
        {
            var intervention = await _context.interventions.FindAsync(id);
            DateTime now = DateTime.Now;
            
            if(intervention == null) {
                return NotFound();
            }
            // set a start date and status
            intervention.intervention_begin = now;
            intervention.status = "InProgress";
            _context.SaveChanges();

            return intervention;
        }

        [HttpPut("{id}/status/Completed")]
        public async Task<ActionResult<Intervention>> PutCompleted(int id, string status, DateTime intervention_end)
        {
            var intervention = await _context.interventions.FindAsync(id);
            DateTime now = DateTime.Now;
            
            if(intervention == null) {
                return NotFound();
            }
            // set a start date and status
            intervention.intervention_end = now;
            intervention.status = "Completed";
            _context.SaveChanges();

            return intervention;
        }
    }
}
