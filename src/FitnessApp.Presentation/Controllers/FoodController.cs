namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Core.Foods.Models;
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
        var foods = await this.sender.Send(new GetAllQueries());

        return View(foods);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id, string imageUrl)
    {
        var food = await this.sender.Send(new GetByIdQuery(id, imageUrl));

        ViewBag.VideoId = food.VideoId;
        
        return View(food);
    }

    [HttpPost]
    public async Task<IActionResult> GetbyCategory([FromForm] FilterFood foodParams)
    {
        var foods = await this.sender.Send(new GetbyCategoryQueries(foodParams));
        
        return base.View(foods);
    }

    [HttpGet]
    public async Task<IActionResult> GetbyCategory()
    {
        return base.View();
    }
}
