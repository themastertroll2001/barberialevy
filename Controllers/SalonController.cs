using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barberia.Data;
using Barberia.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Barberia.Controllers
{
    public class SalonController : Controller
    {
        private readonly ILogger<SalonController> _logger;
        private readonly IDAL _idal;
        public SalonController(ILogger<SalonController> logger, IDAL idal)
        {
            _logger = logger;
            _idal = idal;
        }
       
        public IActionResult Index()
        {
            return View();
        }
       
       
        public IActionResult Citasdiarias()
        {
            ViewData["Events"] = JSONListEvent.GetEventListJSONString(_idal.GetEvents()); // Añade esta línea
            return View();

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
