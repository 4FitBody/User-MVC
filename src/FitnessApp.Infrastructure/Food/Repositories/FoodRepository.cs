namespace FitnessApp.Infrastructure.Food.Repositories;

using System.Text.Json;
using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;
using FitnessApp.Infrastructure.Food.Repositories.Base;

public class FoodRepository : IFoodRepository
{
    public readonly string ApiKey;

    public FoodRepository(string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<IEnumerable<Food>> GetByCategory(FilterFood? FoodParams)
    {
        string apiUrl = string.Empty;

        if (FoodParams.Diet.Contains("Omnivore") && string.IsNullOrWhiteSpace(FoodParams.Intolerances))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else if (FoodParams.Diet.Contains("Omnivore"))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?intolerances={FoodParams.Intolerances}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else if (string.IsNullOrWhiteSpace(FoodParams.Intolerances))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?diet={FoodParams.Diet}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?diet={FoodParams.Diet}&intolerances={FoodParams.Intolerances}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

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

    public async Task<IEnumerable<Food>> GetAll()
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?apiKey=" + ApiKey;

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
