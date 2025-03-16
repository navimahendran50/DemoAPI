using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DemoAPI.Dtos;

namespace DemoAPI.Middlewares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandlerMiddleware> logger;
        public GlobalExceptionHandlerMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (System.Exception e)
            {
                var errorId = Guid.NewGuid().ToString();
                logger.LogError(e, $"Error Id: {errorId} : Exception Message:- ");
                await HandleExceptionAsync(context, errorId);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string errorId)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            ErrorResponse result = new()
            {
                StatusCode = context.Response.StatusCode,
                ErrorId = errorId,
                ErrorMessage = "An error occurred while processing your request. Please contact Administrator (or) try after some time."
            };
            var resultJson = System.Text.Json.JsonSerializer.Serialize(result);
            return context.Response.WriteAsync(resultJson);
        }
    }
}