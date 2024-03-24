namespace FitnessApp.Core.Foods.Models;

using System.Text.Json.Serialization;

public class Video
{
    [JsonPropertyName("shortTitle")]
    public string ShortTitle { get; set; }
    
    [JsonPropertyName("youTubeId")]
    public string YouTubeId { get; set; }
}
