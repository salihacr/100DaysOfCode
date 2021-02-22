using Filters_And_Middleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters_And_Middleware.Extensions
{
    public static class Extension
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<HelloMiddleware>();
        }
    }
}
