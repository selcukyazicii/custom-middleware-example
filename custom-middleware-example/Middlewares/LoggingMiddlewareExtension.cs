using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace custom_middleware_example.Middlewares
{
    public static class LoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseLogging(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
