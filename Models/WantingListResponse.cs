using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingListResponse
{
<<<<<<< HEAD
    //public List<Wanting>
=======
   // public List<Wanting
>>>>>>> d8a8d8c1989eeb0c995a2d506fb8f77fe8fcc731
    //TODO: check håkans!
    [Required]
    public string CatName { get; set; }
    [Required]
    public double[] Position { get; set; }
    [Required]
    public string EventInfo { get; set; }
    //public string pictureUri
}