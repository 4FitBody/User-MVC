namespace FitnessApp.Infrastructure.Food.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Foods;
using MediatR;

public class SearchQueries : IRequest<IEnumerable<Food>>
{
    public string? query { get; set; }

    public SearchQueries(string? query)
    {
        this.query = query;
    }

    public SearchQueries() { }
}
