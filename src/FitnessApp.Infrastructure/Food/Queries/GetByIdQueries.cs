namespace FitnessApp.Infrastructure.Food.Queries;

using FitnessApp.Core.Foods;
using MediatR;

public class GetByIdQuery : IRequest<Food>
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public GetByIdQuery(int Id, string ImageUrl)
    {
        this.Id = Id;
        this.ImageUrl = ImageUrl;
    }

    public GetByIdQuery() { }
}
