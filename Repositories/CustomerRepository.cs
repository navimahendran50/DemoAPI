using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Data;
using DemoAPI.Interfaces;
using DemoAPI.Models;
using DemoAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Repositories
{
    public class CustomerRepository : RepositoryBase<BankDbContext>, ICustomerRepository
    {        
        public CustomerRepository(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) {}        
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
            var result = await context.SaveChangesAsync();
            return result > 0 ? customer : default!;
        }

        public async Task<Customer?> GetCustomerAsync(Guid id)
        {
            return await context.Customers.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id)!;
        }

        public async Task<IEnumerable<Customer?>> GetCustomersAsync()
        {
            return await context.Customers.AsNoTracking().ToListAsync();
        }
    }
}