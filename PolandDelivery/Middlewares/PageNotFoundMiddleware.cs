using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolandDelivery.Middlewares
{
    public class PageNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public PageNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 404)
            {
                context.Request.Path = "/Home/Page404";
                await _next.Invoke(context);
            }
        }
    }
}
