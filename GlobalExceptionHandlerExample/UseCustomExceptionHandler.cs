using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace GlobalExceptionHandlerExample
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(cfg =>
            {
                cfg.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = new { StatusCode = statusCode, Message = exceptionFeature.Error.Message };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }

    //public static class UseCustomExceptionHandler
    //{
    //    public static void UseCustomException(this IApplicationBuilder app)
    //    {
    //        app.UseExceptionHandler(cfg =>
    //        {
    //            cfg.Run(async context =>
    //            {
    //                context.Response.ContentType = "application/json";
    //                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
    //                var statusCode = 500;
    //                context.Response.StatusCode = statusCode;
    //                var response = new { StatusCode = statusCode, Message = exceptionFeature.Error.Message };
    //                await context.Response.WriteAsync(JsonSerializer.Serialize(response));

    //            });
    //        });
    //    }
    //}
}
