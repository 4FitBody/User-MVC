namespace FitnessApp.Core.Foods;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class AllFood
{

    [JsonPropertyName("results")]
    public List<Food> Foods { get; set; }

}
