namespace FitnessApp.Infrastructure.Food.Handlers;

using FitnessApp.Infrastructure.Food.Queries;
using FitnessApp.Infrastructure.Food.Repositories.Base;
using MediatR;

public class GetIngredientsHandler : IRequestHandler<GetIngredientsQueries,string>
{
    private readonly IFoodRepository repository;

    public GetIngredientsHandler(IFoodRepository repository)
    {
        this.repository = repository;
    }

    public async Task<string> Handle(GetIngredientsQueries request, CancellationToken cancellationToken)
    {
        if (request.Id is null)
        {
            throw new ArgumentNullException(request.Id.ToString());
        }

        return await repository.GetIngredients(request.Id);
    }

}
