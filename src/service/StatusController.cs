using Microsoft.AspNetCore.Mvc;

namespace service
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