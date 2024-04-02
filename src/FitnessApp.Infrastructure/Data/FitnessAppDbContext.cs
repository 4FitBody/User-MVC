using FitnessApp.Core.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Data;

public class FitnessAppDbContext : IdentityDbContext<User, IdentityRole, string>
{
        public DbSet<User> userServices {get; set;}

    public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { }
}