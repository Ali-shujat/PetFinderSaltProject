using PetFinderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PetFinderApi.Data.Services;

public class SightingRepo : ISightingService
{
    private readonly PetFinderContext _context;
    public SightingRepo(PetFinderContext Context) => _context = Context;
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
    public Sighting Create(Sighting sighting)
    {
        _context.Sighting.Add(sighting);
        _context.SaveChanges();
        return sighting;
    }
}