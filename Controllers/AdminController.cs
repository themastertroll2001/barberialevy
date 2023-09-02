using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Barberia.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View("Dashboard", "_LayoutAdmin");
        }
        public IActionResult Productos()
        {
            return View("Productos", "_LayoutAdmin");
        }
        public IActionResult Usuarios()
        {
            return View("Usuarios", "_LayoutAdmin");
        }
    }
}
