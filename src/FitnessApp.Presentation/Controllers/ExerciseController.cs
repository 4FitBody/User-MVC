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
    private IEnumerable<Exercise?>? searchedExercises;

    public ExerciseController(ISender sender) => this.sender = sender;

    [HttpGet]
    [ActionName("Index")]
    [Route("[controller]/Index")]
    [Route("[controller]/Index/{search}")]
    public async Task<IActionResult> GetAll(string? search)
    {
        var query = new GetAllQuery();

        var exercises = await this.sender.Send(query);
        
        if(search is null)
        {
            return base.View(model: exercises);
        }
        
        search = search.ToLower();

        searchedExercises = exercises!.Where(exercise => 
        exercise.Name!.ToLower().Contains(search)
        || exercise.BodyPart!.ToLower().Contains(search) 
        || exercise.Target!.ToLower().Contains(search)
        || exercise.Equipment!.ToLower().Contains(search)
        || search.Contains(exercise.BodyPart!.ToLower())
        || search.Contains(exercise.Target!.ToLower())
        || search.Contains(exercise.Name!.ToLower())
        || search.Contains(exercise.Equipment!.ToLower()));
        
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
}