using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingResponse
{
    public int id { get; set; }
    public string EventInfo { get; set; } = null!;
    public string CatName { get; set; } =null!;
    public string? Image { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Breed { get; set; }
    public string? Size { get; set; }
    public string? Eyecolor { get; set; }
    public string? CoatLength { get; set; }
    public string? Gender { get; set; }
    public string? OwnerFirstName { get; set; }
    public string? OwnerSurname { get; set; }
    public string? OwnerPhone { get; set; }
    public string? OwnerEmail { get; set; }
}