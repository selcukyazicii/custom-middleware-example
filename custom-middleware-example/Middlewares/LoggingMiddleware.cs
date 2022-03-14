using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace custom_middleware_example.Middlewares
{
    public class LoggingMiddleware
    {
        readonly RequestDelegate _requestDelegate;
        public LoggingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            finally 
            {
                string logText = $"{context.Request?.Method}{context.Request?.Path.Value}=>{context.Response?.StatusCode}" +
                    $"{Environment.NewLine}";
                File.AppendAllText("log.txt", logText);
            }
        }
    }
}
