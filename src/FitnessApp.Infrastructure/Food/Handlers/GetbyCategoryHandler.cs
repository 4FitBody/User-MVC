namespace FitnessApp.Infrastructure.Food.Handlers;

using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;
using FitnessApp.Infrastructure.Food.Repositories.Base;

public class GetbyCategoryHandler : IRequestHandler<GetbyCategoryQueries, IEnumerable<Food>>
{
    private readonly IFoodRepository repository;

    private readonly IImageRepository imageRepository;

    public GetbyCategoryHandler(IFoodRepository repository, IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;
        
        this.repository = repository;
    }

    public async Task<IEnumerable<Food>> Handle(GetbyCategoryQueries request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetByCategory(request.FoodName);

        foreach (var r in recipes)
        {
            r.Image = await imageRepository.GetImage(r.Title);
        }

        return recipes;
    }

}
