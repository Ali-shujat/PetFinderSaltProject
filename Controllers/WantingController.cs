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
    public async Task<ActionResult<WantingListResponse>> GetAllWanting()
    {
        var wantings = await _service.GetAll();
        var WantingsToList = mapper.getAll(wantings);
        return Ok(WantingsToList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        var wanting = await _service.GetOne(id);
        if (wanting == null) return NotFound();
        var response = mapper.makeOne(wanting);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Wanting>> Create(WantingRequest request)
     {
    //     var newCat = new Cat()
    //     {
    //         Name = request.CatName,
    //         Owner = new Person()
    //         {
    //             FirstName = request.OwnerName
    //         }
    //     };
    //     var wanting = new Wanting
    //     {
    //         Cat = newCat,
    //         EventInfo = request.EventInfo,
    //         Latitud = request.Position[0],
    //         Longitud = request.Position[1],
    //     };

    //     _context.Wanting.Add(wanting);
    //     await _context.SaveChangesAsync();
    var wanting = mapper.WantingReqToWanting(request);
    var wantingCreated = await _service.Create(wanting);
        return Ok(mapper.makeOne(wantingCreated));
    }
}