namespace FitnessApp.Infrastructure.Food.Queries;

using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;
using MediatR;

public class GetbyCategoryQueries : IRequest<IEnumerable<Food>>
{
    public FilterFood? FoodParams { get; set; }

    public GetbyCategoryQueries(FilterFood? foodParams)
    {
        this.FoodParams = foodParams;
    }

    public GetbyCategoryQueries() { }
}
