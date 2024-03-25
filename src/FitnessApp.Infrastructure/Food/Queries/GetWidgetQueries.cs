namespace FitnessApp.Infrastructure.Food.Queries;

using MediatR;

public class GetWidgetQueries : IRequest<string>
{
    public int? Id { get; set; }
    
    public GetWidgetQueries(int? Id)
    {
        this.Id = Id;
    }

    public GetWidgetQueries() { }
}
