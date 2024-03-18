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
        var uri = "https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByDifficulty(Difficulty? difficulty)
    {
        var exerciseDifficulty = difficulty.ToString()!.ToLower();

        var uri = $"https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises?difficulty={exerciseDifficulty}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByMuscleType(MuscleType? muscleType)
    {
        var exerciseMuscleType = muscleType.ToString()!.ToLower();

        var uri = $"https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises?muscle={exerciseMuscleType}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByName(string? name)
    {
        var exerciseName = name!.ToString().ToLower();

        var uri = $"https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises?name={exerciseName}";

        var request = this.CreateRequest(HttpMethod.Get, uri);

        var exercises = await this.GetExercises(request);

        return exercises;
    }

    public async Task<IEnumerable<Exercise>?> GetByType(ExerciseType? type)
    {
        var exerciseType = type.ToString()!.ToLower();

        var uri = $"https://exercises-by-api-ninjas.p.rapidapi.com/v1/exercises?difficulty={exerciseType}";

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
}