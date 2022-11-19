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
    public class CustomerController : ControllerBase
    {
        private readonly RocketElevatorsContext _context;

        public CustomerController(RocketElevatorsContext context) => _context = context;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _context.customers.ToListAsync();
            return Ok(customers);
        }
        
        [HttpGet("/customerobj/{email}")]
        public IActionResult GetCustomerObject(string EmailCompanyContact)
        {
            var customer = _context.customers.Where(c => c.EmailCompanyContact == EmailCompanyContact);
            return Ok(customer);
        }
    }
}
