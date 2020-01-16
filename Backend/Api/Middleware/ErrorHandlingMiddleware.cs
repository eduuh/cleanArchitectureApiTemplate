using System.Net;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Application.Errors;
using Newtonsoft.Json;

namespace Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logging;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logging)
        {
            _next = next;
            _logging = logging;
        }

        public async Task Invoke(HttpContext context){
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                
                await HandleExceptionAsync(context,ex,_logging);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex,
         ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;

            switch (ex){
                case RestException re:
                 logger.LogError(ex, "Rest Error");
                 errors = re.Errors;
                 context.Response.StatusCode = (int)re.Code;
                 break;
                case Exception e:
                 logger.LogError(ex,"Server Error");
                 errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                 break;
            }
            context.Response.ContentType = "application/json";
            if(errors!=null){
                var result = JsonConvert.SerializeObject(new {
                    errors
                });
                
                await context.Response.WriteAsync(result);
            }
        }
    }
}