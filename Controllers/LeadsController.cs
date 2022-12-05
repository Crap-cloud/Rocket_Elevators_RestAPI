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
    public class LeadsController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public LeadsController(RocketElevatorsContext context)
        {
            _context = context;
        }
        //GET: api/Leads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> Getleads()
        {
            return await _context.leads.ToListAsync();
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> Get(int id)
        {
            var lead = await _context.leads.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return lead;
        }

        [HttpGet("pastdays")]
        public async Task<IActionResult> GetLeads()
        // public String GetLeads()
        {
            DateTime days = DateTime.Now.AddDays(-30);
            DateTime today = DateTime.Now;

            bool bol = true;
            var customer = await _context.customers.ToListAsync();
            List<string> customerEmail = new List<string>();
            for( int i = 0 ; i <customer.Count; i++ )
            {
                customerEmail.Add(customer[i].EmailCompanyContact);
            }
            var lead = _context.leads.Where(l =>  (bol != customerEmail.Contains(l.contactEmail)) && (today - l.created_at < today - days));
            if (lead == null)
            {
                return NotFound();
            }
            return Ok(lead);
        }
    }
}
