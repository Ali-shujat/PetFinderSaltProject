using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data;
using PetFinderApi.Models;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private Mapper mapper = new Mapper();
    private readonly PetFinderContext _context;
    private IWantingRepo _repo;
    public WantingController(IWantingRepo repo, PetFinderContext context)
    {
        _repo = repo;
        _context = context;

    }

    // GET: api/Cats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wanting>>> GetAllWanting()
    {
        if (_context.Wanting == null)
        {
            return NotFound();
        }
        return await _context.Wanting.ToListAsync();
    }

    // GET: api/Cats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        if (_context.Cat == null)
        {
            return NotFound();
        }
        var wanting = await _context.Wanting.FindAsync(id);

        if (wanting == null)
        {
            return NotFound();
        }

        return wanting;
    }
        /*
        [HttpPost]
        public ActionResult Create(WantingRequest request)
        {
            var Cat = mapper.WantingReqToCat(request);
            var Person = mapper.WantingReqToPerson(request);
            var Created = _repo.Create(request.EventInfo, Cat, Person, request.Position);
            return Ok();
        }
    */
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
