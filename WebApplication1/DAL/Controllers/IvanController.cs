using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    public class IvanController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IvanController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IvanHeloWorld([FromQuery]string from)
        {
            string model = "hello word from "+from;
            return View("IvanHeloWorld", model);
        }
    }
}