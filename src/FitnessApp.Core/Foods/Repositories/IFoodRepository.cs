namespace FitnessApp.Infrastructure.Food.Repositories.Base;

using FitnessApp.Core.Foods;
using FitnessApp.Core.Foods.Models;

public interface IFoodRepository
{
    public Task<AllFood> GetByCategory(FilterFood? FoodParams, int offset);

    public Task<Food> GetById(int? id);

    public Task<AllFood> GetAll(int offset);

    public Task<string> GetWidget(int? id);

    public Task<string> GetIngredients(int? id);

    public Task<AllFood> Search(string query, int offset);
}
