namespace FitnessApp.Infrastructure.Food.Queries;

using MediatR;
using FitnessApp.Core.Foods;

public class GetAllQueries : IRequest<AllFood>
{
     public int Offset { get; set; }

    public GetAllQueries(int offset)
    {
        this.Offset = offset;
    }

    public GetAllQueries() { }
}
