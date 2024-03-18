namespace FitnessApp.Core.Exercises.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum Difficulty
{
    [EnumMember(Value = "beginner")]
    Beginner,
    [EnumMember(Value = "intermediate")]
    Intermediate,
    [EnumMember(Value = "expert")]
    Expert,
}