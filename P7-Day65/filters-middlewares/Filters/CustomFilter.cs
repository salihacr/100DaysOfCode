using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters_And_Middleware.Filters
{
    public class CustomFilter : Attribute, IActionFilter
    {
        // Aksiyondan once calisan kod blogu
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int i = 10;
        }
        // aksiyondan sonra calisacak olan kod blogu
        public void OnActionExecuted(ActionExecutedContext context)
        {
            int i = 20;
        }
    }
}
