namespace FitnessApp.Infrastructure.Food.Repositories;

using System.Text.Json;
using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;
using FitnessApp.Infrastructure.Food.Repositories.Base;
using PexelsDotNetSDK.Models;

public class FoodRepository : IFoodRepository
{
    public readonly string ApiKey;

    int limit = 9;

    public FoodRepository(string apiKey)
    {
        this.ApiKey = apiKey;
    }

    public async Task<AllFood> GetByCategory(FilterFood? FoodParams, int offset)
    {
        string apiUrl = string.Empty;

        if (FoodParams.Diet.Contains("Omnivore") && string.IsNullOrWhiteSpace(FoodParams.Intolerances))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?number=99&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else if (FoodParams.Diet.Contains("Omnivore"))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?number=99&intolerances={FoodParams.Intolerances}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else if (string.IsNullOrWhiteSpace(FoodParams.Intolerances))
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?number=99&diet={FoodParams.Diet}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
        }

        else
        {
            apiUrl = @$"https://api.spoonacular.com/recipes/complexSearch?number=99&diet={FoodParams.Diet}&intolerances={FoodParams.Intolerances}&query={FoodParams.FoodType}&minProtein={FoodParams.MinProtein}&maxProtein={FoodParams.MaxProtein}&minCalories={FoodParams.MinCalories}&maxCalories={FoodParams.MaxCalories}&apiKey=" + ApiKey;
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

        recipes.Foods = recipes.Foods.Skip(offset * this.limit).Take(limit).ToList();

        return recipes;
    }

    public async Task<AllFood> GetAll(int offset = 1)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?number=99&apiKey=" + ApiKey;

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

        recipes.Foods = recipes.Foods.Skip(offset * this.limit).Take(limit).ToList();

        return recipes;
    }

    public async Task<AllFood> Search(string query, int offset)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?number=99&query={query}&apiKey=" + ApiKey;

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

        recipes.Foods = recipes.Foods.Skip(offset * this.limit).Take(limit).ToList();

        return recipes;
    }

    public async Task<string> GetWidget(int? id)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/{id}/nutritionWidget?defaultCss=true&apiKey=" + ApiKey;

        string value = string.Empty;

        using var client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            value = await response.Content.ReadAsStringAsync();
        }

        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return value;
    }

    public async Task<string> GetIngredients(int? id)
    {
        string apiUrl = $"https://api.spoonacular.com/recipes/{id}/ingredientWidget?defaultCss=true&apiKey=" + ApiKey;

        string value = string.Empty;

        using var client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            value = await response.Content.ReadAsStringAsync();
        }

        else
        {
            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        return value;
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
