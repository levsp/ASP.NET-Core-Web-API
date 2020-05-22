using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WebApiLogger;

namespace WebApi.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerWebApi _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILoggerWebApi logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();

            // Leave the body open so the next middleware can read it.
            using (var reader = new StreamReader(
                context.Request.Body,
                encoding: Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 1024,
                leaveOpen: true))
            {
                var body = await reader.ReadToEndAsync();
                _logger.LogInfo("**Handling request: " + body + "**");

                // Reset the request body stream position so the next middleware can read it
                context.Request.Body.Position = 0;
            }

            // Call the next delegate/middleware in the pipeline
            await _next.Invoke(context);
        }

    }
}
