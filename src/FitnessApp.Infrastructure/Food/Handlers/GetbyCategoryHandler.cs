namespace FitnessApp.Infrastructure.Food.Handlers;

using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;
using FitnessApp.Infrastructure.Food.Repositories.Base;

public class GetbyCategoryHandler : IRequestHandler<GetbyCategoryQueries, AllFood>
{
    private readonly IFoodRepository repository;

    private readonly IImageRepository imageRepository;

    public GetbyCategoryHandler(IFoodRepository repository, IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;
        
        this.repository = repository;
    }

    public async Task<AllFood> Handle(GetbyCategoryQueries request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetByCategory(request.FoodParams,request.Offset);

        foreach (var r in recipes.Foods)
        {
            r.Image = await imageRepository.GetImage(r.Title);
        }

        return recipes;
    }

}
