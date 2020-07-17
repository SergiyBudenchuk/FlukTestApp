using FlukeTestApp.DomainModels.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlukeTestApp.ExceptionsFilter
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private const int DefaultErrorStatusCode = 500;
        public int Order { get; set; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var handledException = new ObjectResult(context.Exception.Message);

                switch (context.Exception)
                {
                    case ItemNotFoundException e:
                        {
                            handledException.StatusCode = e.StatusCode;
                            break;
                        }
                    default:
                        {
                            handledException.StatusCode = DefaultErrorStatusCode;
                            break;
                        }
                }

                context.Result = handledException;
                context.ExceptionHandled = true;
            }
        }
    }
}