namespace FitnessApp.Infrastructure.Food.Queries;

using FitnessApp.Core.Foods;
using MediatR;

public class GetbyCategoryQueries : IRequest<IEnumerable<Food>>
{
    public string? FoodName { get; set; }

    public GetbyCategoryQueries(string? foodName)
    {
        this.FoodName = foodName;
    }

    public GetbyCategoryQueries() { }
}
