using FitnessApp.Core.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Data;

public class FitnessAppDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { }
}