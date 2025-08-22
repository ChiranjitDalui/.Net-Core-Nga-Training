using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace EmployeesManagement.Filters
{
   public class ProductCacheResourceFilter : IResourceFilter
    {
        private readonly IMemoryCache _cache;
        public ProductCacheResourceFilter(IMemoryCache cache) {
            _cache = cache;
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var key = context.HttpContext.Request.Path.ToString();
            // The request path (e.g., "/api/products") is used as the cache key.

            if (_cache.TryGetValue<string>(key, out var cached))// In this we are storing data before the action executes.
            {
                context.Result = new ContentResult { Content = cached, ContentType = "text/plain" };
            }
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var key = context.HttpContext.Request.Path.ToString();
            if (context.Result is ContentResult cr)//
            {
                if(cr.Content == null)
                {
                    Console.WriteLine("Response content is null, not caching.");
                    return; // If the content is null, we do not cache it.
                }
                // _cache.Set(key, cr.Content!, TimeSpan.FromSeconds(20)); 
                _cache.Set(key, cr.Content, TimeSpan.FromSeconds(20));
                // // Here we are caching the data after the action executes. also the time
            }
        }
    }
}