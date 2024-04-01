namespace FitnessApp.Infrastructure.Exercises.Queries;

using MediatR;

public class GetBodyPartsQuery : IRequest<IEnumerable<string>?>
{

}