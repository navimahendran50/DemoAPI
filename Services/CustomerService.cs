using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Interfaces;
using DemoAPI.Mappers;
using DemoAPI.Models;

namespace DemoAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public Task<Customer> CreateCustomerAsync(CreateCustomerDto customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            return customerRepository.CreateCustomerAsync(customer.ToCustomer());
        }

        public async Task<Customer?> GetCustomerAsync(Guid id)
        {
            return await customerRepository.GetCustomerAsync(id);
        }

        public async Task<IEnumerable<Customer?>> GetCustomersAsync()
        {
            return await customerRepository.GetCustomersAsync();
        }
    }
}