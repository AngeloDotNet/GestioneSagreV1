namespace GestioneSagre.Domain.Services.Application;

public interface IImagePersister
{
    /// <returns>The image URL e.g. /images/7c9e6679-7425-40de-944b-e07fc1f90ae7.jpg</returns>
    Task<string> SaveImageAsync(string imageName, string imageExtension, string imagePath, IFormFile formFile);
}