using Microsoft.AspNetCore.Mvc;

namespace httpstub
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