using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApliVentas.BD.Data.Entity
{
   public class Ganancia
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "la fecha del dia debe ser OBLIGATORIO")]
        [MaxLength(8, ErrorMessage = "Solo se aceptan hasta 8 caracteres en la fecha")]
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "El Precio del Producto comprado a proveedores debe ser OBLIGATORIO")]

        public int precio { get; set; }

        [Required(ErrorMessage = "El Porcentaje del Producto que se desea obtener debe ser OBLIGATORIO")]

        public int porcentajeGanancia { get; set; }

    }
}
