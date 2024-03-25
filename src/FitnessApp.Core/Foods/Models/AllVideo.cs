namespace FitnessApp.Core.Foods.Models;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class AllVideo
{
    [JsonPropertyName("videos")]
    public List<Video> Videos { get; set; }
}
