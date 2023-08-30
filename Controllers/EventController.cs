using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Barberia.Data;
using Barberia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Barberia.Controllers
{
    [Authorize]
    public class EventController : Controller
    {

        private readonly IDAL _dal;
        private readonly UserManager<IdentityUser> _userManager;
        public EventController(IDAL dal, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _dal = dal;
        }

        // GET: Event
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetEvents());

        }

        // GET: Event/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection form)
        {
            try
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var newEvent = new Event
                {
                    Nombre = form["Nombre"],
                    Descripcion = form["Descripcion"],
                    Telefono = int.Parse(form["Telefono"]),
                    Fechainicio = DateTime.Parse(form["Fechainicio"]),
                    Finfecha = DateTime.Parse(form["Finfecha"]),
                    UserId = userId
                };
                _dal.CreateEvent(newEvent);
                TempData["Alert"] = "¡Éxito! Has creado un nuevo evento: " + form["Nombre"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "Ocurrió un error: " + ex.Message;
                return View();
            }
        }

        // GET: Event/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _dal.GetEvent((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event); // Aquí puedes pasar un ViewModel si es necesario

        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection form)
        {
            try
            {
                var updatedEvent = new Event
                {
                    Id = id,
                    Nombre = form["Nombre"],
                    Descripcion = form["Descripcion"],
                    Telefono = int.Parse(form["Telefono"]),
                    Fechainicio = DateTime.Parse(form["Fechainicio"]),
                    Finfecha = DateTime.Parse(form["Finfecha"]),
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _dal.UpdateEvent(updatedEvent);
                TempData["Alert"] = "¡Éxito! Has modificado el evento: " + form["Nombre"];
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "Ocurrió un error: " + ex.Message;
                return View();
            }
        }

        // GET: Event/Delete/5
        public IActionResult Delete(int? id)
        {
            var @event = _dal.GetEvent((int)id);

            // Obtener el correo electrónico del usuario actualmente autenticado
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var email = user?.Email;

            // Pasar el correo electrónico al modelo
            @event.UserId = email;

            // ...

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteEvent(id);
            TempData["Alert"] = "Has eliminado un evento.";
            return RedirectToAction(nameof(Index));
        }
    }
}
