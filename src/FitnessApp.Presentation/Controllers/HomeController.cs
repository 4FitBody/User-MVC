using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Presentation.Models;

namespace FitnessApp.Presentation.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return base.View();
    }

    [HttpGet]
    public IActionResult Main()
    {
        return base.View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
