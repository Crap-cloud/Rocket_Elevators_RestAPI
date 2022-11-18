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
        //gives building address
        // [HttpGet("/buildingaddress/{id}")]// customer id
        // public IActionResult GetCustomerBuildingAddress(long id)
        // {
        //     var customerBuildings = _context.Buildings.Where(b => b.CustomerId == id);
        //     List<string> customerBuildingAddress = new List<string>();
        //     foreach (var item in customerBuildings)
        //     {
        //         customerBuildingAddress.Add(item.AddressOfBuilding);
        //     }
        //     return Ok(customerBuildingAddress);
        // }
    }
    //     [Route("api/[controller]")]
    //     [ApiController]
    //     public class CustomersController : ControllerBase
    //     {
    //         private readonly RocketElevatorsContext _context;

    //         public CustomersController(RocketElevatorsContext context)
    //         {
    //             _context = context;
    //         }

    //         // GET: api/Customers
    //         [HttpGet]
    //         public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
    //         {
    //             return await _context.customers.ToListAsync();
    //         }

    //         // GET: api/Customers/5
    //         [HttpGet("{id}")]
    //         public async Task<ActionResult<Customer>> Get(int id)
    //         {
    //             var customer = await _context.customers.ToListAsync();

    //             if (customer == null)
    //             {
    //                 return NotFound();
    //             }

    //             return Ok(customer);
    //         }

    //         // PUT: api/Customers/5
    //         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //         [HttpPut("/customer/{email}")]
    //         public Task<ActionResult<Customer>> Put(int id, string EmailCompanyContact)
    //         {
    //             var customer = _context.customers.Where(c => c.EmailCompanyContact == EmailCompanyContact);
    //             return Ok(customer);
    //         }

    //         // DELETE: api/Customers/5
    //         [HttpDelete("{id}")]
    //         public void Delete(int id)
    //         {
    //         }
    //     }
    // }
}
