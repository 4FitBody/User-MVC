namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetByMuscleTypeHandler : IRequestHandler<GetByMuscleTypeQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByMuscleTypeHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetByMuscleTypeQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.MuscleType);

        var exercises = await this.exerciseRepository.GetByMuscleType(request.MuscleType);

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}