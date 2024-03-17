namespace FitnessApp.Infrastructure.Food.Handlers;

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using MediatR;

public class GetByIdHandler : IRequestHandler<GetByIdQuery, Food>
{
    public async Task<Food> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {
        string APIKey = "d6c43be27aa74da5a870679ef210718e";

        string apiUrl = $"https://api.spoonacular.com/recipes/{request.Id}/summary?apiKey=" + APIKey;
        using var client = new HttpClient();
        var food = new Food();
        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            food = JsonSerializer.Deserialize<Food>(json);
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
        food.Image = request.ImageUrl;
        return food;
    }
}


