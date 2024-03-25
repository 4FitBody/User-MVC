namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetBySearchQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? Search { get; set; }

    public GetBySearchQuery(string search)
    {
        this.Search = search;
    }

    public GetBySearchQuery() { }
}