using System;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using UnluCoProductCatalog.Application.Exceptions;
using UnluCoProductCatalog.Application.Interfaces.LogInterfaces;


namespace WebAPI.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly ILoggerService _loggerService;
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(ILoggerService loggerService, RequestDelegate next)
        {
            _loggerService = loggerService;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            var watch = Stopwatch.StartNew();
            try
            {
                await _next(context);
                watch.Stop();

            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            string message = "[Error]   HTTP " + context.Request.Method + " - " + context.Response.StatusCode +
                             " Error Message : " + ex.Message
                             + " in " + watch.Elapsed.TotalMilliseconds+" ms";
            _loggerService.Log(message);

            switch (ex)
            {
                case NotFoundExceptions e:
                    response.StatusCode = (int) HttpStatusCode.NotFound;
                    break;
                case NotSavedExceptions e:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case InvalidOperationException e:
                    response.StatusCode = (int) HttpStatusCode.BadRequest;
                    break;
                default:
                    response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    break;
            }
            var result =JsonConvert.SerializeObject(new { message = ex?.Message });
           return context.Response.WriteAsync(result);
        }
    }
    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomeExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
