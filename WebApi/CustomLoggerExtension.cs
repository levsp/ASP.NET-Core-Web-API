using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Middlewares;

namespace WebApi
{
    public static class CustomLoggerExtension
    {
        public static IApplicationBuilder UseCustomLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
