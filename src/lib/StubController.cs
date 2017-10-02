using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Parkwell.HttpStub
{
    public class StubController : Controller
    {
        private ICacheRequests _cache;

        public StubController(ICacheRequests cache)
        {
            _cache = cache;
        }

        [Route("{*catchall}")]
        [HttpPost]
        public IActionResult Post([FromBody]object data)
        {
            _cache.AddOrUpdate(Request.Path, data);

            return Ok();
        }

        [Route("{*catchall}")]
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None)]
        public IActionResult Get()
        {
            var cacheValue = _cache.FetchByKey(Request.Path);

            if (cacheValue == null)
            {
                return NotFound();
            }

            return Ok(cacheValue);
        }

        [Route("{*catchall}")]
        [HttpDelete]
        public IActionResult Delete()
        {
            _cache.RemoveByPath(Request.Path);
            
            return Ok();
        }
    }
}