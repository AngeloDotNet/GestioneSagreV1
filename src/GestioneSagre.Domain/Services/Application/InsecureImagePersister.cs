namespace GestioneSagre.Domain.Services.Application;

public class InsecureImagePersister : IImagePersister
{
    private readonly IWebHostEnvironment env;

    public InsecureImagePersister(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public async Task<string> SaveImageAsync(string imageName, string imageExtension, string imagePath, IFormFile formFile)
    {
        var path = $"/{imagePath}/{imageName}.{imageExtension}";
        var physicalPath = Path.Combine(env.WebRootPath, imagePath, $"{imageName}.{imageExtension}");

        using var fileStream = File.OpenWrite(physicalPath);

        await formFile.CopyToAsync(fileStream);

        return path;
    }
}