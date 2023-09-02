using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class DetalleCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public Producto Productos { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
