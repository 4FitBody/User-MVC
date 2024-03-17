namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Food.Queries;
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
        var foods = await this.sender.Send(new GetbyCategoryQueries());

        return View(foods);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id, string imageUrl)
    {
        var foods = await this.sender.Send(new GetByIdQuery(id, imageUrl));

        return View(foods);
    }

    [HttpGet]
    [Route("[controller]/[action]/{foodCategory}")]
    public async Task<IActionResult> GetbyCategory(string foodCategory)
    {
        var foods = await this.sender.Send(new GetbyCategoryQueries($"{foodCategory}"));
        
        return base.View(foods);
    }
}
