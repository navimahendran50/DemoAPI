using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Interfaces;
using DemoAPI.Mappers;
using DemoAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace DemoAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        public async Task<IdentityResult> RegisterUserAsync(CreateUserDto userDto, CancellationToken cancellationToken)
        {
            if (userDto == null)
            {
                throw new ArgumentNullException(nameof(userDto));
            }
            return await accountRepository.RegisterUserAsync(userDto.ToAppUser(), userDto.Password, cancellationToken);
        }
    }
}