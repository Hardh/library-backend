using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;

namespace library_backend.Controllers;

public static class ErrorHandlingExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
            var exceptionDetails = context.Features.Get<IExceptionHandlerFeature>();
            var exception = exceptionDetails?.Error;
            logger.LogError(
                exception, 
                "Error on request in machine {Machine}. TraceId: {TraceId}", 
                Environment.MachineName, 
                Activity.Current?.Id
            );
            await Results.Problem(
                title: "Error  ",
                statusCode: StatusCodes.Status500InternalServerError,
                extensions: new Dictionary<string, object?>
                {
                    { "traceId", Activity.Current?.Id }
                }
            ).ExecuteAsync(context);
       });
    }
}