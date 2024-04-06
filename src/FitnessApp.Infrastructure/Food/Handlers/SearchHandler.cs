namespace FitnessApp.Infrastructure.Food.Handlers;

using System;
using System.Collections.Generic;
using FitnessApp.Core.Foods;
using System.Threading;
using System.Threading.Tasks;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;
using FitnessApp.Infrastructure.Food.Repositories.Base;

public class SearchHandler : IRequestHandler<SearchQueries, AllFood>
{
    private readonly IFoodRepository repository;

    private readonly IImageRepository imageRepository;

    public SearchHandler(IFoodRepository repository, IImageRepository imageRepository)
    {
        this.imageRepository = imageRepository;

        this.repository = repository;
    }

    public async Task<AllFood> Handle(SearchQueries request, CancellationToken cancellationToken)
    {
        var recipes = await repository.Search(request.query, request.Offset);

        foreach (var r in recipes.Foods)
        {
            r.Image = await imageRepository.GetImage(r.Title);
        }

        return recipes;
    }
}
