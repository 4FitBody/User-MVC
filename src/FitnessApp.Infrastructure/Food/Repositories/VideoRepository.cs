namespace FitnessApp.Infrastructure.Food.Repositories;

using System.Text.Json;
using FitnessApp.Core.Foods.Models;
using FitnessApp.Core.Foods.Repositories;

public class VideoRepository : IVideoRepository
{
    public readonly string ApiKey;

    public VideoRepository(string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<string> GetVideo(string foodName)
    {

        string apiUrlVideo = $"https://api.spoonacular.com/food/videos/search?query={foodName}&number=1&apiKey=" + ApiKey;

        using var videoClient = new HttpClient();

        var videos = new AllVideo();

        HttpResponseMessage videoResponse = await videoClient.GetAsync(apiUrlVideo);

        if (videoResponse.IsSuccessStatusCode)
        {
            string json = await videoResponse.Content.ReadAsStringAsync();

            videos = JsonSerializer.Deserialize<AllVideo>(json);
        }

        else
        {
            Console.WriteLine($"Error: {videoResponse.StatusCode} - {videoResponse.ReasonPhrase}");
        }

        if(videos.Videos.Count == 0){
            return string.Empty;
        }

        return videos.Videos[0].YouTubeId;
    }
}
