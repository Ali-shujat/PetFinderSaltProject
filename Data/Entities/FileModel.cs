namespace PetFinderApi.Data.Entities;


public class FileModel
{
    public string? FileName { get; set; }
    public IFormFile FormFile { get; set; }
}
