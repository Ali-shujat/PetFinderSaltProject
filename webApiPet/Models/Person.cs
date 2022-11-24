using System.ComponentModel.DataAnnotations;

namespace PetFinderApi.Data.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
