namespace PetFinderApi.Models;

public class SightingResponse
{
    public int id { get; set; }
    public string EventInfo { get; set; } = null!;
    public string? Image { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Breed { get; set; }
    public string? Size { get; set; }
    public string? Eyecolor { get; set; }
    public string? CoatLength { get; set; }
    public string? Gender { get; set; }
    public string? InformerFirstName { get; set; }
    public string? InformerSurname { get; set; }
    public string? InformerPhone { get; set; }
    public string? InformerEmail { get; set; }
}