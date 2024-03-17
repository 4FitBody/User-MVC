namespace FitnessApp.Infrastructure.Food.Repositories;

using FitnessApp.Infrastructure.Food.Repositories.Base;
using PexelsDotNetSDK.Api;

public class ImageRepository : IImageRepository
{
    public readonly string ApiKey;

    public ImageRepository(string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<string> GetImage(string foodName)
    {
        var pexelsClient = new PexelsClient(ApiKey);

        var result = await pexelsClient.SearchPhotosAsync(foodName);

        var photos = result.photos;

        if (photos is null)
        {
            throw new ArgumentNullException("No Image for this food");
        }

        return photos.FirstOrDefault().source.original;
    }
}
