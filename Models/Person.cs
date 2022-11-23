using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace The_Bright_Side_Test.Models;

public class Person
{
    [Key]
    public int Id {get; set; }

    [MaxLength(20)]
    public string FirstName { get; set; }

    [MaxLength(20)]
    public string Surname { get; set; }

    [MaxLength(15), MinLength(5)]
    public string? Phone { get; set; }

    [MaxLength(50), MinLength(10)]
    public string Email { get; set; }

}