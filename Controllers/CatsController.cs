﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data;
using PetFinderApi.Models;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CatsController : ControllerBase
{
    private readonly PetFinderContext _context;

    public CatsController(PetFinderContext context)
    {
        _context = context;
    }

    // GET: api/Cats
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cat>>> GetCat()
    {
        if (_context.Cat == null) return NotFound();
        return await _context.Cat.Include(c => c.Owner).ToListAsync();
    }

    // GET: api/Cats/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cat>> GetCat(int id)
    {
        if (_context.Cat == null) return NotFound();
        var cat = await _context.Cat.FindAsync(id);

        if (cat == null) return NotFound();

        return cat;
    }

    // PUT: api/Cats/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCat(int id, Cat cat)
    {
        if (id != cat.Id) return BadRequest();

        _context.Entry(cat).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CatExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    // POST: api/Cats
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Cat>> PostCat(Cat cat)
    {
        if (_context.Cat == null) return Problem("Entity set 'testingContext.Cat'  is null.");
        _context.Cat.Add(cat);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCat", new { id = cat.Id }, cat);
    }

    // DELETE: api/Cats/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCat(int id)
    {
        if (_context.Cat == null) return NotFound();
        var cat = await _context.Cat.FindAsync(id);
        if (cat == null) return NotFound();

        _context.Cat.Remove(cat);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CatExists(int id)
    {
        return (_context.Cat?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}