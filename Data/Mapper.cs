
using PetFinderApi.Data.Entities;
using PetFinderApi.Data.ViewModels;

namespace PetFinderApi.Data;

public class Mapper
{
    public Cat WantingReqToCat(WantingRequest request)
    {
        return new Cat
        {
            Name = request.CatName,            
        };        
    }
    public Person WantingReqToPerson(WantingRequest request)
    {
        return new Person
        {
            FirstName = request.OwnerName,
            Email = request.Email
        };
    }
    public Wanting WantingReqToWanting(WantingRequest request)
    {
        var CreatePerson = WantingReqToPerson(request);
        var CreateCat = WantingReqToCat(request);
        //TODO: add owner
        return new Wanting
        {
            Cat = CreateCat,
            EventInfo = request.EventInfo,
            Latitud =request.Position[0],
            Longitud = request.Position[1],
        };
    }
}