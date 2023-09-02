using System.ComponentModel.DataAnnotations;
namespace Barberia.Models
{
    public class Compra
    {
        [Key]
        public int IdCompra { get; set; }
        public string? UserId { get; set; }
        public int TotalProducto { get; set; }
        public decimal Total { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }  
        public string Direccion { get; set; }
        public string IdZona { get; set; }
        public string FechaTexto { get; set; }
        public string IdTransaccion { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; }
    }
}
