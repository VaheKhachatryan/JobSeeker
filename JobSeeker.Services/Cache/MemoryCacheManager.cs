using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VeroxTech.Services.Interfaces.Cache;

namespace VeroxTech.Services.Cache
{
	public class MemoryCacheManager : ICacheManager
	{
		private readonly IMemoryCache _memoryCache;

		public MemoryCacheManager(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		public T Get<T>(string key)
		{
			return _memoryCache.Get<T>(key);
		}

		public T Get<T>(string key, Func<T> acquire, bool cacheForce = false)
		{
			T result = _memoryCache.Get<T>(key);
			if (result == null || cacheForce)
			{
				result = acquire();
				Set(key, result);
			}

			return result;
		}

		public async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, bool cacheForce = false)
		{
			T result = _memoryCache.Get<T>(key);
			if (result == null || cacheForce)
			{
				result = await acquire();
				Set(key, result);
			}

			return result;
		}

		public object Set(string key, object data, TimeSpan cacheTime)
		{
			return _memoryCache.Set(key, data, cacheTime);
		}

		public T Set<T>(string key, T data)
		{
			return _memoryCache.Set<T>(key, data);
		}

		public T Set<T>(string key, T data, TimeSpan cacheTime)
		{
			return _memoryCache.Set<T>(key, data, cacheTime);
		}


		public bool UpdateCacheDictionary<TKey, TEntity>(string cacheType, TKey key, TEntity entity)
		{
			bool result = false;
			var entities = Get<Dictionary<TKey, TEntity>>(cacheType);

			if (entities != null)
			{
				var currentEntity = entities[key];
				if (currentEntity == null)
				{
					entities.Add(key, entity);
				}
				else
				{
					entities[key] = entity;
				}

				result = true;
			}

			return result;
		}

		public void Remove(string key)
		{
			_memoryCache.Remove(key);
		}

		public virtual void Dispose()
		{
			//nothing special
		}
	}
}
