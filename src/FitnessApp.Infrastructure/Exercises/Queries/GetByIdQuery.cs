namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByIdQuery : IRequest<Exercise?>
{
    public string? Id { get; set; }

    public GetByIdQuery(string id)
    {
        this.Id = id;
    }

    public GetByIdQuery() { }
}