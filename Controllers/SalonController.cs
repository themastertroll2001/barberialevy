using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barberia.Models;
namespace Barberia.Controllers
{
    public class SalonController : Controller
    {
        private readonly ILogger<SalonController> _logger;

        public SalonController(ILogger<SalonController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Registrocitas()
        {
            return View();
        }
        public IActionResult Citasdiarias()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
