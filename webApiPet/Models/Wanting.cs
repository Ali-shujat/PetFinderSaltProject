using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetFinderApi.Data.Entities;

public class Wanting
{
    [Key]
    public int Id { get; set; }
    public double Latitud { get; set; }
    public double Longitud { get; set; }
    public string? EventInfo { get; set; }
   // public int CatId { get; set; }
    //public int PersonId { get; set; }

    public virtual Cat Cat { get; set; }

   // public virtual Person Owner {get; set; }

}