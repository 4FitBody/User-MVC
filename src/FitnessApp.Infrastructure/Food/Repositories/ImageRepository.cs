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

        if (result is null || result.photos.Count==0)
        {
            foodName = "sorry";

            result = await pexelsClient.SearchPhotosAsync(foodName);

            var defautlPhoto = result.photos;

            return defautlPhoto.FirstOrDefault().source.original;
        }

        var photos = result.photos;

        return photos.FirstOrDefault().source.original;
    }
}
