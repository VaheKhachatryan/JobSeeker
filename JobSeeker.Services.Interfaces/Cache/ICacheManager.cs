using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VeroxTech.Services.Interfaces.Cache
{

	public interface ICacheManager : IDisposable
	{
		T Get<T>(string key);
		T Get<T>(string key, Func<T> acquire, bool cacheForce = false);
		Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, bool cacheForce = false);

		object Set(string key, object data, TimeSpan cacheTime);

		T Set<T>(string key, T data);

		T Set<T>(string key, T data, TimeSpan cacheTime);

		bool UpdateCacheDictionary<TKey, TEntity>(string cacheType, TKey key, TEntity entity);
	}
}
