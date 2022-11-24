using PetFinderApi.Data.Entities;

namespace PetFinderApi.Data;

public interface IWantingRepo 
{
    List<Wanting> GetAll();
    Wanting GetOne(int id);
    Wanting Create(string eventInfo, Cat cat, Person person, double[] position);    
}