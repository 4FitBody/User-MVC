namespace FitnessApp.Infrastructure.Food.Repositories.Base;

using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;

public interface IFoodRepository
{
    public Task<IEnumerable<Food>> GetByCategory(FilterFood? FoodParams);

    public Task<Food> GetById(int? id);

    public Task<IEnumerable<Food>> GetAll();

    public Task<string> GetWidget(int? id);

    public Task<string> GetIngredients(int? id);

    public Task<IEnumerable<Food>> Search(string query);
}
