using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevators_Rest_API.Models;

namespace Rocket_Elevators_Rest_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public LeadsController(RocketElevatorsContext context)
        {
            _context = context;
        }

        // GET: api/<Leads>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            return await _context.leads.ToListAsync();
        }

        // GET api/Leads/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> Get(int id)
        {
            var leads = await _context.leads.FindAsync(id);
            if (leads == null) return NotFound();
            return leads;
        }

        // PUT api/leads/id/status/status
        [HttpPut("{id}/status/{status}")]
        public async Task<ActionResult<Lead>> Put(int id, string status)
        {
            // grab leads with id id
            var leads = await _context.leads.FindAsync(id);

            if (leads == null)
            {
                return NotFound();
            }
            // change status of leads
            leads.status = status;
            _context.SaveChanges();

            return leads;
        }

        // DELETE api/<LeadsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
