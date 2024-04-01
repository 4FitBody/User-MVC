namespace FitnessApp.Infrastructure.Food.Handlers;

using System.Threading;
using System.Threading.Tasks;
using FitnessApp.Infrastructure.Food.Queries;
using FitnessApp.Infrastructure.Food.Repositories.Base;
using MediatR;

public class GetWidgetHandler : IRequestHandler<GetWidgetQueries,string>
{
    private readonly IFoodRepository repository;

    public GetWidgetHandler(IFoodRepository repository)
    {
        this.repository = repository;
    }

    public async Task<string> Handle(GetWidgetQueries request, CancellationToken cancellationToken)
    {
        if (request.Id is null)
        {
            throw new ArgumentNullException(request.Id.ToString());
        }

        return await repository.GetWidget(request.Id);
    }
}
