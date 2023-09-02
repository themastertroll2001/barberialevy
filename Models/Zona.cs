using System.ComponentModel.DataAnnotations;

namespace Barberia.Models
{
    public class Zona
    {
        [Key]
        public string IdZona { get; set; }
        public string Descripcion { get; set; }
    }
}
