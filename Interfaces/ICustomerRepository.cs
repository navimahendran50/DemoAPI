using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Models;

namespace DemoAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer?> GetCustomerAsync(Guid id);
        Task<IEnumerable<Customer?>> GetCustomersAsync();
    }
}