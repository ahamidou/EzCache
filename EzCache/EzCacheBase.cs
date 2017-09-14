using System;
using System.Runtime.Caching;

namespace EzCache
{

    public abstract class EzCacheBase<T> : IEzCache<T>
    {
        private static ObjectCache _cache;
        private Func<CacheItemPolicy> _policy;

        protected EzCacheBase(Func<CacheItemPolicy> policy = null)
        {
            _policy = policy ?? (() => { return new CacheItemPolicy(); });
        }

        protected ObjectCache Cache => _cache ?? (_cache = MemoryCache.Default);

        /// <summary>
        /// Must be unique per implementing class
        /// </summary>
        protected abstract string Identifier { get; }

        public virtual void Flush()
        {
            Cache.Remove(Identifier);
        }

        public virtual T Retrieve() => (T)Cache[Identifier];

        public virtual void Update(T value)
        {
            Cache.Set(Identifier, value, _policy.Invoke());
        }
    }
}
