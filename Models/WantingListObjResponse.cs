using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingListObjResponse
{
    public int id {get; set;}
    public string CatName { get; set; } 
    public string EventInfo { get; set; }
    //public string pictureUri
    public string DetailedUri {get; set; }
}