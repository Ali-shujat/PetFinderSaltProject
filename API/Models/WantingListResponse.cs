using PetFinderApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace PetFinderApi.Models;

public class WantingListResponse
{
public List<WantingListObjResponse> Wantings {get; set; }
public string Next {get; set; }
public string Previous {get; set; }
}