namespace FitnessApp.Infrastructure.Food.Repositories.Base;

using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;

public interface IFoodRepository
{
    public Task<IEnumerable<Food>> GetByCategory(FilterFood? FoodParams);
    
    public Task<Food> GetById(int? id);

    public Task<IEnumerable<Food>> GetAll();
}
