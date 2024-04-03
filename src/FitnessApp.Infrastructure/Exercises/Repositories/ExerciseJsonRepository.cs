namespace FitnessApp.Infrastructure.Exercises.Repositories;

using FitnessApp.Core.Exercises.Models;
using FitnessApp.Core.Exercises.Repositories;
using Newtonsoft.Json;

public class ExerciseJsonRepository : IExerciseRepository
{
    private readonly string apiKey;
    private readonly string host;
    private readonly HttpClient client;
    public ExerciseJsonRepository(string apiKey, string host)
    {
        this.apiKey = apiKey;

        this.host = host;

        this.client = new HttpClient();
    }

    public async Task<IEnumerable<Exercise>?> GetAll(int? limit, int? offset)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises?limit={limit}&offset={offset}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var allExercises = await this.GetExercises(request);

        return allExercises!;
    }

    public async Task<IEnumerable<Exercise>?> GetByBodyPart(string? bodyPart, int? limit, int? offset)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/bodyPart/{bodyPart}?limit={limit}&offset={offset}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByEquipment(string? equipment)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/equipment/{equipment}?limit=2000";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<Exercise>? GetById(string? id)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/exercise/{id}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercise = await this.GetExercise(request)!;

        return exercise;
    }

    public async Task<IEnumerable<Exercise>?> GetByName(string? name)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/name/{name}?limit=2000";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByTarget(string? target)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/target/{target}?limit=2000";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<string>?> GetBodyParts()
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/bodyPartList";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var bodyParts = await this.GetBodyParts(request);

        return bodyParts;
    }

    private HttpRequestMessage CreateRequest(HttpMethod httpMethod, string uri)
    {
        var request = new HttpRequestMessage
        {
            Method = httpMethod,
            RequestUri = new Uri(uri),
            Headers =
            {
                { "X-RapidAPI-Key", this.apiKey },
                { "X-RapidAPI-Host", this.host },
            },
        };

        return request;
    }

    private async Task<IEnumerable<Exercise>?> GetExercises(HttpRequestMessage request)
    {
        var exercises = Enumerable.Empty<Exercise>();

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            exercises = JsonConvert.DeserializeObject<IEnumerable<Exercise>>(body);
        }

        return exercises;
    }

    private async Task<IEnumerable<string>?> GetBodyParts(HttpRequestMessage request)
    {
        var bodyParts = Enumerable.Empty<string>();

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            bodyParts = JsonConvert.DeserializeObject<IEnumerable<string>>(body);
        }

        return bodyParts;
    }

    private async Task<Exercise>? GetExercise(HttpRequestMessage request)
    {
        var exercise = new Exercise();

        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            exercise = JsonConvert.DeserializeObject<Exercise>(body);
        }

        return exercise!;
    }

    public async Task<IEnumerable<Exercise?>?> SearchExercises(string search)
    {
        search = search.ToLower();

        var allExercises = await this.GetAll(2000, 0);

        var searchedExercises = allExercises!.Where(exercise => 
        exercise!.Name!.ToLower().Contains(search)
        || exercise.BodyPart!.ToLower().Contains(search) 
        || exercise.Target!.ToLower().Contains(search)
        || exercise.Equipment!.ToLower().Contains(search)
        || search.Contains(exercise.BodyPart!.ToLower())
        || search.Contains(exercise.Target!.ToLower())
        || search.Contains(exercise.Name!.ToLower())
        || search.Contains(exercise.Equipment!.ToLower())).Take(12);

        return searchedExercises;
    }
}