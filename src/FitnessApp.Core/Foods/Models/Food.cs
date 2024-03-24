namespace FitnessApp.Core.Foods;

using System.Text.Json.Serialization;

public class Food
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("summary")]
    public string? Description { get; set; }

    public string? VideoId { get; set; }
}
