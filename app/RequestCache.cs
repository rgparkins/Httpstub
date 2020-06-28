using System.Collections.Concurrent;
using System.Linq;

namespace rgparkins.HttpStub
{
    public interface ICacheRequests
    {
        void AddOrUpdate(string path, object content);

        object FetchByKey(string key);

        void RemoveByPath(string key);
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
            _cache.Keys.ToList().ForEach(k =>
            {
                if (k.StartsWith(path))
                {
                    RemoveKey(k);
                }
            });
        }

        private void RemoveKey(string key)
        {
            object @object;

            _cache.TryRemove(key, out @object);
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
