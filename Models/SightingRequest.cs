using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class SightingRequest
{
    //TODO: validation
    [Required]
    public string InformerName {get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string CatDescription { get; set; }
    [Required]
    //[LocationValidation(ErrorMessage = "Must have two elements")]
    public double[] Position { get; set; }
    [Required]
    public string EventInfo { get; set; }
  //  public string FileName { get; set; }
  //  public IFormFile FormFile { get; set; }
}