
using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public class Mapper
{
    public Cat WantingReqToCat(WantingRequest request)
    {
        return new Cat
        {
            Name = request.CatName, 
            Owner = new Person {
                FirstName = request.OwnerName,
                Email = request.Email
            }           
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
        var CreateCat = WantingReqToCat(request);
        return new Wanting
        {
            Cat = CreateCat,
            EventInfo = request.EventInfo,
            Latitud =request.Position[0],
            Longitud = request.Position[1],
        };
    }
}