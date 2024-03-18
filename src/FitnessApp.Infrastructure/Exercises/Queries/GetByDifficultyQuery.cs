namespace FitnessApp.Infrastructure.Exercises.Queries;

using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByDifficultyQuery : IRequest<IEnumerable<Exercise>?>
{
    public Difficulty? Difficulty { get; set; }

    public GetByDifficultyQuery(Difficulty difficulty)
    {
        this.Difficulty = difficulty;
    }

    public GetByDifficultyQuery() { }
}