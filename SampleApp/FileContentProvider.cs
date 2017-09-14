using EzCache;
using System;
using System.IO;

namespace CacheApp
{
    public class FileContentProvider
    {
        private string _filePath;
        private IEzCache<string> fileCacheProvider;
        public FileContentProvider(string filePath)
        {
            _filePath = filePath;
            fileCacheProvider = new FileCacheProvider(_filePath);
        }

        public string GetContents()
        {
            var fileContents = fileCacheProvider.Retrieve();
            if (fileContents == null)
            {
                fileContents = $"{File.ReadAllText(_filePath)}\nRetrieved: {DateTime.Now:G}";
                fileCacheProvider.Update(fileContents);
            }
            return fileContents;
        }
    }
}
