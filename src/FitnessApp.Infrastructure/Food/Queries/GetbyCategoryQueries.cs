namespace FitnessApp.Infrastructure.Food.Queries;

using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;
using MediatR;

public class GetbyCategoryQueries : IRequest<AllFood>
{
    public FilterFood? FoodParams { get; set; }

    public int Offset { get; set; }
    
    public GetbyCategoryQueries(FilterFood? foodParams, int offset)
    {
        this.FoodParams = foodParams;

        this.Offset = offset;
    }

    public GetbyCategoryQueries() { }
}
