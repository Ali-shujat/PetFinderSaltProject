﻿using Microsoft.AspNetCore.Mvc;
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
        //make wantingresponselist
        return Ok(wantings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        var wanting = await _service.GetOne(id);
        if (wanting == null) return NotFound();
        //make wantingresponse
        return Ok(wanting);
    }
 
    [HttpPost]
    public async Task<ActionResult<Wanting>> Create(WantingRequest request)
    {
       // var wanting = mapper.WantingReqToWanting(request);
        var wanting = new Wanting
        {
            Cat = new Cat
            {
                Name = request.CatName,
                Owner = new Person
                {
                    FirstName = request.OwnerName
                }
            },
            EventInfo = request.EventInfo,
            Latitud = request.Position[0],
            Longitud = request.Position[1],
        };
        var person = new Person {FirstName = request.OwnerName};
        _context.Person.Add(person);
      //   _context.Wanting.Add(wanting);
        await _context.SaveChangesAsync();
        return wanting;

        // var made = await _service.Create(wanting);
        // return Ok(made.Id);
        // return CreatedAtAction("GetOneWanting", made.Id, made);
    }
}