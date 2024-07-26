using MediatR;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Caching.Memory;

namespace specification.PipelineBehaviors;

public class CachingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CachingPipelineBehavior<TRequest, TResponse>> _logger;

    public CachingPipelineBehavior(IMemoryCache cache, ILogger<CachingPipelineBehavior<TRequest, TResponse>> logger)
    {
        _cache = cache;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var cacheKey = GenerateCacheKy(request);
        if (_cache.TryGetValue(cacheKey, out TResponse cachedResponse))
        {
            return cachedResponse;
        }

        var response = await next();
        var cacheOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            Size = 288
        };
        _cache.Set(cacheKey, response, cacheOptions);

        return response;
    }

    private string GenerateCacheKy(TRequest request)
    {
        return $"{typeof(TRequest).Name}:{System.Text.Json.JsonSerializer.Serialize(request)}";
    }
}