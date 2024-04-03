namespace FitnessApp.Infrastructure.Food.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Foods;
using MediatR;

public class SearchQueries : IRequest<AllFood>
{
    public string? query { get; set; }

    public int Offset { get; set; }

    public SearchQueries(string? query, int offset)
    {
        this.query = query;
        
        this.Offset = offset;
    }

    public SearchQueries() { }
}
