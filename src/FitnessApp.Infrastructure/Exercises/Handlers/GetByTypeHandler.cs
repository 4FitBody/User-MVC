namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetByTypeHandler : IRequestHandler<GetByTypeQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByTypeHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetByTypeQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Type);

        var exercises = await this.exerciseRepository.GetByType(request.Type);

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}