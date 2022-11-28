using Microsoft.AspNetCore.Mvc;
using PetFinderApi.Data;
using PetFinderApi.Data.Services;
using PetFinderApi.Models;
using System.Collections.Generic;  
using System.IO;  
using System.Linq;  
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace PetFinderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WantingController : ControllerBase
{
    private readonly IWantingService _dbservice;
    private readonly Mapper mapper = new();
    private readonly string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=petblobaccount;AccountKey=1Oa4CeDyrtKAVGnBIweNqXsRus9xkf45xOSRJQ9l+jlspwPlh1E0BlHJJ3SajJuhKHX4uIvB8WHP+AStH6HvLg==;EndpointSuffix=core.windows.net";
    private readonly string containerName = "petpics";


    public WantingController(IWantingService service, PetFinderContext context)
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
        await _dbservice.Create(wanting);
        if (request.image == null) return Ok("no image");
        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(wanting.Id.ToString());
            await using (var data = request.image.OpenReadStream())
            {
                await blockBlob.UploadFromStreamAsync(data);
            }
            return CreatedAtAction("GetOneWanting", new { id = wanting.Id }, mapper.makeOne(wanting));
    }
    
    


    
  
/*        private readonly string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=petblobaccount;AccountKey=1Oa4CeDyrtKAVGnBIweNqXsRus9xkf45xOSRJQ9l+jlspwPlh1E0BlHJJ3SajJuhKHX4uIvB8WHP+AStH6HvLg==;EndpointSuffix=core.windows.net";
        private readonly string containerName = "petpics";

        [HttpPost(nameof(UploadFile))]  
        public async Task < IActionResult > UploadFile(IFormFile files) {
            string systemFileName = files.FileName;  
            //string blobstorageconnection = _configuration.GetValue < string > ("BlobConnectionString");
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);  
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();  
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);  
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);  
            await using(var data = files.OpenReadStream()) {  
                await blockBlob.UploadFromStreamAsync(data);  
            }  
            return Ok("File Uploaded Successfully");  
        } */  
}   
