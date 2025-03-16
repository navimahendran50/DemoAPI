using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoAPI.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(CreateUserDto userDto, CancellationToken cancellationToken);
    }
}