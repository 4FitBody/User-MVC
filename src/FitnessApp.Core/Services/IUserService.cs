using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Core.Users.Models;

namespace FitnessApp.Core.Services
{
    public interface IUserService
    {
        public Task UpdateUserAsync(string id, User user);

    }
}