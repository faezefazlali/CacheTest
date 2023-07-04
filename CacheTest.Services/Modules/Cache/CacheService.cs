using CacheTest.Common.DTOs.Common;
using CacheTest.Services.Contracts.Cache;


namespace CacheTest.Services.Modules.Cache
{
    public sealed class CacheService: ICacheService
    {
        private readonly IRedisService _redisService;
        private readonly IMemoryCacheService _memoryCacheService;

        public CacheService(IRedisService redisService, IMemoryCacheService memoryCacheService)
        {
            _redisService = redisService;
            _memoryCacheService = memoryCacheService;
        }

        public T GetOrSet<T>(string key, Func<T> getData)
        {
            if (!_memoryCacheService.GetData(key, out T data))
            {
                var expirationTime = DateTimeOffset.Now.AddMinutes(5.0);

                if (!_redisService.GetData(key, result: out T redisData))
                {
                    redisData = getData();
                    if (data == null)
                        return default;
                    _redisService.SetData(key, redisData);
                }
                _memoryCacheService.SetData(key, redisData, expirationTime);
                return redisData;
            }
            return data;
        }

    }
}
