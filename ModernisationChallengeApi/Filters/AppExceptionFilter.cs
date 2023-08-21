using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ModernisationChallengeApi.Filters;

public class AppExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;

    public AppExceptionFilter(IHostEnvironment hostEnvironment) => _hostEnvironment = hostEnvironment;

    public void OnException(ExceptionContext context)
    {
        if (!_hostEnvironment.IsDevelopment()) return;

        context.Result = new ObjectResult(
            new ProblemDetails
            {
                Title = context.Exception.Message,
                Status = 500,
                Detail = context.Exception.StackTrace
            }
        );

        context.ExceptionHandled = true;
    }
}
