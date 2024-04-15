namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Food.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class FoodController : Controller
{
    private readonly ISender sender;

    public FoodController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ActionName("Index")]
    public async Task<IActionResult> GetAll()
    {
        var getAllQuery = new GetAllQuery();

        var food = await this.sender.Send(getAllQuery);

        return base.View(model: food);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var getByIdQuery = new GetByIdQuery(id);

        var food = await this.sender.Send(getByIdQuery);

        return View(food);
    }
}
