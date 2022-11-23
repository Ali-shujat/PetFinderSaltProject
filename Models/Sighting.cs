using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace The_Bright_Side_Test.Models;

public class Sighting
{
    [Key]
    public int Id { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string? EventInfo { get; set; }
    //public int CatId { get; set; }
    //public int PersonId { get; set; }
    
    public virtual Cat Cat { get; set; }

    public virtual Person Informer { get; set; }
}