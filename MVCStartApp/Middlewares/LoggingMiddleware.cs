using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using MVCStartApp.Models.DB;
using MVCStartApp.Repositories;

namespace MVCStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogRepository _logRepo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, ILogRepository logRepo)
        {
            _next = next;
            _logRepo = logRepo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogToConsole(context);
            await LogToDB(context);
            await _next.Invoke(context);
        }

        private async Task LogToDB(HttpContext context)
        {
            Request request = new ()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _logRepo.AddLog(request);
        }
        
        private static void LogToConsole(HttpContext context) => Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
    }
}