using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using DemoAPI.Data;
using DemoAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Middlewares
{
    public class DynamicDbContextMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly ILogger<DynamicDbContextMiddleware> logger;
        public DynamicDbContextMiddleware(RequestDelegate next, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory, ILogger<DynamicDbContextMiddleware> logger)
        {
            this.next = next;
            this.configuration = configuration;
            this.serviceScopeFactory = serviceScopeFactory;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? connectionString = null;
            string requestPath = context.Request.Path.Value ?? string.Empty;

            if (requestPath.StartsWith("/api/account", StringComparison.OrdinalIgnoreCase))
            {
                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                if (context.Request.Headers.TryGetValue("bankCode", out var bankCode))
                {
                    logger.LogInformation("Bank Code: {0}", bankCode!);
                    var dynamicConnectionString = configuration.GetConnectionString(bankCode!);

                    if (!string.IsNullOrEmpty(dynamicConnectionString))
                    {
                        connectionString = dynamicConnectionString;
                    }
                    else
                    {
                        logger.LogWarning("No connection string found for Bank Code: {0}", bankCode!);
                        await HandleInvalidBankCodeResponse(context, Guid.NewGuid().ToString(), $"Invalid bankCode: {bankCode}");
                        return;
                    }
                }
                else
                {
                    logger.LogWarning("Missing bankCode in request headers.");
                    await HandleInvalidBankCodeResponse(context, Guid.NewGuid().ToString(), "bankCode header is required for this request.");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
                using var scope = serviceScopeFactory.CreateScope();
                var optionsBuilder = new DbContextOptionsBuilder<BankDbContext>();
                optionsBuilder.UseSqlite(connectionString);
                var dbContext = new BankDbContext(optionsBuilder.Options);

                context.Items["BankDbContext"] = dbContext;
            }

            await next(context);
        }

        private static Task HandleInvalidBankCodeResponse(HttpContext context, string errorId, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var result = new
            {
                StatusCode = context.Response.StatusCode,
                ErrorId = errorId,
                ErrorMessage = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}