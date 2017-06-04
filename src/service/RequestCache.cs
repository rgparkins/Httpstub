using System.Collections.Concurrent;
using System.Linq;

namespace service
{
    public interface ICacheRequests
    {
        void AddOrUpdate(string path, object content);

        object FetchByKey(string key);

        void RemoveByPath(string key);

        void RemoveAll();
    }


    public class RequestCache : ICacheRequests
    {
        ConcurrentDictionary<string, object> _cache = new ConcurrentDictionary<string, object>();

        public void AddOrUpdate(string path, object content)
        {
            _cache.AddOrUpdate(path, content, (k, v) => { return content; });
        }

        public void RemoveByPath(string path)
        {
            object @object;

            _cache.TryRemove(path, out @object);
        }

        public void RemoveAll()
        {
            _cache.Keys.ToList().ForEach(k =>
            {
                RemoveByPath(k);
            });
        }

        public object FetchByKey(string key)
        {
            if (_cache.ContainsKey(key))
            {
                return _cache[key];
            }

            return null;
        }
    }
}
