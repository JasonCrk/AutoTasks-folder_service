using Domain.Exceptions;

using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class IsAuthFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("X-User-Id"))
            {
                throw new UnauthorizedException();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}