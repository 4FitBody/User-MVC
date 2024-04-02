using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Core.Services;
using FitnessApp.Core.Users.Models;
using FitnessApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly FitnessAppDbContext dbContext;

        private readonly UserManager<User> userManager;
        public UserService( UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            var oldUser = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);

            oldUser.UserName = user.UserName;

            oldUser.Email = user.Email;

            oldUser.Surname = user.Surname;

            oldUser.Age = user.Age;

            await dbContext.SaveChangesAsync();
        }
    }
}