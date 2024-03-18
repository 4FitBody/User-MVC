namespace FitnessApp.Infrastructure.Food.Repositories.Base;

public interface IImageRepository
{
    public Task<string> GetImage(string foodName);
}
