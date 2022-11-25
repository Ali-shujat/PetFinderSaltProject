using PetFinderApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PetFinderApi.Data.Services;

public class WantingService : IWantingService
{
    private readonly PetFinderContext _context;
    public WantingService(PetFinderContext Context) => _context = Context;
    public async Task<List<Wanting>> GetAll()
    {
        var wantings = await  _context.Wanting
            .Include(w => w.Cat)
            .Include(w => w.Cat.Owner)
            .ToListAsync();
        if(wantings == null) return new List<Wanting>();
        return wantings;
    }
    public async Task<Wanting>? GetOne(int id)
    {
        if (await _context.Wanting.ToListAsync() == null) return null;
        //var wanting = await _context.Wanting.FindAsync(id);
        return await _context.Wanting
            .Where(w => w.Id == id)
            .Include(w => w.Cat)
            .Include(w => w.Cat.Owner)
            .FirstOrDefaultAsync();
    }
    public async Task<Wanting> Create(Wanting wanting)
    {
        await _context.Wanting.AddAsync(wanting);
        await _context.SaveChangesAsync();
        return wanting;
    }
}