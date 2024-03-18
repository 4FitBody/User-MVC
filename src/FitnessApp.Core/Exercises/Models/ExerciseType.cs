namespace FitnessApp.Core.Exercises.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum ExerciseType
{
    [EnumMember(Value = "cardio")]
    Cardio,
    [EnumMember(Value = "olympic_weightlifting")]
    OlympicWeightlifting,
    [EnumMember(Value = "plyometrics")]
    Plyometrics,
    [EnumMember(Value = "powerlifting")]
    Powerlifting,
    [EnumMember(Value = "strength")]
    Strength,
    [EnumMember(Value = "stretching")]
    Stretching,
    [EnumMember(Value = "strongman")]
    Strongman,
}