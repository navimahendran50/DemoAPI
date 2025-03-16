using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Interfaces;
using DemoAPI.Mappers;
using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto customer)
        {
            var result = await customerService.CreateCustomerAsync(customer);
            //return Ok(ResponseMapper.ToResponse(200, "Customer Created", result));
            return Ok().ToResponse("Customer Created Successfully", result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await customerService.GetCustomerAsync(id);
            if(customer == null)
            {
                return NotFound().ToResponse($"Customer not found with given {id} id", default(Customer)!);
            }
            return Ok().ToResponse("Success", customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await customerService.GetCustomersAsync();
            return Ok().ToResponse("Success", customers!);
        }
    }
}