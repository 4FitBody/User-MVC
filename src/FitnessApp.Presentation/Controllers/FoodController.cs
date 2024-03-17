namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Food.Handlers.GetbyCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
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
        return View(foods);
    }

    [HttpGet]
    [Route("[controller]/[action]/{foodCategory}")]
    public async Task<IActionResult> GetbyCategory(string foodCategory)
    {
        var foods = await this.sender.Send(new GetbyCategoryCommand($"{foodCategory}"));
        return base.View(foods);
    }
}
