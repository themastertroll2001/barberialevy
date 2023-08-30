using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;  // Inicialización en línea

        public string Descripcion { get; set; } = string.Empty;  // Inicialización en línea

        public int Telefono { get; set; }

        public DateTime Fechainicio { get; set; }

        public DateTime Finfecha { get; set; }

        // Relación con IdentityUser
        public string? UserId { get; set; }

        public IdentityUser? User { get; set; }

        public Event(IFormCollection form)
        {
            Nombre = form["Event.Nombre"].ToString() ?? string.Empty; // Utilizando el operador null-coalescing
            Descripcion = form["Event.Descripcion"].ToString() ?? string.Empty; // Utilizando el operador null-coalescing
            Telefono = int.TryParse(form["Event.Telefono"].ToString(), out int tempTelefono) ? tempTelefono : 0;
            Fechainicio = DateTime.TryParse(form["Event.Fechainicio"].ToString(), out DateTime tempFechainicio) ? tempFechainicio : DateTime.MinValue;
            Finfecha = DateTime.TryParse(form["Event.Finfecha"].ToString(), out DateTime tempFinfecha) ? tempFinfecha : DateTime.MinValue;
        }

        public void UpdateEvent(IFormCollection form)
        {
            Nombre = form["Event.Nombre"].ToString() ?? string.Empty; // Utilizando el operador null-coalescing
            Descripcion = form["Event.Descripcion"].ToString() ?? string.Empty; // Utilizando el operador null-coalescing
            Telefono = int.TryParse(form["Event.Telefono"].ToString(), out int tempTelefono) ? tempTelefono : 0;
            Fechainicio = DateTime.TryParse(form["Event.Fechainicio"].ToString(), out DateTime tempFechainicio) ? tempFechainicio : DateTime.MinValue;
            Finfecha = DateTime.TryParse(form["Event.Finfecha"].ToString(), out DateTime tempFinfecha) ? tempFinfecha : DateTime.MinValue;
        }

        public Event()
        {
            // Inicializando en el constructor
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }
    }
}
