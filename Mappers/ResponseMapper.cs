using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Mappers
{
    public static class ResponseMapper
    {
        public static ResponseDto<T> ToResponse<T>(int statusCode, string message, T data)
        {
            return new ResponseDto<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };
        }

        public static IActionResult ToResponse<T>(this IActionResult actionResult, string message, T data)
        {
            int statusCode = actionResult switch
            {
                OkResult => StatusCodes.Status200OK,
                NotFoundResult => StatusCodes.Status404NotFound,
                BadRequestResult => StatusCodes.Status400BadRequest,
                UnauthorizedResult => StatusCodes.Status401Unauthorized,
                ForbidResult => StatusCodes.Status403Forbidden,
                ObjectResult objectResult when objectResult.StatusCode.HasValue => objectResult.StatusCode.Value,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = new ResponseDto<T>()
            {
                StatusCode = statusCode,
                Message = message,
                Data = data
            };

            return new ObjectResult(response) { StatusCode = statusCode };
        }
    }
}