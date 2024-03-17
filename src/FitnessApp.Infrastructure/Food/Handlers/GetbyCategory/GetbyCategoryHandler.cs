namespace FitnessApp.Infrastructure.Food.Handlers.GetbyCategory;

using System.Text.Json;
using FitnessApp.Core.Foods;
using MediatR;

public class GetbyCategoryHandler : IRequestHandler<GetbyCategoryCommand, IEnumerable<Food>>
{
    
    public async Task<IEnumerable<Food>> Handle(GetbyCategoryCommand request, CancellationToken cancellationToken)
    {

        string APIKey = "d6c43be27aa74da5a870679ef210718e";

        string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?query={request.FoodName}&apiKey=" + APIKey;

        using var client = new HttpClient();
        var recipes = new AllFood();

        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();
            recipes = JsonSerializer.Deserialize<AllFood>(json);
        }

        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        if (recipes is null || !recipes.Foods.Any())
            return Enumerable.Empty<Food>();

        return recipes.Foods;
    }

}
