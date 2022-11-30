using PetFinderApi.Models;

namespace PetFinderApi.Data.Services;

public class Mapper
{
    public Cat WantingReqToCat(WantingRequest request)
    {
        return new Cat
        {
            Name = request.CatName,
            Owner = new Person
            {
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
        var wanting = new Wanting
        {
            Cat = new Cat
            {
                Name = request.CatName,
                Owner = new Person
                {
                    FirstName = request.OwnerName
                }
            },
            EventInfo = request.Description
        };
        if (request.Position != null && request.Position.Length == 2)
        {
            wanting.Latitud = request.Position[0];
            wanting.Longitud = request.Position[1];
        }

        return wanting;
    }

    public WantingListResponse getAll(List<Wanting> wantings)
    {
        var fileService = new FileService();
        var mappedList = wantings
            .Select(w => new WantingListObjResponse
            {
                id = w.Id,
                    Location = new double[] { w.Latitud, w.Longitud },
                EventInfo = w.EventInfo!,
                Contactinformation = w.Cat.Owner.Email,
                DetailedUri = "https://petfinderapi.azurewebsites.net/api/Wanting/" + w.Id.ToString(),
                PictureUrl = fileService.getPath(w.imageFileName),
            }).ToList();
        return new WantingListResponse
        {
            Wantings = mappedList
        };
    }

    public WantingResponse makeOne(Wanting wanting)
    {
        return new WantingResponse
        {
            Description = wanting.EventInfo!,
            CatName = wanting.Cat.Name!,
            Image = wanting.Cat.Image,
            AdditionalInfo = wanting.Cat.AdditionalInfo,
            Breed = wanting.Cat.Breed,
            Size = wanting.Cat.Size,
            Eyecolor = wanting.Cat.Eyecolor,
            CoatLength = wanting.Cat.CoatLength,
            OwnerFirstName = wanting.Cat.Owner!.FirstName,
            OwnerSurname = wanting.Cat.Owner.Surname,
            OwnerEmail = wanting.Cat.Owner.Email,
            OwnerPhone = wanting.Cat.Owner.Phone
        };
    }
}