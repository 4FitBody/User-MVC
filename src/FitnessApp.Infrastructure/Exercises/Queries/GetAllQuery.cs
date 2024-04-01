namespace FitnessApp.Infrastructure.Exercises.Queries;

using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetAllQuery : IRequest<IEnumerable<Exercise>?>
{
    public int? Limit { get; set; }
    public int? Offset { get; set; }

    public GetAllQuery(int? limit, int? offset)
    {
        this.Limit = limit;

        this.Offset = offset;
    }

    public GetAllQuery() { }
}