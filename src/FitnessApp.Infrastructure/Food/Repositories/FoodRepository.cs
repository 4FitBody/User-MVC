namespace FitnessApp.Infrastructure.Food.Repositories;

using System.Text.Json;
using FitnessApp.Core.Foods;
using FitnessApp.Infrastructure.Food.Repositories.Base;

public class FoodRepository : IFoodRepository
{
    public readonly string ApiKey;

    public FoodRepository(string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<IEnumerable<Food>> GetByCategory(string? foodName)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?query={foodName}&apiKey=" + ApiKey;

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

        return recipes.Foods;
    }

    public async Task<Food> GetById(int? id)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/{id}/summary?apiKey=" + ApiKey;

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

        return food;
    }
}
