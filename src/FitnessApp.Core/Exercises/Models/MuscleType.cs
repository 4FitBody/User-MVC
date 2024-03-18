namespace FitnessApp.Core.Exercises.Models;

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum MuscleType
{
    [EnumMember(Value = "abdominals")]
    Abdominals,
    [EnumMember(Value = "abductors")]
    Abductors,
    [EnumMember(Value = "adductors")]
    Adductors,
    [EnumMember(Value = "biceps")]
    Biceps,
    [EnumMember(Value = "calves")]
    Calves,
    [EnumMember(Value = "chest")]
    Chest,
    [EnumMember(Value = "forearms")]
    Forearms,
    [EnumMember(Value = "glutes")]
    Glutes,
    [EnumMember(Value = "hamstrings")]
    Hamstrings,
    [EnumMember(Value = "lats")]
    Lats,
    [EnumMember(Value = "lower_back")]
    LowerBack,
    [EnumMember(Value = "middle_back")]
    MiddleBack,
    [EnumMember(Value = "neck")]
    Neck,
    [EnumMember(Value = "quadriceps")]
    Quadriceps,
    [EnumMember(Value = "traps")]
    Traps,
    [EnumMember(Value = "triceps")]
    Triceps,
    [EnumMember(Value = "shoulders")]
    Shoulders,
}