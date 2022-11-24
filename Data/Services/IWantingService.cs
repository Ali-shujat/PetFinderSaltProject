using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public interface IWantingService 
{
    Task<List<Wanting>> GetAll();
    Task<Wanting> GetOne(int id);
    Wanting Create(string eventInfo, Cat cat, Person person, double[] position);    
}