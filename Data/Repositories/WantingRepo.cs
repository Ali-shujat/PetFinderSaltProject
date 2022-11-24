using PetFinderApi.Models;

namespace PetFinderApi.Data;

public class WantingRepo : IWantingRepo
{
    private readonly PetFinderContext _context;
    public WantingRepo(PetFinderContext Context) => _context = Context;
    public List<Wanting> GetAll()
    {
        if(_context.Wanting == null);
        return null;
    }
    public Wanting GetOne(int id)
    {
        return null;
    }
    public Wanting Create(string eventInfo, Cat cat, Person person, double[] position)
    {
        return null;
    }
}