using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace The_Bright_Side_Test.Models;

public class Cat 
{   [Key]
    public int Id {get; set; }

    [MaxLength(20)]
    public string? Name { get; set; }

    public string Image { get; set; }

    [MaxLength(300)]
    public string? AdditionalInfo { get; set; }

    [MaxLength(15)]
    public string? Breed { get; set; }

    [Required]
    [MaxLength(300)]
    public string Characteristics {get; set; }

    [MaxLength(15)]
    public string? Size { get; set; }

    [MaxLength(15)]
    public string? Eyecolor { get; set; }

    [MaxLength(15)]
    public string? CoatLength { get; set; }

    [MaxLength(1)]
    public string? Gender {get; set; }  

    //public int PersonId { get; set; }

    public virtual Person Owner { get; set; }

    public virtual List<Person> Informers { get; set; }
}