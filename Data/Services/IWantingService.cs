using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public interface IWantingService 
{
    Task<List<Wanting>> GetAll();
    Task<Wanting>? GetOne(int id);
    Task<Wanting> Create(Wanting wanting);   
}