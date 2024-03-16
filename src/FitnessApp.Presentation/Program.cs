using System.Reflection;
using FitnessApp.Core.Users.Models;
using FitnessApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(configurations => {
    configurations.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
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