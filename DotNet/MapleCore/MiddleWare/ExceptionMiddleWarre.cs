using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MapleCore.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ExceptionMiddleWare(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

                if (context.Response.StatusCode != 200)
                {
                    var logger = _loggerFactory.CreateLogger<ExceptionMiddleWare>();
                    logger.LogError($"Invalid response HTTP Status:{context.Response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<ExceptionMiddleWare>();
                logger.LogError($"Exception occured {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var msg = "Something went wrong!!";

            if (exception is ApplicationException)
            {
                msg = exception.Message;
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
            }
            else if (exception is DbUpdateException)
            {
                msg = "Data validation error, either duplicate or invalid entry!!";
                context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
            }
            else
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new
            {
                StatusCode = context.Response.StatusCode,
                Message = msg
            }.ToString());
        }
    }
}
