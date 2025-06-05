using Intranet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Portal.Services;

public class PortalTextService
{
    private readonly IntranetContext _context;
    private readonly IMemoryCache _cache;

    public PortalTextService(IntranetContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public string Get(string key)
    {
        var cacheKey = $"PortalText-{key}";
        if (!_cache.TryGetValue(cacheKey, out string? value))
        {
            var text = _context.PortalTexts
                .AsNoTracking()
                .FirstOrDefault(t => t.Key == key);
            value = text?.Value ?? key;
            _cache.Set(cacheKey, value, TimeSpan.FromMinutes(10));
        }
        return value;
    }
}
