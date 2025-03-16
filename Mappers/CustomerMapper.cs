using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Models;

namespace DemoAPI.Mappers
{
    public static class CustomerMapper
    {
        public static Customer ToCustomer(this CreateCustomerDto dto)
        {
            return new Customer()
            {
                Name = dto.Name
            };
        }
    }
}