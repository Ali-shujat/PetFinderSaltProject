namespace PetFinderApi.Models;

public class WantingListResponse
{
    public List<WantingListObjResponse> Wantings { get; set; } = null!;
    public string? Next { get; set; }
    public string? Previous { get; set; }
}