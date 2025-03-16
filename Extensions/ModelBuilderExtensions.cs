using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder SeedRoles(this ModelBuilder builder)
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole { Id = "b49f2e5b-4d8e-48eb-84fa-5e688f589a66", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "a3c1e3d6-81d7-4d94-a3f7-0d5a9ef54f51", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "d7f8c5ad-7b8b-4691-a21f-fc68238f9cfb", Name = "Manager", NormalizedName = "MANAGER" }
            };

            builder.Entity<IdentityRole>().HasData(roles);
            return builder;
        }
    }
}