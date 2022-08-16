namespace GestioneSagre.Domain.Services.Application;

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
            var path = $"/{imagePath}/{imageName}.{imageExtension}";
            var physicalPath = Path.Combine(env.ContentRootPath, imagePath, $"{imageName}.{imageExtension}");

            if (!Directory.Exists(Path.GetDirectoryName(physicalPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(physicalPath));
            }

            using var inputStream = formFile.OpenReadStream();
            using MagickImage image = new(inputStream);

            var width = 300;
            var height = 300;

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