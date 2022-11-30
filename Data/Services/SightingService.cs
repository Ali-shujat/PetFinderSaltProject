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
        var sightings = await _context.Sighting
            .Include(s => s.Cat)
            .ThenInclude(c => c.Owner)
            .ToListAsync();
        if (sightings == null) return new List<Sighting>();
        return sightings;
    }

    public async Task<Sighting>? GetOne(int id)
    {
        if (await _context.Sighting.ToListAsync() == null) return null;

        return await _context.Sighting
            .Where(s => s.Id == id)
            .Include(s => s.Cat)
            .ThenInclude(c => c.Owner)
            .FirstOrDefaultAsync();
    }

    public async Task<Sighting> Create(Sighting sighting)
    {
        await _context.Sighting.AddAsync(sighting);
        await _context.SaveChangesAsync();
        return sighting;
    }
}