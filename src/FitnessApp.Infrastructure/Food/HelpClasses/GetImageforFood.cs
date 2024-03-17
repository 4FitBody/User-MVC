namespace FitnessApp.Infrastructure.Food.HelpClasses;

using System.Linq;
using System.Threading.Tasks;
using PexelsDotNetSDK.Api;

public class GetImageforFood
{
    public static async Task<string> GetImage(string foodName)
    {
        var pexelsClient = new PexelsClient("3RPbL7b4OQoA9ai3iGZ2vLVDR4dwzusnPAqlE1tCLAnwLI0AnsfHAd04");
        var result = await pexelsClient.SearchPhotosAsync(foodName);
        var photos = result.photos;
        return photos.FirstOrDefault().source.original;
    }
}
