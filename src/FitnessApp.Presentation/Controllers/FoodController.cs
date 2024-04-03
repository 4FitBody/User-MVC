namespace FitnessApp.Presentation.Controllers;

using System.Runtime.InteropServices;
using FitnessApp.Core.Foods;
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
    [Route("[controller]/[action]")]
    [Route("[controller]/[action]/{query}")]
    public async Task<IActionResult> Get(string? query, int offset = 0)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            var foods = await this.sender.Send(new GetAllQueries(offset));

            foods.Offset = offset;

            return View(foods);
        }

        var Allfoods = await this.sender.Send(new SearchQueries(query,offset));

        Allfoods.Offset = offset;

        return View(Allfoods);
    }


    [HttpGet]
    public async Task<IActionResult> GetById(int id, string imageUrl)
    {
        var food = await this.sender.Send(new GetByIdQuery(id, imageUrl));

        string htmlResponse = await this.sender.Send(new GetIngredientsQueries(id));

        ViewBag.HtmlResponse = htmlResponse;

        ViewBag.VideoId = food.VideoId;

        return View(food);
    }

    [HttpPost]
    public async Task<IActionResult> Get([FromForm] FilterFood foodParams,int offset = 0)
    {
        var foods = await this.sender.Send(new GetbyCategoryQueries(foodParams,offset));

        return base.View(foods);
    }

    [HttpGet]
    public async Task<IActionResult> GetWidget(int id)
    {
        return base.Content(await this.sender.Send(new GetWidgetQueries(id)), "text/html");
    }
}
