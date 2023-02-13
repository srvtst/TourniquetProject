﻿using CoreLayer.CrossCuttingConcerns.Caching.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace CoreLayer.CrossCuttingConcerns.Caching.Concrete
{
    public class MemoryCacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public bool IsThere(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}