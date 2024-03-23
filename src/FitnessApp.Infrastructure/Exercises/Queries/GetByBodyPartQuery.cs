namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByBodyPartQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? BodyPart { get; set; }

    public GetByBodyPartQuery(string bodyPart)
    {
        this.BodyPart = bodyPart;
    }

    public GetByBodyPartQuery() { }
}