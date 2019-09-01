using System;
using Microsoft.AspNetCore.Mvc;

namespace Zip.Api.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return new OkObjectResult(new { timestamp = DateTime.Now });
        }
    }
}