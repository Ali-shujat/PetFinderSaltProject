using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingListResponse
{
    //public List<Wanting>
    //TODO: check håkans!
    [Required]
    public string CatName { get; set; }
    [Required]
    public double[] Position { get; set; }
    [Required]
    public string EventInfo { get; set; }
    //public string pictureUri
}