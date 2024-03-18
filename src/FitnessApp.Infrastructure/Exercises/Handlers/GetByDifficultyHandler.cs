namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetByDifficultyHandler : IRequestHandler<GetByDifficultyQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByDifficultyHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetByDifficultyQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Difficulty);

        var exercises = await this.exerciseRepository.GetByDifficulty(request.Difficulty);
    
        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}