using Microsoft.AspNetCore.Mvc;

namespace Parkwell.HttpStub
{
    public class StatusController : Controller
    {
        [Route("private/ping")]
        public IActionResult Ping()
        {
            return Ok("pong");
        }
    }
}