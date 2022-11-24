using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetFinderApi.Models;

public class Sighting
{
    [Key]
    public int Id { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string? EventInfo { get; set; }
    public virtual Cat Cat { get; set; }
}