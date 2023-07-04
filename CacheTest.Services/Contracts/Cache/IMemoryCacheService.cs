using Microsoft.Extensions.Caching.Memory;


namespace CacheTest.Services.Contracts.Cache
{
     public interface IMemoryCacheService 
    {
        bool GetData<T>(string key, out T result);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);

    }
}
