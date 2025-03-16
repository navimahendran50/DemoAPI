using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Common;
using DemoAPI.Data;
using DemoAPI.Interfaces;
using DemoAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountRepository(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IdentityResult> RegisterUserAsync(AppUser userDto, string password, CancellationToken cancellationToken)
        {
            try
            {
                using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
                var result = await userManager.CreateAsync(userDto, password);
                if (!result.Succeeded)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return result;
                }

                if (!await roleManager.RoleExistsAsync(Roles.DEFAULT_USER))
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return IdentityResult.Failed(new IdentityError { Code = nameof(Roles.DEFAULT_USER), Description = "Default user role does not exist.!" });
                }

                var roleResult = await userManager.AddToRoleAsync(userDto, Roles.DEFAULT_USER);
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    return roleResult;
                }

                await transaction.CommitAsync(cancellationToken);
                return IdentityResult.Success;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Error during registration: {ex.Message}");
                throw;
            }
        }
    }
}