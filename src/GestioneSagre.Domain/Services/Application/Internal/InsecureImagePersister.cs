using GestioneSagre.Domain.Services.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GestioneSagre.Domain.Services.Application.Internal;

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