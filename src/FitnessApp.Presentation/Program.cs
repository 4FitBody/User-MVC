using System.Reflection;
using FitnessApp.Core.Users.Models;
using FitnessApp.Infrastructure.Data;
using FitnessApp.Infrastructure.Food.Repositories;
using FitnessApp.Infrastructure.Food.Repositories.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var infrastructureAssembly = typeof(FitnessAppDbContext).Assembly;

builder.Services.AddMediatR(configurations => {
    configurations.RegisterServicesFromAssembly(infrastructureAssembly);
});

builder.Services.AddScoped<IFoodRepository>(provider=>{
    const string key = "FoodAPIKey";

    var APIkey = builder.Configuration.GetSection(key).Get<string>();

    return new FoodRepository(APIkey);
});

builder.Services.AddScoped<IImageRepository>(provider=>{
    const string key = "ImageAPIKey";

    var APIkey = builder.Configuration.GetSection(key).Get<string>();

    return new ImageRepository(APIkey);
});

builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("FitnessDb");

builder.Services.AddDbContext<FitnessAppDbContext>(dbContextOptionsBuilder =>
{
    dbContextOptionsBuilder.UseNpgsql(connectionString, o => 
    {
        o.MigrationsAssembly("FitnessApp.Presentation");
    });
});

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
})
    .AddEntityFrameworkStores<FitnessAppDbContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Main}/{id?}");

app.Run();