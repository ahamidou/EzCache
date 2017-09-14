using EzCache;
using System;
using System.Runtime.Caching;

namespace CacheApp
{
    public class FileCacheProvider : EzCacheBase<string>
    {
        public FileCacheProvider(string filePath) : base(() =>
          {
              CacheItemPolicy policy = new CacheItemPolicy
              {
                  AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(60)
              };
              policy.ChangeMonitors.Add(new HostFileChangeMonitor(new string[] { filePath }));
              return policy;
          })
        { }

        protected override string Identifier => "filecontent";
    }
}
