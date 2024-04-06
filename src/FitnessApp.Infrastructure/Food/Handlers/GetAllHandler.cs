namespace FitnessApp.Infrastructure.Food.Handlers;

using FitnessApp.Infrastructure.Food.Repositories.Base;
using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;

public class GetAllHandler : IRequestHandler<GetAllQueries, AllFood>
{
    private readonly IFoodRepository repository;

    private readonly IImageRepository imageRepository;

    public GetAllHandler(IFoodRepository repository, IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;

        this.repository = repository;
    }

    public async Task<AllFood> Handle(GetAllQueries request, CancellationToken cancellationToken)
    {
        var recipes = await repository.GetAll(request.Offset);

        foreach (var r in recipes.Foods)
        {
            r.Image = await imageRepository.GetImage(r.Title);
        }

        return recipes;
    }

}
