using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Models;

namespace DemoAPI.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(CreateCustomerDto customer);
        Task<Customer?> GetCustomerAsync(Guid id);
        Task<IEnumerable<Customer?>> GetCustomersAsync();
    }
}