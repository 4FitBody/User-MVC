
using System.Net;
using System.Security.Claims;
using FitnessApp.Core.Dtos;
using FitnessApp.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace FinanceApp.Presentation.Controllers;
public class IdentityController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly SignInManager<User> signInManager;

    public IdentityController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;

        this.roleManager = roleManager;

        this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto userDto)
    {
        if (ModelState.IsValid == false)
        {
            return View();
        }

        var user = new User
        {
            UserName = userDto.Name,
            Surname = userDto.Surname,
            Age = userDto.Age,
            Email = userDto.Email,

        };

        var result = await userManager.CreateAsync(user, userDto.Password);

        if (!result.Succeeded)
        {

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            if (ModelState.Any())
            {
                return View();
            }

        }

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto userdto)
    {
        if (ModelState.IsValid == false)
        {
            return View();
        }

        var user = await userManager.FindByEmailAsync(userdto.Email);

        if (user is null)
        {
            ViewData.Add("Error", "No user with this email found");
            return View();
        }

        var result = await signInManager.PasswordSignInAsync(user, userdto.Password, true, true);

        if (result.Succeeded == false)
        {
            ViewData.Add("Error", "Incorrect Credentials");
            return View();
        }

        return base.RedirectToAction("Home");

    }
}