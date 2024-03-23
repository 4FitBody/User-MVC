namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetByBodyPartHandler : IRequestHandler<GetByBodyPartQuery, IEnumerable<Exercise>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetByBodyPartHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<Exercise>?> Handle(GetByBodyPartQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request.BodyPart);

        var exercises = await this.exerciseRepository.GetByName(request.BodyPart);

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}