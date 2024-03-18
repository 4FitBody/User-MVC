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
        var exercises = await this.exerciseRepository.GetAll();

        if (exercises is null)
        {
            return Enumerable.Empty<Exercise>();
        }

        return exercises;
    }
}