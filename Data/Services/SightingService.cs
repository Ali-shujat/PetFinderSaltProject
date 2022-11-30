using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public class SightingRepo : ISightingService
{
    private readonly PetFinderContext _context;

    public SightingRepo(PetFinderContext Context)
    {
        _context = Context;
    }

    public async Task<List<Sighting>> GetAll()
    {
        var sightings = await _context.Sighting.ToListAsync();
        if (sightings == null) return new List<Sighting>();
        return sightings;
    }

    public async Task<Sighting> GetOne(int id)
    {
        if (await _context.Sighting.ToListAsync() == null) return null;
        var sighting = await _context.Sighting.FindAsync(id);
        return sighting;
    }

    public async Task<Sighting> Create(Sighting sighting)
    {
        await _context.Sighting.AddAsync(sighting);
        await _context.SaveChangesAsync();
        return sighting;
    }
}