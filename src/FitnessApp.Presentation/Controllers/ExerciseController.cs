namespace FitnessApp.Presentation.Controllers;

using System.Security.Principal;
using FitnessApp.Core.Exercises.Models;
using FitnessApp.Infrastructure.Exercises.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ExerciseController : Controller
{
    private readonly ISender sender;

    public ExerciseController(ISender sender) => this.sender = sender;

    [HttpGet]
    [ActionName("Index")]
    [Route("[controller]/Index")]
    [Route("[controller]/Index/{search}")]
    public async Task<IActionResult> GetAll(string? search)
    {   
        if(search is null)
        {
            var getAllQuery = new GetAllQuery();

            var exercises = await this.sender.Send(getAllQuery);

            return base.View(model: exercises);
        }
        
        var getBySearchQuery = new GetBySearchQuery(search);

        var searchedExercises = await this.sender.Send(getBySearchQuery);
        
        return base.View(model: searchedExercises);
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

    [HttpGet]
    [Route("[controller]/[action]/{bodyPart}")]
    public async Task<IActionResult> FilterByBodyPart(string bodyPart)
    {
        var query = new GetByBodyPartQuery(bodyPart);

        var exercises = await this.sender.Send(query);

        return base.View(viewName: "Index", model: exercises);
    }
}