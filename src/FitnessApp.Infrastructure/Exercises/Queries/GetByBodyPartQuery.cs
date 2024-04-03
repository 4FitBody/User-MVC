namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByBodyPartQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? BodyPart { get; set; }
    public int? Limit { get; set; }
    public int? Offset { get; set; }

    public GetByBodyPartQuery(string bodyPart, int? limit, int? offset)
    {
        this.BodyPart = bodyPart;
        
        this.Limit = limit;
        
        this.Offset = offset;
    }

    public GetByBodyPartQuery() { }
}