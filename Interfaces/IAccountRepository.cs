using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoAPI.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterUserAsync(AppUser userDto, string password, CancellationToken cancellationToken);
    }
}