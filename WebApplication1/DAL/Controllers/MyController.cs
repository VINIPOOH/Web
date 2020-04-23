using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MyController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetHelloWordWithString([FromQuery]string from)
        {
            string model = $"hello word from {from}";
            return View("GetHelloWordWithString", model);
        }

    }
}
