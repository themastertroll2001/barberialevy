using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Barberia.Models;
using Barberia.Data;

namespace Barberia.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Compras()
    {
        return View();
    }
    public IActionResult Inventarioprod()
    {
        return View();
    }
   
    [HttpPost] // Cambio: Usar POST para procesar el formulario
    public IActionResult CalcularTotal(decimal precio, int cantidad)
    {
        decimal total = precio * cantidad;
        return Json(new { Total = total }); // Devolver el resultado como JSON
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
