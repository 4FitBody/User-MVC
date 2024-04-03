namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetBySearchHandler : IRequestHandler<GetBySearchQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetBySearchHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetBySearchQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Search);

        var exercises = await this.exerciseRepository.SearchExercises(request.Search);

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises!;
    }
}