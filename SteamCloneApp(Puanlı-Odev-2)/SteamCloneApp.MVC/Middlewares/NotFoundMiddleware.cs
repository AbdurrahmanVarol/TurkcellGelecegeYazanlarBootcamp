using Microsoft.AspNetCore.Http;
using System.Net;

namespace SteamCloneApp.MVC.Middlewares
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            var statusCode = context.Response.StatusCode;

            if (statusCode == 404)
            {
                context.Response.Redirect("/home/notfoundpage");
            }
        }
    }
}
