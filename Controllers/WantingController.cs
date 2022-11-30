using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;
using System.Collections.Generic;  
using System.IO;  
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.AspNetCore.Http;


namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private readonly IWantingService _dbservice;
    private readonly Mapper mapper = new();
    private readonly string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=petblobaccount;AccountKey=1Oa4CeDyrtKAVGnBIweNqXsRus9xkf45xOSRJQ9l+jlspwPlh1E0BlHJJ3SajJuhKHX4uIvB8WHP+AStH6HvLg==;EndpointSuffix=core.windows.net";
    private readonly string containerName = "petpics";

    public WantingController(IWantingService service)
    {
        _dbservice = service;
    }

    [HttpGet]
    public async Task<ActionResult<WantingListResponse>> GetAllWanting()
    {
        var wantings = await _dbservice.GetAll();
        var WantingsToList = mapper.getAll(wantings);
        return Ok(WantingsToList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Wanting>> GetOneWanting(int id)
    {
        var wanting = await _dbservice.GetOne(id);
        if (wanting == null) return NotFound();
        var response = mapper.makeOne(wanting);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Wanting>> Create([FromForm] WantingRequest request)
    {
        var wanting = mapper.WantingReqToWanting(request);
        string fileName;
        if (request.image.FileName.Length > 0)
        {
             fileName = Guid.NewGuid() + request.image.FileName;
             CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
             CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
             CloudBlobContainer container = blobClient.GetContainerReference(containerName);
             CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
             await using (var data = request.image.OpenReadStream())
             { 
                 await blockBlob.UploadFromStreamAsync(data);
             }
        }
        else fileName = "No image";
        wanting.imageFileName = fileName;

        await _dbservice.Create(wanting);
        
        return CreatedAtAction("GetOneWanting", new { id = wanting.Id }, mapper.makeOne(wanting));
    }
}   