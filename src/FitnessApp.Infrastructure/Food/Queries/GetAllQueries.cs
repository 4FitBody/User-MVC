namespace FitnessApp.Infrastructure.Food.Queries;

using MediatR;
using FitnessApp.Core.Foods;

public class GetAllQueries : IRequest<IEnumerable<Food>>
{
    
}
