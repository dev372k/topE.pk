using DL.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ICacheService
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
        bool Remove(string key);
    }
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void Set<T>(string key, T value) => _cache.Set(key, JsonConvert.SerializeObject(value), CacheHelper.CacheOptions());

        public T Get<T>(string key)
        {
            var value = _cache.Get<string>(key);

            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);
            return default;
        }

        public bool Remove(string key)
        {
            var value = _cache.Get<string>(key);
            if (string.IsNullOrEmpty(value))
                return false;

            _cache.Remove(key);
            return true;
        }
    }
}
