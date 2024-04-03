using FitnessApp.Core.Exercises.Models;

namespace FitnessApp.Presentation.ViewModels;

public class ExercisesViewModel
{
    public IEnumerable<Exercise>? Exercises { get; set; }
    public int Offset { get; set; }
}