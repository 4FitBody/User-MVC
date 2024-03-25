namespace FitnessApp.Infrastructure.Food.Queries;

using MediatR;

public class GetIngredientsQueries: IRequest<string>
{
    public int? Id { get; set; }
    
    public GetIngredientsQueries(int? Id)
    {
        this.Id = Id;
    }

    public GetIngredientsQueries() { }
}
