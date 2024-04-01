namespace FitnessApp.Infrastructure.Exercises.Handlers;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;

public class GetBodyPartsHandler : IRequestHandler<GetBodyPartsQuery, IEnumerable<string>?>
{
    private readonly IExerciseRepository exerciseRepository;

    public GetBodyPartsHandler(IExerciseRepository exerciseRepository) => this.exerciseRepository = exerciseRepository;

    public async Task<IEnumerable<string>?> Handle(GetBodyPartsQuery request, CancellationToken cancellationToken)
    {
        var bodyParts = await this.exerciseRepository.GetBodyParts();

        if (bodyParts is null)
        {
            return Enumerable.Empty<string>();
        }

        return bodyParts;
    }
}