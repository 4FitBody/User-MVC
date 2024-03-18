namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByNameQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? Name { get; set; }

    public GetByNameQuery(string name)
    {
        this.Name = name;
    }

    public GetByNameQuery() { }
}