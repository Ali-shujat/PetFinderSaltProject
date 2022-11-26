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
    public class BlobController: ControllerBase {  
        private readonly IConfiguration _configuration;  
        public BlobController(IConfiguration configuration) 
        {  
            _configuration = configuration;  
        }  
        [HttpPost(nameof(UploadFile))]  
        public async Task < IActionResult > UploadFile(IFormFile files) {  
            string systemFileName = files.FileName;  
            string blobstorageconnection = _configuration.GetValue < string > ("BlobConnectionString");
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);  
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();  
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue < string > ("BlobContainerName"));  
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);  
            await using(var data = files.OpenReadStream()) {  
                await blockBlob.UploadFromStreamAsync(data);  
            }  
            return Ok("File Uploaded Successfully");  
        }   
    }   