namespace FitnessApp.Core.Foods.Repositories;

public interface IVideoRepository
{
    public Task<string> GetVideo(string foodName);
}
