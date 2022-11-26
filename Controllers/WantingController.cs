﻿using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private readonly PetFinderContext _context;
    private readonly IWantingService _dbservice;
    private readonly Mapper mapper = new();

    public WantingController(IWantingService service, PetFinderContext context)
    {
        _dbservice = service;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<WantingListResponse>> GetAllWanting()
    {
        var wantings = await _dbservice.GetAll();
        var WantingsToList = mapper.getAll(wantings);
        return Ok(WantingsToList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        var wanting = await _dbservice.GetOne(id);
        if (wanting == null) return NotFound();
        var response = mapper.makeOne(wanting);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Wanting>> Create(WantingRequest request)
    {
        var wanting = mapper.WantingReqToWanting(request);
        await _dbservice.Create(wanting);
        return CreatedAtAction("GetOneWanting", new { id = wanting.Id }, mapper.makeOne(wanting));
    }
}