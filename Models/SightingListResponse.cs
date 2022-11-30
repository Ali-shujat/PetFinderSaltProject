namespace PetFinderApi.Models;

public class SightingListResponse
{
    public List<SightingListObjResponse> Sightings { get; set; } = null!;
    public string? Next { get; set; }
    public string? Previous { get; set; }
}