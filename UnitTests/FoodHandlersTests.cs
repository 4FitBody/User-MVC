using FitnessApp.Infrastructure.Food.Handlers;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;

namespace UnitTests;

public class FoodHandlersTests
{
    [Fact]
    public async Task GetByCategory_PassNullCategory_ThrowsArgumentNullException()
    {
        string? category = null;

        var command = new GetbyCategoryQueries(category);

        var handler = new GetbyCategoryHandler(null, null);

        Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public void GetById_PassNullId_ThrowsArgumentNullException()
    {
        int? id = null;

        var command = new GetByIdQuery(id, "url");

        var handler = new GetByIdHandler(null);

        Assert.ThrowsAsync<ArgumentNullException>(async () => await handler.Handle(command, CancellationToken.None));
    }
}