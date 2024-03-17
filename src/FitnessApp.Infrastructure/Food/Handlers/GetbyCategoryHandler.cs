namespace FitnessApp.Infrastructure.Food.Handlers;

using System.Text.Json;
using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Queries;
using FitnessApp.Infrastructure.Food.HelpClasses;
using MediatR;

public class GetbyCategoryHandler : IRequestHandler<GetbyCategoryQueries, IEnumerable<Food>>
{

    public async Task<IEnumerable<Food>> Handle(GetbyCategoryQueries request, CancellationToken cancellationToken)
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
        foreach (var r in recipes.Foods)
        {
            r.Image = await GetImageforFood.GetImage(r.Title);
        }
        return recipes.Foods;
    }

}
