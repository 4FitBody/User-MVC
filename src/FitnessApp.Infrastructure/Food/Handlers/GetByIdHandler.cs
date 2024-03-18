namespace FitnessApp.Infrastructure.Food.Handlers;

using System.Threading;
using System.Threading.Tasks;
using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using FitnessApp.Infrastructure.Food.Repositories.Base;
using MediatR;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, Food>
{
    private readonly IFoodRepository repository;

    public GetByIdHandler(IFoodRepository repository){
        this.repository = repository;
    }

    public async Task<Food> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.Id is null)
        {
            throw new ArgumentNullException(request.Id.ToString());
        }

        var food = await repository.GetById(request.Id);

        if(food is null){
            throw new ArgumentNullException("No food by this Id");
        }

        food.Image = request.ImageUrl;

        return food;
    }
}


