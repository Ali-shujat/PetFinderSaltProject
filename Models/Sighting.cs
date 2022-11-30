namespace PetFinderApi.Models;

public class Sighting
{
    public int Id { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string? EventInfo { get; set; }
    public virtual Cat Cat { get; set; }
    
    public string? imageFileName { get; set; }
}