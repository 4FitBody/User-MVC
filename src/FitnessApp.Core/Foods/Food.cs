namespace FitnessApp.Core.Foods;

using System.Text.Json.Serialization;

public class Food
{

    [JsonPropertyName("title")]
    public string Title { get; set; }
    
}
