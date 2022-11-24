using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;
using PetFinderApi.Data;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private Mapper mapper = new Mapper();
    private readonly PetFinderContext _context;
    private IWantingService _service;
    public WantingController(IWantingService service, PetFinderContext context)
    {
        _service = service;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wanting>>> GetAllWanting()
    {
        var wantings = await _service.GetAll();
        return Ok(wantings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        var wanting = await _service.GetOne(id);
        if (wanting == null) return NotFound();
        return Ok(wanting);
    }
 
    [HttpPost]
    public async Task<ActionResult<Wanting>> Create(WantingRequest request)
    {
        //var Cat = mapper.WantingReqToCat(request);
        //var Person = mapper.WantingReqToPerson(request);
        //var Wanting = mapper.WantingReqToWanting(request);
        var Wanting = new Wanting 
        {   
            EventInfo = request.EventInfo,
            Cat = new Cat
            {
                Name = request.CatName,
                Owner = new Person
                {
                    FirstName = request.OwnerName,
                    Email = request.Email
                }
            }
        
        };

        if (_context.Wanting == null)
        {
            return Problem("Entity set 'Wanting'  is null.");
        }
        //_context.Cat.Add(Cat);
        _context.Wanting.Add(Wanting);
        await _context.SaveChangesAsync();
        return Ok();
        //return CreatedAtAction("GetCat", new { id = Wanting.Id }, Wanting);
    }
}
