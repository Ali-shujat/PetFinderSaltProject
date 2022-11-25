using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingRequest
{
    public string? OwnerName {get; set; }
    public string? Email { get; set; }
    public string? CatName { get; set; }
    public double[]? Position { get; set; }
    public string? EventInfo { get; set; }
}