using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters_And_Middleware.Middlewares
{
    public class HelloMiddleware
    {
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            // Custom operation
            Console.WriteLine("Selamun aleyküm...");
            await _next.Invoke(httpContext);
            Console.WriteLine("Aleyküm selam");
        }

    }
}
