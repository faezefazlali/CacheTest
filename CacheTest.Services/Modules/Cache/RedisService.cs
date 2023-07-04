using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Newtonsoft.Json;
using CacheTest.Services.Contracts.Cache;

namespace CacheTest.Services.Modules.Cache

{
    public sealed class RedisService : IRedisService
    {
        private readonly IDistributedCache _redisCashe;

        public RedisService(IDistributedCache redisCashe)
        {
            _redisCashe = redisCashe;
        }

        public void SetData(string key, object data, int cacheTimeInMinutes)
        {
            var json = JsonConvert.SerializeObject(data);
            var expiresIn = TimeSpan.FromMinutes(cacheTimeInMinutes);
            var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expiresIn);

            _redisCashe.SetString(key, json, options);

        }

        public bool GetData<T>(string key, out T result)
        {
            var json = _redisCashe.GetString(key);
            if (json == null)
            {
                result = default;
                return false;
            }
            result = JsonConvert.DeserializeObject<T>(json);
            return true;
        }


    }
}
