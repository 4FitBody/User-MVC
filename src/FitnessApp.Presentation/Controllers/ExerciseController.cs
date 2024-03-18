namespace FitnessApp.Presentation.Controllers;

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

    [ActionName("Index")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllQuery();

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    public async Task<IActionResult> GetByDifficulty(Difficulty difficulty)
    {
        var query = new GetByDifficultyQuery(difficulty);

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    public async Task<IActionResult> GetByMuscleType(MuscleType muscleType)
    {
        var query = new GetByMuscleTypeQuery(muscleType);

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    public async Task<IActionResult> GetByName(string name)
    {
        var query = new GetByNameQuery(name);

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }

    public async Task<IActionResult> GetByType(ExerciseType type)
    {
        var query = new GetByTypeQuery(type);

        var exercises = await this.sender.Send(query);

        return base.View(model: exercises);
    }
    
    [Route("[controller]/[action]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var query = new GetAllQuery();

        var exercises = await this.sender.Send(query);

        var exercise = exercises!.FirstOrDefault(e => e.Name == name);

        return base.View(model: exercise);
    }
}