namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetAllHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.Limit);

        ArgumentNullException.ThrowIfNull(request.Offset);

        var exercises = await this.exerciseRepository.GetAll(request.Limit, request.Offset);

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}