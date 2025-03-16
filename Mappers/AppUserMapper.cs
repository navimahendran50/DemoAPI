using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using DemoAPI.Models;

namespace DemoAPI.Mappers
{
    public static class AppUserMapper
    {
        public static AppUser ToAppUser(this CreateUserDto userDto)
        {
            return new AppUser()
            {
                Email = userDto.Email,
                UserName = userDto.Email
            };
        }
    }
}