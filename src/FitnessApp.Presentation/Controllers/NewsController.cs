namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.News.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class NewsController : Controller
{
    private readonly ISender sender;

    public NewsController(ISender sender)
    {
        this.sender = sender;
    }

    [HttpGet]
    [ActionName("Index")]
    public async Task<IActionResult> GetAll()
    {
        var getAllQuery = new GetAllQuery();

        var news = await this.sender.Send(getAllQuery);

        return base.View(model: news);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        var getByIdQuery = new GetByIdQuery(id);

        var news = await this.sender.Send(getByIdQuery);

        return base.View(model: news);
    }
}