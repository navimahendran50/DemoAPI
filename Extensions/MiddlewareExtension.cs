using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Middlewares;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemoAPI.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
        public static IApplicationBuilder UseDatabaseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DynamicDbContextMiddleware>();
        }
    }
}