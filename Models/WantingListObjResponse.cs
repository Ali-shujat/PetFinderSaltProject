namespace PetFinderApi.Models;

public class WantingListObjResponse
{
    public int id { get; set; }
    public string CatName { get; set; } = null!;

    public string EventInfo { get; set; } = null!;

    //public string pictureUri
    public string DetailedUri { get; set; } = null!;
}