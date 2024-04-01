namespace FitnessApp.Core.Exercises.Models;

using Newtonsoft.Json;

public class Exercise
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("bodyPart")]
    public string? BodyPart { get; set; }

    [JsonProperty("equipment")]
    public string? Equipment { get; set; }

    [JsonProperty("gifUrl")]
    public string? GifUrl { get; set; }

    [JsonProperty("target")]
    public string? Target { get; set; }

    [JsonProperty("secondaryMuscles")]
    public string?[]? SecondaryMuscles { get; set; }

    [JsonProperty("instructions")]
    public string?[]? Instructions { get; set; }
}