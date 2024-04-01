namespace FitnessApp.Infrastructure.Exercises.Queries;

using System.Collections.Generic;
using FitnessApp.Core.Exercises.Models;
using MediatR;

public class GetByEquipmentQuery : IRequest<IEnumerable<Exercise>?>
{
    public string? Equipment { get; set; }

    public GetByEquipmentQuery(string equipment)
    {
        this.Equipment = equipment;
    }

    public GetByEquipmentQuery() { }
}