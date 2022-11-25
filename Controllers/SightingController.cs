using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;
using PetFinderApi.Data;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SightingController : ControllerBase
{
    private readonly PetFinderContext _context;
    private ISightingService _service;
    public SightingController(ISightingService service, PetFinderContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sighting>>> GetAllSighting()
    {
        var sightings = await _service.GetAll();
        return Ok(sightings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sighting>> GetOneSighting(int id)
    {
        var sighting = await _service.GetOne(id);
        if (sighting == null) return NotFound();
        return Ok(sighting);
    }

    [HttpPost]
    public async Task<ActionResult<Sighting>> Create(SightingRequest request)
    {
        var sighting = new Sighting
        {
            Cat = new Cat
            {
                AdditionalInfo = request.CatDescription,
                Owner = new Person
                {
                    FirstName = request.InformerName,
                    Email = request.Email
                }
            },
            EventInfo = request.EventInfo,
            Latitud = request.Position[0],
            Longitud = request.Position[1],
        };

        if (_context.Sighting == null)
        {
            return Problem("Entity set 'Sighting' is null.");
        }
        _context.Sighting.Add(sighting);
        await _context.SaveChangesAsync();
        return CreatedAtAction("Create", new { id = sighting.Id }, sighting);
    }
}
