using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Interfaces;
using DemoAPI.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> logger;
        private readonly IAccountService accountService;
        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            this.logger = logger;
            this.accountService = accountService;
        }

        [HttpPost("register")]  
        public async Task<IActionResult> Register([FromBody] CreateUserDto request, CancellationToken cancellationToken)
        {
            var result = await accountService.RegisterUserAsync(request, cancellationToken);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok().ToResponse("Success", result);
        }
    }
}