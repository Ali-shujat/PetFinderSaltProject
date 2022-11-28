namespace PetFinderApi.Models;

public class FileService
{
    private string BLOB_PATH;

    private string blobname = "petpics";
    private string blobaccount = "petblobaccount";
    private string _pictureName = "dog";
    private string pictureFormat = "jpg";

    public FileService(string pictureName)
    {
        _pictureName = pictureName;
        BLOB_PATH = $"https://{blobaccount}.blob.core.windows.net/{blobname}/{pictureName}.{pictureFormat}";
        //BLOB_PATH = $"https://{blobaccount}.blob.core.windows.net/{blobname}/{pictureName}";
    }
    public FileService()
    {}

    public string getPath(string pictureName) => $"https://{blobaccount}.blob.core.windows.net/{blobname}/{pictureName}.{pictureFormat}";
}