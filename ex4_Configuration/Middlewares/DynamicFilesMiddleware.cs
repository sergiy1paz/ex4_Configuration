using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ex4_Configuration.Services.Interfaces;

using System.IO;

namespace ex4_Configuration
{
    public class DynamicFilesMiddleware
    {
        private readonly RequestDelegate _next;

        public DynamicFilesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IDynamicFilesService filesService)
        {
            if (context.Request.Path == "/upgradefiles")
            {
                await filesService.CreateAndWrite();
            } else if (context.Request.Path == "/deletefiles")
            {
                await filesService.Remove();
            }
            else
            {
                await _next.Invoke(context);
            }
        } 
    }
}
