using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SightingController : ControllerBase
{
    private readonly ISightingService _dbservice;
    private readonly Mapper mapper = new();
    private readonly string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=petblobaccount;AccountKey=1Oa4CeDyrtKAVGnBIweNqXsRus9xkf45xOSRJQ9l+jlspwPlh1E0BlHJJ3SajJuhKHX4uIvB8WHP+AStH6HvLg==;EndpointSuffix=core.windows.net";
    private readonly string containerName = "petpics";

    public SightingController(ISightingService service)
    {
        _dbservice = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sighting>>> GetAllSighting()
    {
        var sightings = await _dbservice.GetAll();
        var SightingsToList = mapper.getAllSightings(sightings);
        return Ok(SightingsToList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Sighting>> GetOneSighting(int id)
    {
        var sighting = await _dbservice.GetOne(id);
        if (sighting == null) return NotFound();
        var response = mapper.makeOneSighting(sighting);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Sighting>> Create([FromForm] SightingRequest request)
    {
        var sighting = mapper.SightingReqToSighting(request);
        var fileName = Guid.NewGuid().ToString() + request.image.FileName;
        sighting.imageFileName = fileName;
        await _dbservice.Create(sighting);

        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
        CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
        await using (var data = request.image.OpenReadStream())
        {
            await blockBlob.UploadFromStreamAsync(data);
        }
        return CreatedAtAction("GetOneSighting", new { id = sighting.Id }, mapper.makeOneSighting(sighting));
    }
}