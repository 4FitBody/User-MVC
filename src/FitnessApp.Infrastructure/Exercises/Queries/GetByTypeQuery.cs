namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByTypeQuery : IRequest<IEnumerable<Exercise>?>
{
    public ExerciseType? Type { get; set; }

    public GetByTypeQuery(ExerciseType type)
    {
        this.Type = type;
    }

    public GetByTypeQuery() { }
}