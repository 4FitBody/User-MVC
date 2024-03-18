namespace FitnessApp.Core.Exercises.Repositories;

using FitnessApp.Core.Exercises.Models;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>?> GetAll();
    Task<IEnumerable<Exercise>?> GetByName(string? name);
    Task<IEnumerable<Exercise>?> GetByType(ExerciseType? type);
    Task<IEnumerable<Exercise>?> GetByMuscleType(MuscleType? muscleType);
    Task<IEnumerable<Exercise>?> GetByDifficulty(Difficulty? difficulty);
}