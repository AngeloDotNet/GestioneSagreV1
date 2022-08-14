using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestioneSagre.Domain.Services.Application.Interfaces;
using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace GestioneSagre.Domain.Services.Application.Internal;

public class MagickNetImagePersister : IImagePersister
{
    private readonly IWebHostEnvironment env;
    private readonly SemaphoreSlim semaphore;

    public MagickNetImagePersister(IWebHostEnvironment env)
    {
        ResourceLimits.Height = 4000;
        ResourceLimits.Width = 4000;

        semaphore = new SemaphoreSlim(1);
        this.env = env;
    }

    public async Task<string> SaveImageAsync(string imageName, string imageExtension, string imagePath, IFormFile formFile)
    {
        await semaphore.WaitAsync();

        try
        {
            string path = $"/{imagePath}/{imageName}.{imageExtension}";
            string physicalPath = Path.Combine(env.ContentRootPath, imagePath, $"{imageName}.{imageExtension}");

            if (!Directory.Exists(Path.GetDirectoryName(physicalPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath));
            }

            using Stream inputStream = formFile.OpenReadStream();
            using MagickImage image = new(inputStream);

            int width = 300;
            int height = 300;

            MagickGeometry resizeGeometry = new(width, height)
            {
                FillArea = true
            };

            image.Resize(resizeGeometry);
            image.Crop(width, width, Gravity.Northwest);

            image.Quality = 70;
            image.Write(physicalPath, MagickFormat.Jpg);

            return path;
        }
        finally
        {
            semaphore.Release();
        }
    }
}