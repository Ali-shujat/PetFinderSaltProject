using PetFinderApi.Models;
namespace PetFinderApi.Models;

public class WantingListObjResponse
{
    public int id { get; set; }
    public string PictureUrl { get; set; } = null!;
    public string EventInfo { get; set; } = null!;
    public double[] Location { get; set; }
    public string Contactinformation { get; set; } = null!;
    public string DetailedUri { get; set; } = null!;
    public string? CatName { get; set; } = null!;

    public WantingListObjResponse()
    {
        
    }
}