using CacheTest.Services.Contracts.Cache;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using System.Runtime.Caching;

namespace CacheTest.Services.Modules.Cache
{
    public sealed class MemoryCacheService : IMemoryCacheService
    {
        ObjectCache _memoryCache = MemoryCache.Default;
        public bool GetData<T>(string key, out T result)
        {
            var data = _memoryCache.Get(key);
            if (data == null)
            {
                result = default;
                return false;
            }
            result = (T)data;
            return true;
        }


        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            bool res = true;

            if (!string.IsNullOrEmpty(key))
            {
                _memoryCache.Set(key, value, expirationTime);
            }
            return res;
        }

    }
}
