using Microsoft.AspNetCore.Http;
namespace PetFinderApi.Models;

public class WantingRequest
{
    public string? OwnerName { get; set; }
    public string? Email { get; set; }
    public string? CatName { get; set; }
    public double[]? Position { get; set; }
    public string? Description { get; set; }
    public IFormFile image { get; set; }
}