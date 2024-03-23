namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ExerciseController : Controller
{
    private readonly ISender sender;

    public ExerciseController(ISender sender) => this.sender = sender;

    [ActionName("Index")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    [HttpGet]
    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetByNameQuery(name);

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public async Task<IActionResult> Details(string id)
    {
        var query = new GetByIdQuery(id);

        var exercise = await this.sender.Send(query);

        return base.View(model: exercise);
    }
}