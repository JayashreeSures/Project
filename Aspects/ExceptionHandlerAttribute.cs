using Cake_palace.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cake_palace.Aspects
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();
            var message = context.Exception.Message;

            if (exceptionType == typeof(CartNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(CategoryNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(NoItemsInCartException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(OrderNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(ProductNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(UserNotFoundException))
            {
                var result = new NotFoundObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(InvalidCredentialsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }

            else if (exceptionType == typeof(UserAlreadyExistsException))
            {
                var result = new ConflictObjectResult(message);
                context.Result = result;
            }
            else
            {
                var result = new StatusCodeResult(500);
                context.Result = result;
            }
        }
    }

}
