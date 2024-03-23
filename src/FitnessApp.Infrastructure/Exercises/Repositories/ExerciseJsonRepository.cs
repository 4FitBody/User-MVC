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

    public async Task<IEnumerable<Exercise>?> GetAll()
    {
        var uri = "https://exercisedb.p.rapidapi.com/exercises?limit=2000";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByBodyPart(string? bodyPart)
    {
        var uri = $"https://exercisedb.p.rapidapi.com/exercises/bodyPart/{bodyPart}?limit=2000";

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
}