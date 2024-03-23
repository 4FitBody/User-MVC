namespace FitnessApp.Presentation.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;

[AllowAnonymous]
public class HomeController : Controller
{
    [HttpGet]
    [Authorize]
    public IActionResult Index()
    {
        return base.View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
