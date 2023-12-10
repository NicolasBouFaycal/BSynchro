using System.Text;
using System.Text.Json;

namespace BSynchro.API.Middlewares
{
    public class CheckRequestMiddleWare
    {
        private readonly RequestDelegate _next;
        public CheckRequestMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;
            if (path.StartsWithSegments("/api/Accounts/UserInfo"))
            {
                string customerId = context.Request.Query["customerId"];

                if (string.IsNullOrEmpty(customerId))
                {
                    var okResponse = new
                    {
                        message = "Missing Customer id"
                    };

                    string jsonResponse = JsonSerializer.Serialize(okResponse);

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status200OK;

                    await context.Response.WriteAsync(jsonResponse);
                    return;
                }

                await _next(context);

            }
            if (path.StartsWithSegments("/api/Accounts/OpenAccount"))
            {
                if (context.Request.ContentLength.HasValue && context.Request.ContentLength > 0 &&
            !string.IsNullOrEmpty(context.Request.ContentType))
                {

                    await _next(context);
                }
                else
                {
                    var okResponse = new
                    {
                        message = "Missing Account Data"
                    };

                    string jsonResponse = JsonSerializer.Serialize(okResponse);

                    context.Response.ContentType = "application/json";
                    context.Response.StatusCode = StatusCodes.Status200OK;

                    await context.Response.WriteAsync(jsonResponse);
                    return;
                }
            }
        }
    }
}
