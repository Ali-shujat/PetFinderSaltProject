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
        private readonly string blobstorageconnection = "DefaultEndpointsProtocol=https;AccountName=petblobaccount;AccountKey=1Oa4CeDyrtKAVGnBIweNqXsRus9xkf45xOSRJQ9l+jlspwPlh1E0BlHJJ3SajJuhKHX4uIvB8WHP+AStH6HvLg==;EndpointSuffix=core.windows.net";
        private readonly string containerName = "petpics";

        [HttpPost(nameof(UploadFile))]  
        public async Task < IActionResult > UploadFile(IFormFile files)
        {
            string systemFileName = "LOTTENPLAYING";//new Guid().ToString(); 
            //string blobstorageconnection = _configuration.GetValue < string > ("BlobConnectionString");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);  
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();  
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);  
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);  
            await using(var data = files.OpenReadStream()) {  
                await blockBlob.UploadFromStreamAsync(data);  
            }  
            return Ok("File Uploaded Successfully");  
        }   
    }   