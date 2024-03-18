namespace FinanceApp.Presentation.Controllers;

using FitnessApp.Core.Users.Models;
using FitnessApp.Presentation.Users.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
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
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return base.RedirectToAction("Main", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return base.View();
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.Name,
            Surname = registerDto.Surname,
            Age = registerDto.Age,
            Email = registerDto.Email,
        };

        var result = await userManager.CreateAsync(user, registerDto.Password!);

        if (!result.Succeeded)
        {
            AddErrorsToModelState(result.Errors);

            return base.View("Register");
        }

        return base.RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return base.View();
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
    {
        try
        {
            var user = await this.userManager.FindByEmailAsync(loginDto.Email!);

            await this.signInManager.PasswordSignInAsync(user!, loginDto.Password!, true, true);
        }
        catch (Exception exception)
        {
            base.ModelState.AddModelError(exception.GetType().Name, "Invalid Login or Password");

            return base.View("Login");
        }

        return base.RedirectToAction(actionName: "Index", controllerName: "Home");
    }

    private void AddErrorsToModelState(IEnumerable<IdentityError> errors)
    {
        foreach (var error in errors)
        {
            base.ModelState.AddModelError(error.Code, error.Description);
        }
    }
}