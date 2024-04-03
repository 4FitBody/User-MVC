namespace FitnessApp.Presentation.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Presentation.Models;
using Microsoft.AspNetCore.Authorization;

[AllowAnonymous]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return base.View();
    }

    [HttpGet]
    public IActionResult AboutUs()
    {
        return base.View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
