using MediatR;
using Microsoft.AspNetCore.Identity.Data;

namespace specification.PipelineBehaviors;

public class ExceptionPipelineBehavior<TRequest, TResponse> :IPipelineBehavior<TRequest, TResponse>
{
    private readonly ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> _logger;

    public ExceptionPipelineBehavior(ILogger<ExceptionPipelineBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception e)
        {
            _logger.LogError("Something went wrong!!");
            Console.WriteLine("Error", e.Message);
            throw;
        }    
    }
}