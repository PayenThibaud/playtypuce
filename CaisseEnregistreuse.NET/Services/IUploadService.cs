namespace CaisseEnregistreuse.NET.Services
{
    public interface IUploadService
    {
        string Upload(IFormFile file);
    }
}
