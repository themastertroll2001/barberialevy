using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }
        public Producto Productos { get; set; }
        public string? UserId { get; set; }
    }
}
