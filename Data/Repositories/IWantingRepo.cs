using PetFinderApi.Models;

namespace PetFinderApi.Data;

public interface IWantingRepo 
{
    List<Wanting> GetAll();
    Wanting GetOne(int id);
    Wanting Create(string eventInfo, Cat cat, Person person, double[] position);    
}