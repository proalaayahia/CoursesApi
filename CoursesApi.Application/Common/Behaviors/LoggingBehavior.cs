using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CoursesApi.Application.Common.Behaviors;
public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> logger;
    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string requestName = typeof(TRequest).Name;
        string unqiueId = Guid.NewGuid().ToString();
        string requestJson = JsonSerializer.Serialize(request);
        logger.LogInformation($"Begin Request Id:{unqiueId}, request name:{requestName}, request json:{requestJson}");
        var timer = new Stopwatch();
        timer.Start();
        var response = await next();
        timer.Stop();
        logger.LogInformation($"End Request Id:{unqiueId}, request name:{requestName}, total request time:{timer.ElapsedMilliseconds}ms");
        return response;
    }
}