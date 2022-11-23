using PetFinderApi.Data.Entities;

namespace PetFinderApi.Data;

public class WantingRepo : IWantingRepo
{
    //private readonly WantingContext _context;
    //public WantingRepo(WantingContext Context) => _context = Context;
    public List<Wanting> GetAll()
    {
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