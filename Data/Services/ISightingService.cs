using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public interface ISightingService
{
    Task<List<Sighting>> GetAll();
    Task<Sighting> GetOne(int id);
    Task<Sighting> Create(Sighting sighting);
}