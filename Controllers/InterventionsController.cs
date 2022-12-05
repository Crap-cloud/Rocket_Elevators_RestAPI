using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketApi.Models;

namespace InterventionApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class InterventionController : ControllerBase
{
    private readonly RocketElevatorContext _context;

    public InterventionController(RocketElevatorContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventionItems()
    {
        return await _context.interventions.ToListAsync();
    }

    private IActionResult View()
    {
        throw new NotImplementedException();
    }

    // GET: api/Elevator/5
    [HttpGet("status")]
    public async Task<ActionResult<IEnumerable<Intervention>>> GetInterventionStat()
    {
        return await _context.interventions.Where(e => (e.Status == "Pending")).ToListAsync();
        {

        };
    }

    [HttpPut("{id}/InProgress")]
    public async Task<ActionResult<Intervention>> UpdateInterventionStatus([FromRoute] int id)
    {
        var Intervention = await this._context.interventions.FindAsync(id);

        if (Intervention == null)
        {
            return NotFound();
        }

        String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
        String timeStamp = GetTimestamp(DateTime.Now);


        Intervention.Status = "InProgress";
        Intervention.StartDate = timeStamp;

        this._context.interventions.Update(Intervention);
        await this._context.SaveChangesAsync();
        return Intervention;
    }

    [HttpPut("{id}/Completed")]
    public async Task<ActionResult<Intervention>> UpdateInterventionEndDate([FromRoute] int id)
    {
        var InterventionEnd = await this._context.interventions.FindAsync(id);

        if (InterventionEnd == null)
        {
            return NotFound();
        }

        String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
        String timeStamp = GetTimestamp(DateTime.Now);


        InterventionEnd.Status = "Completed";
        InterventionEnd.EndDate = timeStamp;

        this._context.interventions.Update(InterventionEnd);
        await this._context.SaveChangesAsync();
        return InterventionEnd;
    }
}