namespace FitnessApp.Core.Foods.Models;

public class FilterFood
{
    public string FoodType { get; set; }

    public string? Diet { get; set; }

    public string? Intolerances { get; set; }

    public int MinProtein { get; set; }
    public int MaxProtein { get; set; }

    public int MinCalories { get; set; }
    public int MaxCalories { get; set; }
}
