namespace FitnessApp.Core.Exercises.Repositories;

using FitnessApp.Core.Exercises.Models;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>?> GetAll();
    Task<IEnumerable<Exercise>?> GetById(string? id);
    Task<IEnumerable<Exercise>?> GetByName(string? name);
    Task<IEnumerable<Exercise>?> GetByTarget(string? target);
    Task<IEnumerable<Exercise>?> GetByEquipment(string? equipment);
    Task<IEnumerable<Exercise>?> GetByBodyPart(string? bodyPart);
}