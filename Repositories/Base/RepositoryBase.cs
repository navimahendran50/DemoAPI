using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Repositories.Base
{
    public abstract class RepositoryBase<TContext> where TContext : DbContext
    {
        protected readonly TContext context;
        public RepositoryBase(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext == null || !httpContextAccessor.HttpContext.Items.ContainsKey("BankDbContext"))
            {
                throw new ArgumentNullException(nameof(httpContextAccessor), "Database context is not available.");
            }

            context = httpContextAccessor.HttpContext.Items["BankDbContext"] as TContext ?? throw new Exception($"{nameof(context)}, Invalid database context.");
        }
    }
}