using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class SightingRequest
{
    public string? InformerName {get; set; }
    public string? Email { get; set; }
    public string? CatDescription { get; set; }
    public double[]? Position { get; set; }
    public string? EventInfo { get; set; }
}