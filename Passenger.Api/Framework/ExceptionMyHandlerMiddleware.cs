using System.Net;
using Newtonsoft.Json;
using Passenger.Infrastructure.Exceptions;

namespace Passenger.Api.Framework
{
    public class ExceptionMyHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMyHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var errorCode = "error";
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionType = exception.GetType();
            
            switch (exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                //custom
                case ServiceException e when exceptionType == typeof(ServiceException):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Code;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = new { code = errorCode, message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)statusCode;
            return httpContext.Response.WriteAsync(payload);
        }
    }
}
