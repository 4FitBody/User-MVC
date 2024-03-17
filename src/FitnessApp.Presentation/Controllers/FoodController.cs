namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Food.Handlers.GetbyCategory;
using FitnessApp.Infrastructure.Food.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// [Authorize]
public class FoodController : Controller
{
    private readonly ISender sender;

    public FoodController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var foods = await this.sender.Send(new GetbyCategoryCommand());
        Dictionary<string, string> imageNames = new Dictionary<string, string>();
        foreach (var r in foods)
        {
            imageNames.Add(r.Title, await GetImageforFood.GetImage(r.Title));
        }
        return View(imageNames);
    }

    [HttpGet]
    [Route("[controller]/[action]/{foodCategory}")]
    public async Task<IActionResult> GetbyCategory(string foodCategory)
    {
        var foods = await this.sender.Send(new GetbyCategoryCommand($"{foodCategory}"));
        Dictionary<string, string> imageNames = new Dictionary<string, string>();
        foreach (var r in foods)
        {
            imageNames.Add(r.Title, await GetImageforFood.GetImage(r.Title));
        }
        return base.View(imageNames);
    }
}
