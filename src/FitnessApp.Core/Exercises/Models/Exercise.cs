namespace FitnessApp.Core.Exercises.Models;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class Exercise
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ExerciseType? Type { get; set; }

    [JsonProperty("muscle")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MuscleType? Muscle { get; set; }

    [JsonProperty("equipment")]
    public string? EquipmentName { get; set; }

    [JsonProperty("difficulty")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Difficulty? Difficulty { get; set; }

    [JsonProperty("instructions")]
    public string? Instructions { get; set; }
}