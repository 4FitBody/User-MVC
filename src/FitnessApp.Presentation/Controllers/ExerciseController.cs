namespace FitnessApp.Presentation.Controllers;

using FitnessApp.Infrastructure.Exercises.Queries;
using FitnessApp.Presentation.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

public class ExerciseController : Controller
{
    private readonly ISender sender;
    private readonly int limit = 12;

    public ExerciseController(ISender sender) => this.sender = sender;

    [HttpGet]
    [ActionName("Index")]
    [Route("[controller]/Index")]
    [Route("[controller]/Index/{search}")]
    public async Task<IActionResult> GetAll(int offset = 0, string? search = null)
    {   
        await this.AdjustFilter();

        if(search is null)
        {
            var getAllQuery = new GetAllQuery(limit, limit * offset);

            var exercises = await this.sender.Send(getAllQuery);

            var viewModel = new ExercisesViewModel
            {
                Exercises = exercises,
                Offset = offset,
            };

            return base.View(model: viewModel);
        }
        
        var getBySearchQuery = new GetBySearchQuery(search);

        var searchedExercises = await this.sender.Send(getBySearchQuery);

        var searchedViewModel = new ExercisesViewModel
        {
            Exercises = searchedExercises,
            Offset = offset,
        };

        return base.View(model: searchedViewModel);
    }

    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public async Task<IActionResult> Details(string id)
    {
        var query = new GetByIdQuery(id);

        var exercise = await this.sender.Send(query);

        return base.View(model: exercise);
    }

    [HttpGet]
    [Route("[controller]/[action]/{bodyPart}")]
    public async Task<IActionResult> FilterByBodyPart(string bodyPart, int? offset)
    {
        await this.AdjustFilter();

        var query = new GetByBodyPartQuery(bodyPart, limit, limit * offset);

        var exercises = await this.sender.Send(query);

        var viewModel = new ExercisesViewModel
        {
            Exercises = exercises,
            Offset = 0,
        };

        return base.View(viewName: "Index", model: viewModel);
    }

    private async Task AdjustFilter()
    {
        var getBodyParts = new GetBodyPartsQuery();

        var bodyParts = await this.sender.Send(getBodyParts);

        ViewData["bodyParts"] = bodyParts;
    }
}