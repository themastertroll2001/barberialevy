using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public bool Activo { get; set; }
       // servira para img public string base64 { get; set; }
       //  servira para img public string extension { get; set; }
    }
}
