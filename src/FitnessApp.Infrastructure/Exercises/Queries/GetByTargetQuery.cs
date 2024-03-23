namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByTargetQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? Target { get; set; }

    public GetByTargetQuery(string target)
    {
        this.Target = target;
    }

    public GetByTargetQuery() { }
}