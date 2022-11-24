using PetFinderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PetFinderApi.Data.Services;

public class WantingRepo : IWantingService
{
    private readonly PetFinderContext _context;
    public WantingRepo(PetFinderContext Context) => _context = Context;
    public async Task<List<Wanting>> GetAll()
    {
        var wantings = await _context.Wanting.ToListAsync();
        if(wantings == null) return new List<Wanting>();
        return wantings;
    }
    public async Task<Wanting> GetOne(int id)
    {
        if (await _context.Wanting.ToListAsync() == null) return null;
        var wanting = await _context.Wanting.FindAsync(id);
        return wanting;
    }
    public Wanting Create(string eventInfo, Cat cat, Person person, double[] position)
    {
        return null;
    }
}