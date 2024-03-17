namespace FitnessApp.Infrastructure.Food.Handlers.GetbyCategory;

using FitnessApp.Core.Foods;
using MediatR;

public class GetbyCategoryCommand : IRequest<IEnumerable<Food>>
{

    public string? FoodName { get; set; }

    public GetbyCategoryCommand(string? foodName)
    {
        this.FoodName = foodName;
    }

    public GetbyCategoryCommand() { }
    
}
