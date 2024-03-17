namespace FitnessApp.Infrastructure.Food.Repositories.Base;

using FitnessApp.Core.Foods;

public interface IFoodRepository
{
    public Task<IEnumerable<Food>> GetByCategory(string foodName);
    
    public Task<Food> GetById(int id);
}
